using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Utility;
using MS.ECP.Web.Areas.Admin.Models;
using MS.ECP.Web.Models;
using MS.ECP.Web.WebHelp;

namespace MS.ECP.Web.Filters
{
    public class StaticFileWriteFilterAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Filter =
                new StaticFileWriteResponseFilterWrapper(filterContext.HttpContext.Response.Filter, filterContext);
        }

        private class StaticFileWriteResponseFilterWrapper : System.IO.Stream
        {
            private readonly System.IO.Stream _inner;
            private readonly ControllerContext _context;

            public StaticFileWriteResponseFilterWrapper(System.IO.Stream s, ControllerContext context)
            {
                this._inner = s;
                this._context = context;
            }

            public override bool CanRead
            {
                get { return _inner.CanRead; }
            }

            public override bool CanSeek
            {
                get { return _inner.CanSeek; }
            }

            public override bool CanWrite
            {
                get { return _inner.CanWrite; }
            }

            public override void Flush()
            {
                _inner.Flush();
            }

            public override long Length
            {
                get { return _inner.Length; }
            }

            public override long Position
            {
                get
                {
                    return _inner.Position;
                }
                set
                {
                    _inner.Position = value;
                }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _inner.Read(buffer, offset, count);
            }

            public override long Seek(long offset, System.IO.SeekOrigin origin)
            {
                return _inner.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _inner.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                _inner.Write(buffer, offset, count);
                try
                {
                    var p = _context.HttpContext.Server.MapPath(HttpContext.Current.Request.Path);
                    if (Path.HasExtension(p))
                    {
                        var dir = Path.GetDirectoryName(p);
                        if (dir != null && !Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        if (File.Exists(p))
                        {
                            File.Delete(p);
                        }
                        File.AppendAllText(p, System.Text.Encoding.UTF8.GetString(buffer));
                    }
                }
                catch
                {

                }
            }
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class LoginAuthenticityAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.Controller.ControllerContext.HttpContext.Session != null)
            {
                var seadmin = filterContext.Controller.ControllerContext.HttpContext.Session["admin"];
                if (null != seadmin) return;
                var request = filterContext.HttpContext.Request;

                if (request.HttpMethod.ToUpper() == "POST" &&
                    request.Path.EndsWith("AddorUpdate", true, CultureInfo.CurrentCulture))
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new JqueryResult()
                        {
                            Result = false,
                            Text = @"
                                    <html>
                                    <head>
                                        <title>Error</title>
                                    </head>
                                    <body>
                                        <div>
                                            <script type=""text/javascript"">
                                                top.location.href = ""/Admin/Account/Logon"";
                                            </script>
                                        </div>
                                    </body>
                                    </html>
                                    "
                        }
                    };
                }
                else
                {
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new System.Web.Routing.RouteValueDictionary(new { Controller = "Shared", action = "Error" }));
                }
            }
        }
    }


}