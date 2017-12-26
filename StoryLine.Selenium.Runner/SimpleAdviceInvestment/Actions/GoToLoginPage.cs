using StoryLine.Contracts;
using StoryLine.Selenium.Actions;
using StoryLine.Selenium.Runner.SimpleAdviceInvestment.Pages;
using StoryLine.Utils.Expectations;
using System;

namespace StoryLine.Selenium.Runner.SimpleAdviceInvestment.Actions
{
    class GoToLoginPage : IActionBuilder, IAction
    {
        public IAction Build()
        {
            return this;
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            Scenario.New()
                .Given(actor)
                .HasPerformed<Navigate>(x => x.Url("https://tst-04-pfp.test.intelliflo.com/"))
                .When()
                .Performs<Click>(x => x.Element(WelcomePage.LoginButton))
                .Then()
                //.Expects<Artifact<MainPageModel>>(x => x.Meets(p => p.Results.Length > 0))    // assert that the page title is "Login"
                .Run();
        }
    }
}