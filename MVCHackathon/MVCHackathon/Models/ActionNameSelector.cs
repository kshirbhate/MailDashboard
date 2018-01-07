using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCHackathon.Models
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ButtonActionNameSelector : ActionNameSelectorAttribute
    {
        public string ButtonName { get; set; }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            string name = methodInfo.Name;
            var requestKey = controllerContext.HttpContext.Request[ButtonName];
            return (controllerContext.HttpContext.Request[ButtonName] != null);
        }
    }
}