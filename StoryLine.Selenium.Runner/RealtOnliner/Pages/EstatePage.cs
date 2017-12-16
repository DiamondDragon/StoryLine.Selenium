using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.RealtOnliner.Pages
{
    public static class EstatePage
    {
        public static readonly IElementSelector ResultsFrame = new ByCss("iframe.modal-iframe");
        public static readonly IElementSelector SearchTextBox = new ByCss("input.fast-search__input");
    }
}