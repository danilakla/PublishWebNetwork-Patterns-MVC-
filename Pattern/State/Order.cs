using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.State
{
	public class Order
	{
		public enum State
		{
			Stopped,
			Started,
			Running
		}

		public enum Action
		{
			Stop,
			Start,
			Accelerate
		}

		private State state = State.Stopped;

		public State CurrentState { get { return state; } }

		public void TakeAction(Action action)
		{
			state = (state, action) switch
			{
				(State.Stopped, Action.Start) => State.Started,
				(State.Started, Action.Accelerate) => State.Running,
				(State.Started, Action.Stop) => State.Stopped,
				(State.Running, Action.Stop) => State.Stopped,
				_ => state
			};
		}
	}
}
