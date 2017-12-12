using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class SwitchToAction : IAction
    {
        private readonly IElementSelector _elementSelector;
        private readonly bool _useDefaultContent;

        public SwitchToAction(IElementSelector elementSelector, bool useDefaultContent)
        {
            _elementSelector = elementSelector;
            _useDefaultContent = useDefaultContent;
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            var driver = actor.Artifacts.Get<IWebDriver>();

            if (_elementSelector != null)
            {
                driver.SwitchTo().Frame(_elementSelector.Find(driver, driver));
                return;
            }

            if (_useDefaultContent)
                driver.SwitchTo().DefaultContent();
        }
    }
}