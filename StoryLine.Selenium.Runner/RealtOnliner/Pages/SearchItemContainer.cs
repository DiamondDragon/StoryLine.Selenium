using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.RealtOnliner.Pages
{
    public static class SearchItemContainer
    {
        public static readonly IElementSelector Title = new ByCss("a.news__link");
        public static readonly IElementSelector Description = new ByCss("div.news__description");
    }
}