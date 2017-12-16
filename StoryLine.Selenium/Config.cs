using System;
using System.Reflection;
using StoryLine.Selenium.Services;

namespace StoryLine.Selenium
{
    public static class Config
    {
        internal static readonly IReflectionService ReflectionService = new ReflectionService();
        internal static readonly IMappingRegistry MappingRegistry = new MappingRegistry();

        public static void RegisterMappingsFromAssembly(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            MappingRegistry.RegisterMappingsFrom(assembly);
        }
    }
}
