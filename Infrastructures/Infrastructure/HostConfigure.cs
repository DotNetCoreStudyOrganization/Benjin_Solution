namespace Infrastructure
{
    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;

    public static class HostConfigure
    {
        private static readonly object locker = new object();

        static HostConfigure()
            => ReloadConfigure();

        public static MssqlDbConfigureModel MssqlDbConfigure { get; private set; } = new MssqlDbConfigureModel(default, default);

        public static void ReloadConfigure()
        {
            var configFile = $"{AppContext.BaseDirectory}Appsettings/appsetting.{HostEnvironment.EnvironmentName}.json";

            if (!File.Exists(configFile))
            {
                return;
            }

            lock (locker)
            {
                var json = default(JToken);

                using (var sr = File.OpenText(configFile))
                {
                    json = JToken.Parse(sr.ReadToEnd());

                    sr.Close();
                }

                var dbConfigure = json?[nameof(MssqlDbConfigure)];

                var enableAutoMigration = dbConfigure[nameof(MssqlDbConfigure.EnableAutoMigration)].ToObject<bool?>();
                
                var connectionString = dbConfigure[nameof(MssqlDbConfigure.ConnectionString)].ToObject<string>();

                MssqlDbConfigure = new MssqlDbConfigureModel(enableAutoMigration, connectionString);
            }
        }

        public class MssqlDbConfigureModel
        {
            internal MssqlDbConfigureModel(bool? enableAutoMigration, string connectionString)
            {
                EnableAutoMigration = enableAutoMigration == true;

                ConnectionString = connectionString;
            }

            public bool EnableAutoMigration { get; private set; } = false;

            public string ConnectionString { get; private set; }
        }
    }
}
