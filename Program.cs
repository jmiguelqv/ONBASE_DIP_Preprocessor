using Microsoft.Extensions.Logging;

using ONBASE_DIP_Preprocessor.Services;
using System;
using NLog;

namespace ONBASE_DIP_Preprocessor
{
     class Program
    {
        static  int  Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logConsole = new NLog.Targets.ConsoleTarget();
            var logDebug = new NLog.Targets.DebugTarget();
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logConsole);
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logDebug);
            NLog.LogManager.Configuration = config;
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                Processor processor = new Processor(args);
                processor.process();
                
                return 1;
            }
            catch(Exception e)
            {
                logger.Fatal(e.Message);
                logger.Trace(e.StackTrace);
                Console.ReadKey();
                return 0;
            }
            
        }
    }
}
