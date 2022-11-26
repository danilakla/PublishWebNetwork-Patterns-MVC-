using Pattern.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Adapter
{
	public class Book
	{
		public string Name { get; set; }
		public string Text{ get; set; }

		public int Age{ get; set; }

		public void print()
		{
			Console.WriteLine("Book");
		}
	
	}
	interface IBookAdapter
	{
		void CalculateAge();
	}
	public class AdapterBook : Book, IBookAdapter
	{
		public void CalculateAge()
		{
			Console.WriteLine(DateTime.Now.Year-base.Age);
		}
	}
}
