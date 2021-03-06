﻿using Common;
using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace XmlConfiguration
{
    class Program
    {
        private const string ConfigFilenameDefault = "log4net.config";

        static void Main(string[] args)
        {
            var configFIlename = ConfigFilenameDefault;
            if (args.Length != 0)
            {
                // Check if a string is a valid Windows directory (folder) path
                // https://stackoverflow.com/questions/3137097/check-if-a-string-is-a-valid-windows-directory-folder-path
                configFIlename = Path.GetFullPath(args[0]);
            }

            // log4net
            // https://www.nuget.org/packages/log4net/
            // Install-Package -Id log4net -ProjectName 2_XmlConfiguration
            var repo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repo, new FileInfo(configFIlename));
            var logger = LogManager.GetLogger(typeof(Program));

            Task[] tasks = Util.LoggingDemoWithInterval(logger, 500);
            Task.WaitAll(tasks);
        }
    }
}
