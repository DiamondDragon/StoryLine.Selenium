using System;
using OpenQA.Selenium;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Helpers
{
    public static class WebDriverExtensions
    {
        public static IDisposable UseFrame(this IWebDriver driver, IElementSelector selector)
        {
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            driver.SwitchTo().Frame(selector.Find(driver, driver));

            return new DisposableAction(() => driver.SwitchTo().DefaultContent());
        }
    }
}