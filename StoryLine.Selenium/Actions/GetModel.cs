using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Mappings;

namespace StoryLine.Selenium.Actions
{
    public class GetModel : IActionBuilder
    {
        private Type _type;
        private IModelMapping _mapping;

        public GetModel Type<T>()
        {
            _type = typeof(T);

            return this;
        }

        public GetModel Mapping(IModelMapping mapping)
        {
            _mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));

            return this;
        }

        public IAction Build()
        {
            return new GetModelAction(_mapping ?? Config.MappingRegistry.GetByType(_type));
        }
    }
}