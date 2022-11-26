using Pattern.AbstractFactory.Class;
using Pattern.AbstractFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.AbstractFactory.Factory
{

	public class PublishCatalogAbstractFactory : IPublishCatalogAbstractFactory
	{
		public IPublishCatalogFactory CreateFactory(string manufacturer="")
		{
			return manufacturer switch
			{
				"" => new PublishCatalogFactory(),
				"block" => new BlockPublishCatalogFactory()
			};
		}
	}

	public class PublishCatalogFactory : IPublishCatalogFactory
	{
		public IPublishCatalog CreateCatalog(string type)
		{
			return type switch
			{
				"Your" => new YourPublish(),
				"Foreign" => new ForeignPublish(),
			};
		}
	}

	public class BlockPublishCatalogFactory : IPublishCatalogFactory
	{
		public IPublishCatalog CreateCatalog(string type)
		{
			return type switch
			{
				"Your" => new BlockYourPublish(),
				"Foreign" => new BlockForeignPublish(),
			};
		}
	}
}
