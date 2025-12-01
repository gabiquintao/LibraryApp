using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Entities
{
	/// <summary>
	/// Represents a eBook in the library, inheriting from Book and adding digital properties.
	/// </summary>
	public class EBook : Book
    {
        private string _fileFormat = "";
        private double _fileSizeMB;

		/// <summary>
		/// File format of the eBook.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when title is empty or whitespace.</exception>
		public string FileFormat
        {
            get { return _fileFormat; }
            set { _fileFormat = value; }
        }

		/// <summary>
		/// File size in Megabytes of the eBook.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when title is empty or whitespace.</exception>
		public double FileSizeMB
        {
            get { return _fileSizeMB; }
            set { _fileSizeMB = value; }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="EBook"/> class.
		/// </summary>
		/// <param name="title">The title of the book.</param>
		/// <param name="author">The author of the book.</param>
		/// <param name="year">The publication year of the book.</param>
		/// <param name="fileFormat">The digital file format of the eBook (e.g., PDF, EPUB).</param>
		/// <param name="fileSizeMB">The size of the eBook file in megabytes.</param>
		public EBook(string title, string author, int year, string fileFormat, double fileSizeMB)
            : base(title, author, year)
        {
            FileFormat = fileFormat;
            FileSizeMB = fileSizeMB;
        }

		/// <summary>
		/// Returns a string representation of the eBook.
		/// </summary>
		public override string ToString()
		{
			return $"{base.ToString()} [{FileFormat} | {FileSizeMB} MB]";
		}

		/// <summary>
		/// Returns a string with information for the download of the eBook.
		/// </summary>
		/// <returns>A descriptive string including title, file format, and file size.</returns>
		public string DownloadInfo()
		{
			return $"Download Info: '{Title}' ({FileFormat} | {FileSizeMB} MB)";
		}
	}
}
