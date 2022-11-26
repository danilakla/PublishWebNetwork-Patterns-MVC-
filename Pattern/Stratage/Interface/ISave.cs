using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratage.Interface
{

	public interface IDataSave
	{
		void saveData(ISave db, string msg);
	}
	public interface ISave
	{
		 void Save(string msg);
	}
}
