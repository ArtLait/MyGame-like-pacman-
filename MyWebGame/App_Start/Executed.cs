﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace MyWebGam
{
    //public class Executed
    //{
    //    public static void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        string cultureName = null;
    //        HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
    //        if (cultureCookie != null)
    //            cultureName = cultureCookie.Value;
    //        else
    //            cultureName = "ru";
    //        List<string> cultures = new List<string>() { "ru", "en" };
    //        if (!cultures.Contains(cultureName))
    //        {
    //            cultureName = "ru";
    //        }
    //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
    //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
    //    }
    //}
}