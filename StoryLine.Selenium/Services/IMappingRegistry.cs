using System;
using System.Reflection;
using StoryLine.Selenium.Mappings;

namespace StoryLine.Selenium.Services
{
    public interface IMappingRegistry
    {
        void RegisterMappingsFrom(Assembly assembly);
        IModelMapping GetByType(Type modelType);
    }
}