using System;
using System.IO;
using System.Text;
using log4net;
using Newtonsoft.Json;
using WMS.Core.Config;

namespace WMS.Core.Log
{
    public static class Log4NetHelper
    {
        static Log4NetHelper()
        {
            //初始化log4net配置
            var config = CachedConfigContext.Current.ConfigService.GetConfig("log4net");
            //重写log4net配置里的连接字符串
            //config = config.Replace("{connectionString}", CachedConfigContext.Current.DaoConfig.Log);
            //sds163239240.my3w.com;initial catalog=sds163239240_db;persist security info=True;user id=sds163239240;password=cdsbadminwm0736abc
            config = config.Replace("{connectionString}", @"Data Source=sds163239240.my3w.com;Initial Catalog=sds163239240_db;Persist Security Info=True;User ID=sds163239240;Password=cdsbadminwm0736abc");
            var ms = new MemoryStream(Encoding.Default.GetBytes(config));
            log4net.Config.XmlConfigurator.Configure(ms);
        }

        public static void Debug(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Debug(SerializeObject(message), e);
        }

        public static void Error(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Error(SerializeObject(message), e);
        }

        public static void Info(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Info(SerializeObject(message), e);
        }

        public static void Fatal(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Fatal(SerializeObject(message), e);
        }

        public static void Warn(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Warn(SerializeObject(message), e);
        }

        private static object SerializeObject(object message)
        {
            if (message is string || message == null)
                return message;
            else
                return JsonConvert.SerializeObject(message, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }

    public enum LoggerType
    {
        WebExceptionLog,
        ServiceExceptionLog
    }
}
