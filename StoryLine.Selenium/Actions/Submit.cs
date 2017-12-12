using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class Submit : IActionBuilder
    {
        private IElementSelector _elementSelector;

        public Submit Elemenent(IElementSelector elementSelector)
        {
            _elementSelector = elementSelector ?? throw new ArgumentNullException(nameof(elementSelector));

            return this;
        }

        public IAction Build()
        {
            return new SubmitAction(_elementSelector);
        }
    }
}