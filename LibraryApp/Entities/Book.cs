using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Entities
{
	/// <summary>
	/// Represents a book in the library.
	/// </summary>
	public class Book
    {
        private readonly int _id;
        private string _title = "";
        private string _author = "";
        private int _year;

        public int Id
        {
            get { return _id; }
        }

		/// <summary>
		/// Title of the book.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when title is empty or whitespace.</exception>
		public string Title
        {
            get { return _title; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty.");
                }
                _title = value;
            }
        }

		/// <summary>
		/// Author of the book.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when author name is empty or whitespace.</exception>
		public string Author
        {
            get { return _author; }
            set { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author name cannot be empty.");
                }
                _author = value; 
            }
        }

		/// <summary>
		/// Minimum allowed publication year.
		/// </summary>
		private const int minYear = 0;

		/// <summary>
		/// Maximum allowed publication year.
		/// </summary>
		private const int maxYear = 2025;

		/// <summary>
		/// Book publication year.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown if year is outside valid range.</exception>
		public int Year
        {
            get { return _year; }
            set { 
                if (value < minYear || value > maxYear)
                {
                    throw new ArgumentException($"Book publication year must be between {minYear} and {maxYear}");
                }
                _year = value; 
            }
        }

		/// <summary>
		/// Static counter to generate unique IDs for each book.
		/// </summary>
		private static int _nextId = 0;

		/// <summary>
		/// Initializes a new instance of the Book class with title, author, and publication year.
		/// </summary>
		/// <param name="title">The title of the book.</param>
		/// <param name="author">The author of the book.</param>
		/// <param name="year">The publication year.</param>
		/// <exception cref="ArgumentException">Thrown when any parameter is invalid.</exception>
		public Book(string title, string author, int year)
        {
            _id = _nextId++;
            Title = title;
            Author = author;
            Year = year;
        }

		/// <summary>
		/// Returns a string representation of the book.
		/// </summary>
		public override string ToString()
		{
			return $"{Id}: \"{Title}\" by {Author} ({Year})";
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current book.
		/// Two books are considered equal if they have the same Title, Author, and Year.
		/// </summary>
		/// <param name="obj">The object to compare with the current book.</param>
		/// <returns>True if the objects are equal; otherwise, false.</returns>
		public override bool Equals(object? obj)
        {
            if (obj is not Book)
            {
                return false;
            }

            Book other = (Book)obj;
            return Title == other.Title && Author == other.Author && Year == other.Year;
        }

		public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Year);
        }
	}
}
