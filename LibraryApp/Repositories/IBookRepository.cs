using System.Collections.Generic;
using LibraryApp.Entities;
using LibraryApp.Shared;

namespace LibraryApp.Repositories
{
	/// <summary>
	/// Defines the contract for a repository that manages Book entities.
	/// </summary>
	public interface IBookRepository
	{
		public Result<IReadOnlyCollection<Book>> GetAll();
		public Result<Book> FindById(int id);
		public Result Add(Book book);
	}
}
