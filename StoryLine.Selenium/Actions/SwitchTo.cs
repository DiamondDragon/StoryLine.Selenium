using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class SwitchTo : IActionBuilder
    {
        private IElementSelector _elementSelector;
        private bool _useDefaultContent;

        public SwitchTo Frame(IElementSelector elementSelector)
        {
            _elementSelector = elementSelector ?? throw new ArgumentNullException(nameof(elementSelector));

            return this;
        }

        public SwitchTo DefaultContent()
        {
            _useDefaultContent = true;

            return this;
        }

        public IAction Build()
        {
            return new SwitchToAction(_elementSelector, _useDefaultContent);
        }
    }
}
