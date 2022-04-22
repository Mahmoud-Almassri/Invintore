using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
namespace Invintore.Models
{
    public class Submit : ActionNameSelectorAttribute
    {
        public string Button { get; set; }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var Value = controllerContext.Controller.ValueProvider.GetValue(Button);
            if (Value!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}