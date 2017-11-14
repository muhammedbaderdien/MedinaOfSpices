using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MedinaOfSpices.Helpers
{
	public class ServiceConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty("Services", IsDefaultCollection = false)]
		[ConfigurationCollection(typeof(ServiceCollection),
			AddItemName = "add",
			ClearItemsName = "clear",
			RemoveItemName = "remove")]
		public ServiceCollection Services
		{
			get
			{
				return (ServiceCollection)base["Services"];
			}
		}
	}
}