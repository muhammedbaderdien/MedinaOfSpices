using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MedinaOfSpices.Helpers
{
	public class ServiceCollection : ConfigurationElementCollection
	{
		public ServiceCollection()
		{
			//Console.WriteLine("ServiceCollection Constructor");
		}

		public ServiceConfig this[int index]
		{
			get { return (ServiceConfig)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}

		public void Add(ServiceConfig serviceConfig)
		{
			BaseAdd(serviceConfig);
		}

		public void Clear()
		{
			BaseClear();
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new ServiceConfig();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ServiceConfig)element).Key;
		}

		public void Remove(ServiceConfig serviceConfig)
		{
			BaseRemove(serviceConfig.Key);
		}

		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}

		public void Remove(string name)
		{
			BaseRemove(name);
		}
	}
}