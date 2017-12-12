using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Actions;
using StoryLine.Selenium.Runner.RealtOnliner.Models;
using StoryLine.Selenium.Runner.RealtOnliner.Pages;

namespace StoryLine.Selenium.Runner.RealtOnliner.Actions
{
    public class SearchAction : IAction
    {
        private readonly string _text;

        public SearchAction(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Execute(IActor actor)
        {
            Scenario.New()
                .Given(actor)
                    .HasPerformed<Navigate>(x => x.Url("https://realt.onliner.by"))
                    .HasPerformed<SetModel>(x => x.Data(new SearchModel { Text = _text }))
                .When()
                    .Performs<Submit>(x => x.Elemenent(EstatePage.SearchTextBox))
                .Run();
        }
    }
}