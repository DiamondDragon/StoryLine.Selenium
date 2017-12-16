﻿using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Getters
{
    public class InputValueGetter : IValueGetter
    {
        public object Get(IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            return element.GetAttribute("value");
        }
    }
}