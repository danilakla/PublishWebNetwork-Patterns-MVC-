using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.AbstractFactory.Interface
{

	public interface IPublishCatalogAbstractFactory
	{
		IPublishCatalogFactory CreateFactory(string manufacturer);
	}


	public interface IPublishCatalogFactory
	{
		IPublishCatalog CreateCatalog(string type);
	}

	public interface IPublishCatalog
	{
		List<Publish> GetPublish();
	}
}
