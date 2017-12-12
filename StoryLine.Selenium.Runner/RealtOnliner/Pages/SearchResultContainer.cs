using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.RealtOnliner.Pages
{
    public static class SearchResultContainer
    {
        public static readonly IElementSelector Items = new CssElementSelector("div.result__wrapper");
    }
}
