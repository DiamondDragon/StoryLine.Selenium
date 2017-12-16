using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.GuidGenerator.Pages
{
    public static class MainPage
    {
        public static readonly IElementSelector ResultsTextBox = new ById("txtResults", "Results text box");
        public static readonly IElementSelector GenerateButton = new ById("btnGenerate", "Generate button");
        public static readonly IElementSelector GuidCountTextBox = new ById("txtCount", "Guid count text box");
    }
}
