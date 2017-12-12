using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.RealtOnliner.Pages
{
    public static class EstatePage
    {
        public static readonly IElementSelector ResultsFrame = new CssElementSelector("iframe.modal-iframe");
        public static readonly IElementSelector SearchTextBox = new CssElementSelector("input.fast-search__input");
    }
}