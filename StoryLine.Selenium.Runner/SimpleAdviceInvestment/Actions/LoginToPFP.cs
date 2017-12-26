using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Selenium.Actions;
using StoryLine.Selenium.Runner.GuidGenerator.Models;
using StoryLine.Selenium.Runner.GuidGenerator.Pages;
using StoryLine.Selenium.Runner.SimpleAdviceInvestment.Models;
using StoryLine.Selenium.Runner.SimpleAdviceInvestment.Pages;
using StoryLine.Utils.Expectations;

namespace StoryLine.Selenium.Runner.SimpleAdviceInvestment.Actions
{
    class LoginToPFP : IActionBuilder, IAction
    {
        private string _username = "ip-25981@mailinator.com";
        private string _password = "Welcome123";

        public LoginToPFP Username(string username)
        {
            _username = username ?? throw new ArgumentNullException(nameof(username));

            return this;
        }

        public LoginToPFP Password(string password)
        {
            _password = password ?? throw new ArgumentNullException(nameof(password));

            return this;
        }

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
                .HasPerformed<SetModel>(x => x.Data(new LoginPageModel { Username = _username, Password = _password }))
                .When()
                .Performs<Click>(x => x.Element(LoginPage.LoginButton))
                .Performs<GetModel>(x => x.Type<LoginPageModel>())
                .Then()
                //.Expects<Artifact<MainPageModel>>(x => x.Meets(p => p.Results.Length > 0))
                .Run();
        }
    }
}