using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Entities
{
    public class User
    {
        private readonly int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private static int _nextId = 0;

		/// <summary>
		/// Represents a user in the library.
		/// </summary>
		/// <param name="title">The title of the book.</param>
		/// <param name="author">The author of the book.</param>
		/// <param name="year">Publication year.</param>
		public User(string name)
        {
            _id = _nextId++;
            Name = name;
        }
    }
}
