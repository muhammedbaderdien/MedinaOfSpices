using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MedinaOfSpices.Helpers
{
	public class ServiceConfig : ConfigurationElement
	{
		public ServiceConfig() { }

		public ServiceConfig(string key, string environment)
		{
			Key = key;
			Environment = environment;
		}

		[ConfigurationProperty("Key", DefaultValue = "None", IsRequired = true, IsKey = true)]
		public string Key
		{
			get { return (string)this["Key"]; }
			set { this["Key"] = value; }
		}

		[ConfigurationProperty("Environment", DefaultValue = "None", IsRequired = true, IsKey = false)]
		public string Environment
		{
			get { return (string)this["Environment"]; }
			set { this["Environment"] = value; }
		}
	}
}