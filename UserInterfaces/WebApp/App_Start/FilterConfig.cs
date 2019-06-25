namespace WebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Filters;
    using Infrastructure.Exceptions;
    using Infrastructure.LogTools;
    using Newtonsoft.Json;

    public class FilterConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // 添加授权过滤
            config.Filters.Add(new AuthorizeAttribute());

            // 添加请求异常过滤
            config.Filters.Add(new RequestExceptionFilterAttribute());
        }

        /// <summary>
        /// 异常过滤特性
        /// </summary>
        private class RequestExceptionFilterAttribute : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                var exception = context.Exception;

                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }

                // 异常过滤
                switch (exception)
                {
                    default:
                        break;
                    case AppException appException:
                    case TaskCanceledException taskCanceledException:
                    case OperationCanceledException operationCanceledException:
                        context.Response = context.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, exception.Message);

                        Log4netHelper.Info(exception.Message, exception);
                        return;
                }

                var parameters = new Dictionary<string, object>();

                // 添加路由参数
                if (context.ActionContext.RequestContext.RouteData.Values.ContainsKey("id"))
                {
                    parameters.Add("id", context.ActionContext.RequestContext.RouteData.Values["id"]);
                }

                var actionArguments = context.ActionContext.ActionArguments.Select(m => new KeyValuePair<string, string>(m.Key, JsonConvert.SerializeObject(m.Value)));

                // 添加请求参数
                var request = HttpContext.Current?.Request;

                var queryParams =
                    request?.QueryString.Count > 0 ? request?.QueryString : request?.Form;

                foreach (var key in queryParams?.AllKeys ?? new string[0])
                {
                    parameters.Add(key, queryParams[key]);
                }

                // 将参数加入到异常数据中
                foreach (var item in parameters)
                {
                    exception.Data.Add(item.Key, item.Value);
                }

                // 记录日志
                Log4netHelper.Error("Global", exception);
            }
        }
    }
}
