using System;
using OpenQA.Selenium;
using StoryLine.Contracts;
using StoryLine.Selenium.Actions;
using StoryLine.Selenium.Runner.GuidGenerator.Models;
using StoryLine.Selenium.Runner.GuidGenerator.Pages;
using StoryLine.Utils.Expectations;

namespace StoryLine.Selenium.Runner.GuidGenerator.Actions
{
    public class GenerateGuids : IActionBuilder, IAction
    {
        private int _guidCount = 3;

        public GenerateGuids Count(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            _guidCount = count;

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
                    .HasPerformed<Navigate>(x => x.Url("https://www.guidgenerator.com/"))
                    .HasPerformed<SetModel>(x => x.Data(new MainPageModel { Count = _guidCount }))
                .When()
                    .Performs<Click>(x => x.Element(MainPage.GenerateButton))
                    .Performs<GetModel>(x => x.Type<MainPageModel>())
                .Then()
                    .Expects<Artifact<MainPageModel>>(x => x.Meets(p => p.Results.Length > 0))
                .Run();
        }
    }
}
