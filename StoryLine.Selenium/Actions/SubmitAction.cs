using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class SubmitAction : IAction
    {
        private readonly IElementSelector _elementSelector;

        public SubmitAction(IElementSelector elementSelector)
        {
            _elementSelector = elementSelector ?? throw new ArgumentNullException(nameof(elementSelector));
        }


        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var context = actor.Artifacts.Get<IWebDriver>();

            _elementSelector.Find(context, context).Submit();
        }
    }
}