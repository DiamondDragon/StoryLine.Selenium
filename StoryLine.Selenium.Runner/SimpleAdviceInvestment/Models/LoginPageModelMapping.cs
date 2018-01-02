using StoryLine.Selenium.Getters;
using StoryLine.Selenium.Mappings;
using StoryLine.Selenium.Runner.SimpleAdviceInvestment.Pages;
using StoryLine.Selenium.Setters;

namespace StoryLine.Selenium.Runner.SimpleAdviceInvestment.Models
{
    public class LoginPageModelMapping : ModelMapping<LoginPageModel>
    {
        public override void Configure()
        {
            Property(x => x.Username, LoginPage.UsernameTextBox, new TextValueGetter(), new TextValueSetter());
            Property(x => x.Password, LoginPage.PasswordTextBox, new TextValueGetter(), new TextValueSetter());
        }
    }
}