using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Memento
{

	interface IEmployeeManager
	{
		void AddMemento(Memento memento);
		Memento GetMemento();
	}
	public class EmployeeManager : IEmployeeManager
	{

		private readonly Stack<Memento> _stack = new Stack<Memento>();

		public void AddMemento(Memento memento)=>_stack.Push(memento);
		public Memento GetMemento()=>_stack.Pop();
	}
}
