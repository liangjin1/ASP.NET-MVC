﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04FilterTest1.Filters
{
    public class CheckAuthorFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //获取请求的Controller名字
            string contrrollerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //获取请求的Action的名字
            string actionName = filterContext.ActionDescriptor.ActionName;

            if (contrrollerName == "Login" && (actionName == "Index" || actionName == "Login"))
            {
                //什么都不要做
            }
            else//检查登录状态
            {
                if (filterContext.HttpContext.Session["username"] == null)
                {
                    ContentResult contentResult = new ContentResult() { Content = "当前用户没有登录，请登录后访问！(这是使用IAuthorizationFilter进行检验的)" };
                    filterContext.Result = contentResult;
                }
                //实现：若是用户amdinq请求MainController，则...
                //if ((filterContext.HttpContext.Session["username"].ToString() == "admin")&&contrrollerName=="Main")
                //{

                //}
            }
        }
    }
}