using Data.DataContext;
using Data.Models;
using Pattern.Stratage.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratage.Class
{
	public class DataSql : ISave
	{

		private readonly PublishDbContext _context;
		public DataSql(PublishDbContext context) { 
		_context= context;	
		}
		public void Save(string msg)
		{
			User user = new User
			{
				Email = msg,
			IsAdmin= true,
			Password= msg,
			
			};

			_context.Users.Add(user);

			_context.SaveChanges();

		}
	}
}
