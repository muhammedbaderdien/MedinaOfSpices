using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MedinaOfSpices.Helpers
{
	public static class ConfigurationManagerHelper
	{
		public static T GetSection<T>(string sectionName) where T : ConfigurationSection
		{
			var sectionObject = ConfigurationManager.GetSection(sectionName);

			if (sectionObject == null)
			{
				throw new ConfigurationErrorsException("ConfigurationErrorSectionNotFound");
			}

			var section = (sectionObject as T);

			if (section == null)
			{
				throw new ConfigurationErrorsException("ConfigurationErrorSectionTypeMismatch");
			}

			return section;
		}
	}
}