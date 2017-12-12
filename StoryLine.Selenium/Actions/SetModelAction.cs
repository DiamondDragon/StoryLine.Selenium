using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Selenium.Mappings;

namespace StoryLine.Selenium.Actions
{
    public class SetModelAction : IAction
    {
        private readonly IModelMapping _modelMapping;
        private readonly object _model;

        public SetModelAction(object model, IModelMapping modelMapping)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _modelMapping = modelMapping ?? throw new ArgumentNullException(nameof(modelMapping));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var browser = actor.Artifacts.Get<IWebDriver>();

            _modelMapping.SetData(_model, browser, browser);
        }
    }
}