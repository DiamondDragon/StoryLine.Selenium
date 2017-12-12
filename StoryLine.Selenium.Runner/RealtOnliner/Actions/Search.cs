using System;
using StoryLine.Contracts;

namespace StoryLine.Selenium.Runner.RealtOnliner.Actions
{
    public class Search : IActionBuilder
    {
        private string _text;

        public Search Text(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));

            _text = text;

            return this;
        }

        public IAction Build()
        {
            return new SearchAction(_text);
        }
    }
}
