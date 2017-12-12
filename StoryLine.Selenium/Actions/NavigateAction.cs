using System;
using OpenQA.Selenium;
using StoryLine.Contracts;

namespace StoryLine.Selenium.Actions
{
    public class NavigateAction : IAction
    {
        private readonly string _url;

        public NavigateAction(string url)
        {
            _url = url ?? throw new ArgumentNullException(nameof(url));
        }

        public void Execute(IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));


            actor.Artifacts.Get<IWebDriver>().Navigate().GoToUrl(_url);
        }
    }
}