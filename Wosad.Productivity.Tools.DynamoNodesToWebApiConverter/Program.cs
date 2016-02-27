#region Copyright
/*Copyright (C) 2015 Wosad Inc

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion

using Autodesk.DesignScript.Runtime;
using Dynamo.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Wosad.Productivity.Tools.DynamoNodesToWebApiConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = typeof(Analysis.Beam.Flexure);
            var assembly = entity.Assembly;

            var types = GetTypesWithIsDesignScriptCompatibleAttribute(assembly);

            foreach (var type in types)
            {
                Console.WriteLine(string.Format("{0}.{1}", type.Namespace, type.Name));
                var controllerBuilder = new StringBuilder();
               
                controllerBuilder.AppendLine("using System;");
                controllerBuilder.AppendLine("using System.Collections.Generic;");
                controllerBuilder.AppendLine("using System.Linq;");
                controllerBuilder.AppendLine("using System.Net;");
                controllerBuilder.AppendLine("using System.Net.Http;");
                controllerBuilder.AppendLine("using System.Web.Http;");

                // append special using
                // Wosad.dll with Nodes has the same namespaces as other libs have, for example Steel vs Wosad.Steel from Wosad.Steel library
                var namespaceParts = type.FullName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                var mainNamespace = namespaceParts[0];
                // substitute main namespace
                var substitutedNamespace = string.Format("Wosad{0}", mainNamespace);
                var substitutedUsing = string.Format("using {0} = {1};", substitutedNamespace, mainNamespace);
                
                // set filename with old namespace values
                var fullNamespaceJoined = String.Join("", namespaceParts).Replace("_","");
                var filename = string.Format("{0}Controller.cs", fullNamespaceJoined);

                controllerBuilder.AppendLine(substitutedUsing);
                controllerBuilder.AppendLine();
                controllerBuilder.AppendLine("namespace Wosad.WebApi.Controllers");
                controllerBuilder.AppendLine();
                controllerBuilder.AppendLine("{");

                controllerBuilder.AppendLine("/// <summary>");
                controllerBuilder.AppendLine(string.Format("///{0} Dynamo Web Api Wrapper", String.Join(".", namespaceParts).Replace("_", "")));
                controllerBuilder.AppendLine("/// </summary>");

                namespaceParts[0] = substitutedNamespace;
              
                controllerBuilder.AppendLine(string.Format("[RoutePrefix({0}api{0})]", "\""));
                controllerBuilder.AppendLine(string.Format("public class {0}Controller : ApiController", fullNamespaceJoined));
                controllerBuilder.AppendLine();
                controllerBuilder.AppendLine("{");

                // get members
                foreach (var member in type.GetMembers())
                {
                    var attribute = member.GetCustomAttributes(typeof(MultiReturnAttribute)).ToList();
                    if (attribute.Count > 0)
                    {
                        Console.WriteLine("{0,-3}[{1}].{2}:", string.Empty, member.MemberType, member.Name);

                        // get arguments
                        var methodInfo = member as MethodInfo;

                        var methodParameters = methodInfo.GetParameters();
                        foreach (var argument in methodParameters)
                        {
                            Console.WriteLine("{0,-5}{1}:{2}", string.Empty, argument.Name, argument.ParameterType.Name);
                        }

                        // get output
                        // always return Dictionary<string, object>

                        // build route
  
                        #region
                        // we decided to use querystring instead of url routing
                        // first of all because url routing is limited by number of url layers (divided by / sign)
                        // the second thing - engineering calculation is more functional (query based) than resourse based (which is set by url routing)
                        //var arguments = String.Empty;
                        //foreach (var argument in methodParameters)
                        //{
                        //    var argRouteValue = string.Empty;
                        //    var argType = argument.ParameterType.Name;
                        //    var argTypeName = argType.ToLower();
                        //    var argName = argument.Name;
                        //    if (argTypeName == "double")
                        //    {
                        //        argRouteValue = string.Format("/{0}/{1}{0}:{2}{3}", argName, "{", "double", "}");
                        //    }
                        //    else if (argTypeName.Contains("int"))
                        //    {
                        //        argRouteValue = string.Format("/{0}/{1}{0}:{2}{3}", argName, "{", "int", "}");
                        //    }
                        //    if (argTypeName == "string")
                        //    {
                        //        argRouteValue = string.Format("/{0}/{1}{0}{2}", argName, "{", "}");
                        //    }

                        //    arguments += argRouteValue;
                        //}
                        #endregion

                        var route = string.Format("[Route({3}{0}/{1}/{2}{3})]", type.Namespace.Replace(".","/"), type.Name, member.Name, "\"");

                        // extract xml comments
                        var annotations = GetXml(AssemblyPath(assembly), methodInfo);

                        Console.WriteLine(annotations);
                        Console.WriteLine(route);

                        controllerBuilder.AppendLine(annotations);
                        controllerBuilder.AppendLine("[HttpGet]");
                        controllerBuilder.AppendLine(route);

                        // generate method signature
                        var argumentsSignatures = new List<string>();
                        foreach (var argument in methodParameters)
                        {
                            var defValue = string.Empty;
                            if (argument.HasDefaultValue)
                            {
                                var argTypeName = argument.ParameterType.Name.ToLower();
                                if (argTypeName == "double" || argTypeName.Contains("int"))
                                {
                                    defValue = string.Format("= {0}",argument.DefaultValue.ToString());
                                }
                                if (argument.ParameterType.Name.ToLower() == "string")
                                {
                                    defValue=string.Format("= {1}{0}{1}",argument.DefaultValue,"\"");
                                }
                            }
                            var argumentPart = string.Format("{1} {0}{2}", argument.Name, argument.ParameterType.Name, defValue);
                            argumentsSignatures.Add(argumentPart);
                        }

                        var signatureBody = String.Join(", ", argumentsSignatures);
                        var signature = string.Format("public Dictionary<string, object> {1}({0})", signatureBody, member.Name);

                        Console.WriteLine(signature);
                        controllerBuilder.AppendLine(signature);

                        // body begins
                        var bodyBegin = "{";
                        Console.WriteLine(bodyBegin);
                        controllerBuilder.AppendLine(bodyBegin);

                        // generate method body (static method invokation)
                        var callList = String.Join(",", methodParameters.Select(x => x.Name));
                        var substitutedFullName = String.Join(".", namespaceParts);
                        var invokation = string.Format("    return {0}.{1}({2});", substitutedFullName, member.Name, callList);
                        Console.WriteLine(invokation);
                        controllerBuilder.AppendLine(invokation);
                        // body ends
                        var bodyEnd = "}";

                        Console.WriteLine(bodyEnd);
                        controllerBuilder.AppendLine(bodyEnd);
                        controllerBuilder.AppendLine();
                    }
                }

                // class
                controllerBuilder.AppendLine("}");
                controllerBuilder.AppendLine();

                // namespace
                controllerBuilder.AppendLine("}");
                controllerBuilder.AppendLine();

                // save file
                var directory = string.Format(@"{0}\Export",Path.GetDirectoryName(AssemblyPath(assembly)));
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                File.WriteAllText(string.Format(@"{0}\{1}",directory, filename), controllerBuilder.ToString());

            }

            Console.ReadKey();
        }

        static IEnumerable<Type> GetTypesWithIsDesignScriptCompatibleAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(IsDesignScriptCompatibleAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        static string AssemblyPath(Assembly assemby)
        {
            string codeBase = assemby.CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            return Uri.UnescapeDataString(uri.Path);
        }

        static string GetXml(string assemblyPath, MethodInfo mi)
        {
            string docuPath = assemblyPath.Substring(0, assemblyPath.LastIndexOf(".")) + ".XML";

            if (File.Exists(docuPath))
            {
                var document = new XmlDocument();
                document.Load(docuPath);

                string path = "M:" + mi.DeclaringType.FullName + "." + mi.Name;

                XmlNode xmlDocuOfMethod = document.SelectSingleNode(
                    "//member[starts-with(@name, '" + path + "')]");

                var cleanStr = Regex.Replace(xmlDocuOfMethod.InnerXml, @"\s+", " ");

                // replace
                cleanStr = cleanStr.Replace("<summary>", @"///<summary>");
                cleanStr = cleanStr.Replace("<param ", @"///<param ");
                cleanStr = cleanStr.Replace("<returns ", @"///<returns ");
                // optional
                cleanStr = cleanStr.Replace("<returns>", @"///<returns>");

                cleanStr = cleanStr.Replace("</summary>", "</summary>" + Environment.NewLine);
                cleanStr = cleanStr.Replace("</param>", "</param>" + Environment.NewLine);
                cleanStr = cleanStr.Replace("</returns>", "</returns>" + Environment.NewLine);

                List<string> description = cleanStr.Split(new string[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries).ToList();

                List<string> results = new List<string>();
                foreach (var descriptionItem in description)
                {
                    if (descriptionItem.StartsWith(@"///<returns"))
                    {
                        results.Add(descriptionItem);
                    }
                }

                List<string> alteredResults = new List<string>();
                if (results.Count>1)
                {
                    foreach (var result in results)
                    {
                        // get content
                        var content = result.Replace(@"returns", "").Replace(@"///<","").Replace(@"</","").Replace(@">","");
                        alteredResults.Add(content);
                    }

                    var sb = new StringBuilder();
                    sb.AppendLine(@"///<returns>");
                    foreach (var result in alteredResults)
                    {
                        sb.AppendLine(string.Format("///{0}",result));
                    }
                    sb.AppendLine(@"///</returns>");

                    // remove original results from description collection
                    List<string> distinc = new List<string>();
                    foreach (var descriptionItem in description)
                    {
                        bool isFound = false;
                        foreach (var result in results)
                        {
                            if (result == descriptionItem)
                            {
                                isFound = true;
                                break;
                            }
                        }

                        if (!isFound)
                        {
                            distinc.Add(descriptionItem);
                        }
                    }

                    //flatten distinc and add line from stringbuilder
                    var flattenDescription = String.Join(Environment.NewLine, distinc);
                    flattenDescription += (Environment.NewLine + sb.ToString());

                    return flattenDescription;
                }

                return cleanStr;
            }

            return string.Empty;
        }
    }
}
