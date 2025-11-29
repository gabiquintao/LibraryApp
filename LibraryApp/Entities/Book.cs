using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Entities
{
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
		/// Title of the book. Cannot be empty.
		/// </summary>
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
		/// Author of the book. Cannot be empty.
		/// </summary>
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
		/// Book publication year. Must be between 0 and 2025.
		/// </summary>
		public int Year
        {
            get { return _year; }
            set { 
                if (value < 0 || value > 2025)
                {
                    throw new ArgumentException("Book publication year must be between 0 and 2025");
                }
                _year = value; 
            }
        }

        private static int _nextId = 0;

		/// <summary>
		/// Represents a book in the library.
		/// </summary>
		/// <param name="title">The title of the book.</param>
		/// <param name="author">The author of the book.</param>
        /// <param name="year">Publication year.</param>
		public Book(string title, string author, int year)
        {
            _id = _nextId++;
            Title = title;
            Author = author;
            Year = year;
        }
    }
}
