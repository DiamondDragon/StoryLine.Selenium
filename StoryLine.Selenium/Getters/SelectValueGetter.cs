using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StoryLine.Selenium.Getters
{
    public class SelectValueGetter : IValueGetter
    {
        public object Get(IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            var dropdown = new SelectElement(element);

            var option = dropdown.SelectedOption;

            return option?.GetAttribute("value");
        }
    }
}

