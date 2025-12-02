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
		public bool ExistsDuplicate(Book book);
		public Result Update(int id, string? title, string? author, int? year);
		public Result Remove(int id);
	}
}
