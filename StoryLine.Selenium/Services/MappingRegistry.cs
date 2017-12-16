using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StoryLine.Selenium.Mappings;

namespace StoryLine.Selenium.Services
{
    public class MappingRegistry : IMappingRegistry
    {
        private static readonly List<IModelMapping> Mappings = new List<IModelMapping>();

        public void RegisterMappingsFrom(Assembly assembly)
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

            foreach (var mapper in mappers)
            {
                mapper.Configure();
            }

            Mappings.AddRange(mappers);
        }

        public IModelMapping GetByType(Type modelType)
        {
            if (modelType == null)
                throw new ArgumentNullException(nameof(modelType));

            return
                Mappings.FirstOrDefault(x => x.GetModelType() == modelType)
                ?? Mappings.FirstOrDefault(x => x.GetModelType().IsAssignableFrom(modelType));
        }
    }
}
