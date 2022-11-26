using Pattern.Stratage.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratage.Class
{
	public class DataTxt : ISave
	{

		public void Save(string msg="error")
		{
			using(var stream=new StreamWriter("test3.txt")) { 
			stream.Write(msg+"foreign");
			}
		}
	}
}
