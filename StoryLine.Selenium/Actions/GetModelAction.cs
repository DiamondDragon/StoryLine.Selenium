using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Selenium.Mappings;

namespace StoryLine.Selenium.Actions
{
    public class GetModelAction : IAction
    {
        private readonly IModelMapping _modelMapping;

        public GetModelAction(IModelMapping modelMapping)
        {
            _modelMapping = modelMapping ?? throw new ArgumentNullException(nameof(modelMapping));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var browser = actor.Artifacts.Get<IWebDriver>();

            actor.Artifacts.Add(_modelMapping.GetData(browser, browser));
        }
    }
}