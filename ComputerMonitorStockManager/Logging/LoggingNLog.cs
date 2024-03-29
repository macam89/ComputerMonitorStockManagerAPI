﻿using NLog;


namespace ComputerMonitorStockManager.Logging
{
    public class LoggingNLog : ILogging
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggingNLog()
        {
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

    }
}
