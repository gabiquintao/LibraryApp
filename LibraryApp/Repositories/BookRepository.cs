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

		/// <summary>
		/// Updates the properties of an existing book in the repository, identified by its ID.
		/// Performs validation and fails if another book with the same properties already exists.
		/// </summary>
		/// <param name="id">The unique identifier of the book to update.</param>
		/// <param name="title">The new title of the book, or null to leave unchanged.</param>
		/// <param name="author">The new author of the book, or null to leave unchanged.</param>
		/// <param name="year">The new publication year of the book, or null to leave unchanged.</param>
		/// <returns>
		/// A <see cref="Result"/> indicating success or failure.
		/// Fails if the book does not exist or if a duplicate exists with the same properties.
		/// </returns>
		public Result Update(int id, string? title, string? author, int? year)
		{
			Result<Book> findResult = FindById(id);

			if (!findResult.Success || findResult.Value == null)
			{
				return Result.Fail(findResult.ErrorMessage ?? $"Book with ID {id} not found.");
			}

			Book current = findResult.Value;

			Book temp = new Book(
				title ?? current.Title,
				author ?? current.Author,
				year ?? current.Year
			);


			if (ExistsDuplicate(temp))
			{
				return Result.Fail("Book already exists.");
			}

			current.Update(title, author, year);
			return Result.Ok();
		}
	}
}
