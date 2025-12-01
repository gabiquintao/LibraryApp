using LibraryApp.Entities;
using LibraryApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Repositories
{
	/// <summary>
	/// Represents the data layer of the application for managing books.
	/// </summary>
	public class BookRepository : IBookRepository
    {
		/// <summary>
		/// In-memory list as the data source.
		/// </summary>
		private readonly Dictionary<int, Book> _books = new Dictionary<int, Book>();

		/// <summary>
		/// Returns a readonly collection of books.
		/// </summary>
		public Result<IReadOnlyCollection<Book>> GetAll()
		{
			return Result<IReadOnlyCollection<Book>>.Ok(_books.Values);
		}

		/// <summary>
		/// Finds a book by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the book to find.</param>
		/// <returns>
		/// The book with the specified ID if found; otherwise, null.
		/// </returns>
		public Result<Book> FindById(int id)
        {
			if (_books.TryGetValue(id, out Book? book))
			{
				return Result<Book>.Ok(book);
			}

			return Result<Book>.Fail($"Book with ID {id} not found.");
        }

		/// <summary>
		/// Adds a book to the data source.
		/// </summary>
		/// <param name="book">The book object to add.</param>
		public Result Add(Book book)
		{
			if (_books.TryAdd(book.Id, book))
			{
				return Result.Ok();
			}

			return Result.Fail($"Book with ID {book.Id} already exists.");
		}

		/// <summary>
		/// Determines whether a book with already with the same properties exists in the repository, excluding the book itself.
		/// </summary>
		/// <param name="book">The book to check for duplication.</param>
		/// <returns>True if a duplicate exists; otherwise, false.</returns>
		public bool ExistsDuplicate(Book book)
		{
			foreach (Book b in _books.Values)
			{
				if (b.Id == book.Id)
				{
					continue;
				}

				if (book.Equals(b))
				{
					return true;
				}
			}

			return false;
		}
	}
}
