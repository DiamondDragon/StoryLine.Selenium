using StoryLine.Contracts;

namespace StoryLine.Selenium.Runner.Google.Actions
{
    public class Search : IActionBuilder
    {
        private string _text;

        public Search Text(string text)
        {
            _text = text;

            return this;
        }

        public IAction Build()
        {
            return new SearchAction(_text);
        }
    }
}