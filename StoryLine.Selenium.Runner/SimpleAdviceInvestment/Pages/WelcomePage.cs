using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.SimpleAdviceInvestment.Pages
{
    public static class WelcomePage
    {
        public static readonly IElementSelector LoginButton = new ByXPath("//a[@title='Login']");
        //public static readonly IElementSelector PageText = new ByXPath("//h1/div", "Page title");
    }
}