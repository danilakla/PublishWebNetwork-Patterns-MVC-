using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Decorator
{
	public interface ICake
	{
		void AddLayer(string layer);
		void PrintLayers();
	}

	public class VanillaCake : ICake
	{
		private readonly List<string> layers = new();
		public void AddLayer(string layer)
		{
			layers.Add(layer);
		}

		public void PrintLayers()
		{
			foreach (var layer in layers)
			{
				Console.WriteLine($"Layer: {layer}");
				Console.WriteLine(" ---------- ");
			}
		}
	}

	public class ChocolateCake : ICake
	{
		private readonly List<string> layers = new();
		public void AddLayer(string layer)
		{
			layers.Add(layer);
		}

		public void PrintLayers()
		{
			foreach (var layer in layers)
			{
				Console.WriteLine($"Chocolate Layer: {layer}");
				Console.WriteLine(" ---------- ");
			}
		}
	}
	public interface ICakeMessageDecorator
	{
		void Decorate(string message);
	}

	public class CakeMessageDecorator
	: ICakeMessageDecorator
	{
		private readonly ICake cake;

		public CakeMessageDecorator(ICake cake)
		{
			this.cake = cake;
		}

		public void Decorate(string message)
		{
			cake.AddLayer($"Message for the cake: {message}");
		}
	}
}
