using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Entities
{
	/// <summary>
	/// Represents a user in the library.
	/// </summary>
	public class User
    {
        private readonly int _id;
        private string _name = "";

        public int Id
        {
            get { return _id; }
        }

		/// <summary>
		/// Name of the user.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when title is empty or whitespace.</exception>
		public string Name
        {
            get { return _name; }
            set { 
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Name cannot be empty.");
                }
                _name = value;
            }
        }

        private static int _nextId = 0;

		/// <summary>
		/// Represents a user in the library.
		/// </summary>
		/// <param name="name">The name of the user.</param>
		/// <exception cref="ArgumentException">Thrown when any parameter is invalid.</exception>
		public User(string name)
        {
            _id = _nextId++;
            Name = name;
        }

		/// <summary>
		/// Returns a string representation of the user.
		/// </summary>
		public override string ToString()
		{
			return $"{Id}: \"{Name}\"";
		}
	}
}
