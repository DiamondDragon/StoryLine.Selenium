using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Exceptions;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class ClickAction : IAction
    {
        private readonly IElementSelector _selector;

        public ClickAction(IElementSelector selector)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var driver = actor.Artifacts.Get<IWebDriver>();

            var element = _selector.Find(driver, driver);
            if (element == null)
                throw new ExpectationException("Can't find element: " + _selector.GetElementDescription());

            element.Click();
        }
    }
}