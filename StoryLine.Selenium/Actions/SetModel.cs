using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Mappings;

namespace StoryLine.Selenium.Actions
{
    public class SetModel : IActionBuilder
    {
        private object _model;
        private IModelMapping _mapping;

        public SetModel Data(object model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));

            return this;
        }

        public SetModel Mapping(IModelMapping mapping)
        {
            _mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));

            return this;
        }

        public IAction Build()
        {
            return new SetModelAction(_model, _mapping ?? MappingRegistry.GetByType(_model.GetType()));
        }
    }
}
