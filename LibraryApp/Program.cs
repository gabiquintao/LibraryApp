using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Shared;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace LibraryApp
{
    public class Program
    {
		public static void Main(string[] args)
		{
			BookRepository bookRepo = new BookRepository();

			Console.WriteLine("=== TESTE: Books normais ===");

			Book book1 = new Book("Sociedade do Anel", "Tolkien", 1954);
			Book book2 = new Book("As Duas Torres", "Tolkien", 1954);
			Book book3 = new Book("O Retorno do Rei", "Tolkien", 1955);

			bookRepo.Add(book1);
			bookRepo.Add(book2);
			bookRepo.Add(book3);

			Console.WriteLine("Livros adicionados!");
			Console.WriteLine();

			Result<IReadOnlyCollection<Book>> books = bookRepo.GetAll();
			foreach (var b in books.Value)
				Console.WriteLine($"-> {b.Title} ({b.Year})");

			Console.WriteLine();
			Console.WriteLine("=== TESTE: Equals e HashCode ===");

			bool equals = book1.Equals(book2);
			Console.WriteLine($"book1 == book2 ? {equals}");

			Console.WriteLine($"Hash book1: {book1.GetHashCode()}");
			Console.WriteLine($"Hash book2: {book2.GetHashCode()}");
			Console.WriteLine($"Hash book3: {book3.GetHashCode()}");

			Console.WriteLine();
			Console.WriteLine("=== TESTE: Update e Remove ===");

			bookRepo.Update(1, "Titulo Alterado", null, null);
			Console.WriteLine("Livro 1 atualizado.");

			var found = bookRepo.FindById(1);
			Console.WriteLine($"Livro atualizado: {found.Value.Title}");

			bookRepo.Remove(1);
			Console.WriteLine("Livro 1 removido.");

			Console.WriteLine();
			Console.WriteLine("=== TESTE: Herança e Polimorfismo ===");

			Book ebook = new EBook(
				"Sociedade do Anel (EBook)",
				"Tolkien",
				1954,
				"PDF",
				1.23
			);

			// Herança → EBook é tratado como Book
			Console.WriteLine($"ebook.Title: {ebook.Title}"); // OK

			// Polimorfismo → Chamamos um método virtual (se existir)
			// Aqui só mostramos o tipo efetivo
			Console.WriteLine($"Tipo real do ebook: {ebook.GetType().Name}");

			// Cast para aceder às propriedades específicas da subclasse
			EBook e = (EBook)ebook;
			Console.WriteLine($"Formato: {e.FileFormat}, Tamanho: {e.FileSizeMB}MB");

			Console.WriteLine();
			Console.WriteLine("=== TESTE: Lista Polimórfica ===");

			List<Book> mixed = new List<Book>();
			mixed.Add(book2);
			mixed.Add(book3);
			mixed.Add(ebook); // aqui está a magia — lista aceita EBook como Book

			foreach (Book b in mixed) {
				Console.WriteLine($"[{b.GetType().Name}] {b.Title}");
			}
		}
    }
}
