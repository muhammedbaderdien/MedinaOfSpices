﻿using System.Web;
using System.Web.Mvc;

namespace MedinaOfSpices
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
			filters.Add(new ErrorHandler.AiHandleErrorAttribute());
		}
    }
}
