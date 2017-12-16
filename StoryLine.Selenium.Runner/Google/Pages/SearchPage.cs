using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.Google.Pages
{
    public static class SearchPage
    {
        public static readonly IElementSelector QueryTextBox = new ByNameElementSelector("q");
    }
}