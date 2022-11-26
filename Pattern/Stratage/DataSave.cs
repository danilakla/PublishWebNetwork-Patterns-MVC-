using Pattern.Stratage.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratage
{
	public class DataSave:IDataSave
	{
		public void saveData(ISave db,string msg)
		{
			if(db != null)
			{
				db.Save(msg);
			}
		}
	}
}
