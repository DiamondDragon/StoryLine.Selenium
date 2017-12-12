using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StoryLine.Selenium.Mappings
{
    public static class MappingRegistry
    {
        private static readonly List<IModelMapping> Mappings = new List<IModelMapping>();

        public static void RegisterMappingsFrom(Assembly assembly)
        {
            var mappingTypes =
                (from type in assembly.GetExportedTypes()
                    where typeof(IModelMapping).IsAssignableFrom(type) && !type.IsAbstract
                    select type)
                .ToArray();

            var mappers =
                (from type in mappingTypes
                    select (IModelMapping)Activator.CreateInstance(type))
                .ToArray();

            Mappings.AddRange(mappers);
        }

        public static IModelMapping GetByType(Type modelType)
        {
            if (modelType == null)
                throw new ArgumentNullException(nameof(modelType));

            return
                Mappings.FirstOrDefault(x => x.GetModelType() == modelType)
                ?? Mappings.FirstOrDefault(x => x.GetModelType().IsAssignableFrom(modelType));
        }
    }
}
