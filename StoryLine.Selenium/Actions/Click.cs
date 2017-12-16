using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class Click : IActionBuilder
    {
        private IElementSelector _selector;

        public Click Element(IElementSelector selector)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));

            return this;
        }

        public IAction Build()
        {
            return new ClickAction(_selector);
        }
    }
}
