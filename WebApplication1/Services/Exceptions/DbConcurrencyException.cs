using System;

namespace WebApplication1.Services.Exceptions
{
	public class DbConcurrencyException : ApplicationException
	{
		public DbConcurrencyException (string message) : base(message)
		{

		}
	}
}
