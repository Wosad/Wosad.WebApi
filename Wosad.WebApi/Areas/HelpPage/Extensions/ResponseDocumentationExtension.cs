using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wosad.WebApi.Areas.HelpPage.Extensions
{
    public static class ResponseDocumentationExtension
    {
        public static MvcHtmlString ResponseDocumentation(this HtmlHelper helper, string text)
        {
            var response = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var alteredResponse = new List<string>();
            foreach (var item in response)
            {
                alteredResponse.Add(string.Format("<div>{0}</div>", item));
            }
            return MvcHtmlString.Create(String.Join(Environment.NewLine, alteredResponse));
        }
    }
}