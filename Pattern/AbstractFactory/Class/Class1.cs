using Data.Models;
using Pattern.AbstractFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.AbstractFactory.Class
{
	public class ForeignPublish: IPublishCatalog
	{
		public List<Publish> GetPublish()
		{
			return new List<Publish>() { new Publish { Desctiprion = "foreign " } };
		}
	}

	public class YourPublish : IPublishCatalog
	{
		public List<Publish> GetPublish()
		{
			return new List<Publish>() { new Publish { Desctiprion = "your " } };
		}
	}

	public class BlockForeignPublish : IPublishCatalog
	{
		public List<Publish> GetPublish()
		{
			return new List<Publish>() { new Publish { Desctiprion = "block foreign " } };
		}
	}

	public class BlockYourPublish : IPublishCatalog
	{
		public List<Publish> GetPublish()
		{
			return new List<Publish>() { new Publish { Desctiprion = "block your" } };
		}
	}


}
