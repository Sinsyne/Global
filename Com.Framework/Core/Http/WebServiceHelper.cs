/*************************************************
Author: Leo Shao      
Generated Date: 2015-04-08
Project: 公用框架
Version: 1.0   
.Net Version: 3.5
Description:    // 模块功能描述（如功能、主要算法、内部各部分之间的关系、该文件与其它文件关系等）
Others:         // 其它内容的说明
History:        // 修改历史记录列表，每条修改记录应包括修改日期、修改者及修改内容简述
*************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Web.Services.Description;
using System.IO;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace Com.Framework.Core.Http
{
    public class WebServiceHelper
    {

        public WebServiceHelper()
        {

            //

            //TODO: 在此处添加构造函数逻辑

            //

        }

        #region InvokeWebService

        //动态调用web服务

        public static object InvokeWebService(string url, string methodname, object[] args)
        {

            return WebServiceHelper.InvokeWebService(url, null, methodname, args);

        }



        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {

            string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";

            if ((classname == null) || (classname == ""))
            {

                classname = WebServiceHelper.GetWsClassName(url);

            }



            try
            {

                //获取WSDL

                WebClient wc = new WebClient();

                Stream stream = wc.OpenRead(url + "?WSDL");

                ServiceDescription sd = ServiceDescription.Read(stream);

                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();

                sdi.AddServiceDescription(sd, "", "");

                CodeNamespace cn = new CodeNamespace(@namespace);



                //生成客户端代理类代码

                CodeCompileUnit ccu = new CodeCompileUnit();

                ccu.Namespaces.Add(cn);

                sdi.Import(cn, ccu);

                CSharpCodeProvider csc = new CSharpCodeProvider();

                ICodeCompiler icc = csc.CreateCompiler();



                //设定编译参数

                CompilerParameters cplist = new CompilerParameters();

                cplist.GenerateExecutable = false;

                cplist.GenerateInMemory = true;

                cplist.ReferencedAssemblies.Add("System.dll");

                cplist.ReferencedAssemblies.Add("System.XML.dll");

                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");

                cplist.ReferencedAssemblies.Add("System.Data.dll");



                //编译代理类

                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);

                if (true == cr.Errors.HasErrors)
                {

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {

                        sb.Append(ce.ToString());

                        sb.Append(System.Environment.NewLine);

                    }

                    throw new Exception(sb.ToString());

                }



                //生成代理实例，并调用方法

                System.Reflection.Assembly assembly = cr.CompiledAssembly;

                Type t = assembly.GetType(@namespace + "." + classname, true, true);

                object obj = Activator.CreateInstance(t);

                System.Reflection.MethodInfo mi = t.GetMethod(methodname);



                return mi.Invoke(obj, args);

            }

            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));

            }

        }



        private static string GetWsClassName(string wsUrl)
        {

            string[] parts = wsUrl.Split('/');

            string[] pps = parts[parts.Length - 1].Split('.');



            return pps[0];

        }

        #endregion

    }
}