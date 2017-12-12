using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Actions
{
    public class EnterText : IActionBuilder
    {
        private string _text;
        private IElementSelector _selector;

        public EnterText Text(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));

            return this;
        }

        public EnterText Element(IElementSelector selector)
        {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));

            return this;
        }

        public IAction Build()
        {
            return new EnterTextAction(
                _selector,
                _text
            );
        }
    }
}