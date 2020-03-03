using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TodoItems.Utilities
{
    public static class ConfigurationManager
    {
        private static readonly IConfiguration _Configuration;
        static ConfigurationManager()
        {
            IConfigurationBuilder builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                                   .SetBasePath(Directory.GetCurrentDirectory())
                                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            _Configuration = builder.Build();
        }

        public static string DbConnectionString => _Configuration["ConnectionStrings:DbContext"];

        public static string PasswordSecret => _Configuration["PasswordSecret"];

        public static string UserIdClaimKey => "UserId";

    }
}
