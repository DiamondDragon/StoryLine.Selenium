using StoryLine.Contracts;

namespace StoryLine.Selenium.Actions
{
    public class Navigate : IActionBuilder
    {
        private string _url;

        public Navigate Url(string url)
        {
            _url = url;

            return this;
        }

        public IAction Build()
        {
            return new NavigateAction(_url);
        }
    }
}
