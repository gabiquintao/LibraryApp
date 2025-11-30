using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Shared
{
	/// <summary>
	/// Represents the result of an operation, encapsulating success status and an optional error message.
	/// Used for operations that do not return a value.
	/// </summary>
	public class Result
	{
		private readonly bool _success;
		private readonly string? _errorMessage;

		/// <summary>
		/// Gets a value indicating whether the operation succeeded.
		/// </summary>
		public bool Success
		{
			get { return _success; }
		}

		/// <summary>
		/// Gets the error message if the operation failed; otherwise, null.
		/// </summary>
		public string? ErrorMessage
		{
			get { return _errorMessage; }
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Result"/> for a successful operation.
		/// </summary>
		private Result()
		{
			_success = true;
			_errorMessage = null;
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Result"/> for a failed operation.
		/// </summary>
		/// <param name="error">The error message describing the failure.</param>
		private Result(string error)
		{
			_success = false;
			_errorMessage = error;
		}

		/// <summary>
		/// Creates a <see cref="Result"/> representing a successful operation.
		/// </summary>
		/// <returns>A <see cref="Result"/> with success = true.</returns>
		public static Result Ok()
		{
			return new Result();
		}

		/// <summary>
		/// Creates a <see cref="Result"/> representing a failed operation.
		/// </summary>
		/// <param name="error">The error message describing the failure.</param>
		/// <returns>A <see cref="Result"/> with success = false.</returns>
		public static Result Fail(string error)
		{
			return new Result(error);
		}
	}

	/// <summary>
	/// Represents the result of an operation, encapsulating success status, value, or an error message.
	/// Used when the operation returns a value of type T.
	/// </summary>
	/// <typeparam name="T">The type of the value returned in case of success.</typeparam>
	public class Result<T>
    {
		private readonly bool _success;
		private readonly T? _value;
		private readonly string? _errorMessage;

		/// <summary>
		/// Gets a value indicating whether the operation succeeded.
		/// </summary>
		public bool Success
        {
            get { return _success; }
        }

		/// <summary>
		/// Gets the value returned by the operation if it succeeded; otherwise, null.
		/// </summary>
		public T? Value
        {
            get { return _value; }
        }

		/// <summary>
		/// Gets the error message if the operation failed; otherwise, null.
		/// </summary>
		public string? ErrorMessage
        {
            get { return _errorMessage; }
        }

		/// <summary>
		/// Initializes a new instance of <see cref="Result{T}"/> for a successful operation.
		/// </summary>
		/// <param name="value">The value of the successful operation.</param>
		private Result(T value)
        {
            _success = true;
            _value = value;
        }

		/// <summary>
		/// Initializes a new instance of <see cref="Result{T}"/> for a failed operation.
		/// </summary>
		/// <param name="error">The error message describing the failure.</param>
		private Result(string error)
		{
			_success = false;
			_value = default;
			_errorMessage = error;
		}

		/// <summary>
		/// Creates a <see cref="Result{T}"/> representing a successful operation.
		/// </summary>
		/// <param name="value">The value of the successful operation.</param>
		/// <returns>A <see cref="Result{T}"/> with success = true.</returns>
		public static Result<T> Ok(T value)
        {
            return new Result<T>(value);
        }

		/// <summary>
		/// Creates a <see cref="Result{T}"/> representing a failed operation.
		/// </summary>
		/// <param name="error">The error message describing the failure.</param>
		/// <returns>A <see cref="Result{T}"/> with success = false.</returns>
		public static Result<T> Fail(string error)
		{
			return new Result<T>(error);
		}
	}
}
