using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Actions;
using StoryLine.Selenium.Runner.Google.Models;
using StoryLine.Selenium.Runner.Google.Pages;

namespace StoryLine.Selenium.Runner.Google.Actions
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
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            Scenario.New()
                .Given(actor)
                    .HasPerformed<Navigate>(x => x.Url("http://www.google.com/ncr"))
                    .HasPerformed<SetModel>(x => x.Data(new SearchModel { Text = _text }))
                .When()
                    .Performs<Submit>(x => x.Elemenent(SearchPage.QueryTextBox))
                .Run();
        }
    }
}
