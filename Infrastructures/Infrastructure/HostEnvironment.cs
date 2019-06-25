namespace Infrastructure
{
    using System;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// 环境变量类
    /// </summary>
    public static class HostEnvironment
    {
        private static EnvironmentEnum environment = EnvironmentEnum.Development;

        /// <summary>
        /// 环境变量EnvironmentName
        /// </summary>
        public static string EnvironmentName { get; }

        static HostEnvironment()
        {
            var name = ConfigurationManager.AppSettings["ASPNET_ENVIRONMENT"];

            var enumValue = NameToEnum(name);

            if (enumValue.HasValue)
            {
                environment = enumValue.Value;
            }

            EnvironmentName = environment.ToString();
        }

        /// <summary>
        /// 环境类型
        /// </summary>
        public enum EnvironmentEnum
        {
            Development,
            Test,
            Staging,
            Production
        }

        /// <summary>
        /// 开发环境
        /// </summary>
        /// <returns></returns>
        public static bool IsDevelopment()
        {
            return environment == EnvironmentEnum.Development;
        }

        /// <summary>
        /// 测试环境
        /// </summary>
        /// <returns></returns>
        public static bool IsTest()
        {
            return environment == EnvironmentEnum.Test;
        }

        /// <summary>
        /// 预览环境
        /// </summary>
        /// <returns></returns>
        public static bool IsStaging()
        {
            return environment == EnvironmentEnum.Staging;
        }

        /// <summary>
        /// 生产环境
        /// </summary>
        /// <returns></returns>
        public static bool IsProduce()
        {
            return environment == EnvironmentEnum.Production;
        }

        private static EnvironmentEnum? NameToEnum(string name)
        {
            name = name?.Trim() ?? string.Empty;

            var enumValue = default(EnvironmentEnum?);

            if (Enum.GetNames(typeof(EnvironmentEnum)).Contains(name) == false)
            {
                return enumValue;
            }

            enumValue = (EnvironmentEnum)Enum.Parse(typeof(EnvironmentEnum), name);

            return enumValue;
        }
    }
}
