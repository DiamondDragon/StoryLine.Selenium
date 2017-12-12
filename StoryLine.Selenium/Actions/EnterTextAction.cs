using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class EnterTextAction : IAction
    {
        private readonly string _text;
        private readonly IElementSelector _selector;

        public EnterTextAction(IElementSelector selector, string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        public void Execute(IActor actor)
        {
            var driver = actor.Artifacts.Get<IWebDriver>();

            var element = _selector.Find(driver, driver);

            element.SendKeys(_text);
        }
    }
}