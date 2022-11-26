using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Memento
{
	public record Memento(string Name, int Age, string Phone);

	public interface IEmployee
	{
		string Name { get; set; }
		public int Age { get; set; }
		public string Phone { get; set; }

		Memento Create();
		void Undo(Memento memento);
	}


	public class Employee : IEmployee
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Phone { get; set; }

		public Memento Create()=>new Memento(Name, Age, Phone);


		public void Undo(Memento memento)
		{
			Name= memento.Name;
			Age= memento.Age;
			Phone= memento.Phone;

		}
	}
}
