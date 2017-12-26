using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.SimpleAdviceInvestment.Pages
{
    public static class LoginPage
    {
        public static readonly IElementSelector UsernameTextBox = new ById("username");
        public static readonly IElementSelector PasswordTextBox = new ById("password");
        public static readonly IElementSelector LoginButton = new ByClassName("btn btn-primary");
    }
}