using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Bindings
{
    public class TextValueGetter : IValueGetter
    {
        public object Get(IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.Text;
        }
    }
}