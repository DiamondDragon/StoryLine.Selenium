using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.RealtOnliner.Pages
{
    public static class SearchItemContainer
    {
        public static readonly IElementSelector Title = new CssElementSelector("a.news__link");
        public static readonly IElementSelector Description = new CssElementSelector("div.news__description");
    }
}