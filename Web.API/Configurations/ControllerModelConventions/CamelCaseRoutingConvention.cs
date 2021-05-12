using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.API.Configurations.ControllerModelConventions
{
    // НЕ РАБОТАЕТ
    [Obsolete]
    public class CamelCaseRoutingConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            //var hasRouteAttributes = controller.Selectors.Any(selector =>
            //                                   selector.AttributeRouteModel != null);
            //if (hasRouteAttributes)
            //{
            //    // This controller manually defined some routes, so treat this 
            //    // as an override and not apply the convention here.
            //    return;
            //}
            if (Char.IsUpper(controller.ControllerName[0]))
            {
                foreach (var controllerAction in controller.Actions)
                {
                    foreach (var selector in controllerAction.Selectors)
                    {
                        var template = new StringBuilder();

                        if (controllerAction.Controller.ControllerName != "Home")
                        {
                            template.Append(PascalToKebabCase(controller.ControllerName));
                        }

                        if (string.IsNullOrEmpty(controllerAction.ActionName))
                        {
                            template.Append("/" + PascalToKebabCase(controllerAction.ActionName));
                        }

                        selector.AttributeRouteModel = new AttributeRouteModel()
                        {
                            Template = template.ToString()
                        };
                    }
                }
            }
        }

        private static string PascalToKebabCase(string value)
        {
            var result = Regex.Replace(value, @"([A-Z])([A-Z]+|[a-z0-9_]+)($|[A-Z]\w*)",
            m => 
            m.Groups[1].Value.ToLower() 
            + m.Groups[2].Value.ToLower() 
            + m.Groups[3].Value);
            return result;
        }
    }
}
