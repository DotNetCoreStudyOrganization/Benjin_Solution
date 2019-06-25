namespace Infrastructure.LogTools
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// Log4netHelper
    /// </summary>
    public static class Log4netHelper
    {
        private static readonly ILog Logger;

        static Log4netHelper()
        {
            var repository = LogManager.CreateRepository("NETCoreRepository");

            var resourceName = $"{typeof(Log4netHelper).Namespace}.Log4netConfig.log4net.config";

            var configStream = typeof(Log4netHelper).Assembly.GetManifestResourceStream(resourceName);

            XmlConfigurator.Configure(repository, configStream);

            Logger = LogManager.GetLogger(repository.Name, "NETLogger");
        }

        /// <summary>
        /// Test
        /// </summary>
        public static void Test()
        {
            Logger.Info($"测试{DateTime.Now.ToString()}");
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="exception">exception</param>
        public static void Debug(object message, Exception exception)
        {
            Task.Run(() =>
            {
                if (exception == null)
                {
                    Logger.Debug(message);
                }
                else
                {
                    Logger.Debug(message, exception);
                }
            });
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="exception">exception</param>
        public static void Info(object message, Exception exception = default)
        {
            Task.Run(() =>
            {
                if (exception == null)
                {
                    Logger.Info(message);
                }
                else
                {
                    Logger.Info(message, exception);
                }
            });
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="exception">exception</param>
        public static void Warn(object message, Exception exception = default)
        {
            Task.Run(() =>
            {
                if (exception == null)
                {
                    Logger.Warn(message);
                }
                else
                {
                    Logger.Warn(message, exception);
                }
            });
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="exception">exception</param>
        public static void Error(object message, Exception exception = default)
        {
            Task.Run(() =>
            {
                if (exception == null)
                {
                    Logger.Error(message);
                }
                else
                {
                    Logger.Error(message, exception);
                }
            });
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="exception">exception</param>
        public static void Fatal(object message, Exception exception = default)
        {
            Task.Run(() =>
            {
                if (exception == null)
                {
                    Logger.Fatal(message);
                }
                else
                {
                    Logger.Fatal(message, exception);
                }
            });
        }

        /// <summary>
        /// 解析异常消息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns></returns>
        public static StringBuilder ParseExceptionMessage(Exception exception)
        {
            var msg = new StringBuilder();

            if (exception == null)
            {
                return msg;
            }

            // 异常
            msg.AppendLine($"Exception：\r\n   {exception.Message.Trim("\r\n".ToCharArray())}\r\n");

            // 数据
            var datas = exception.Data;

            msg.AppendLine("Data[]：");

            foreach (var key in datas.Keys)
            {
                msg.AppendFormat($"   {key}：{datas[key]}\r\n");
            }

            msg.AppendLine();

            // 堆栈
            msg.AppendLine($"StackTraces：\r\n{exception.StackTrace}\r\n");

            return msg;
        }
    }
}
