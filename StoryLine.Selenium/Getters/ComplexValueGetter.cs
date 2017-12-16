using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Getters
{
    public class ComplexValueGetter<TModel> : IValueGetter
    {
        public object Get(IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            var mapping = Config.MappingRegistry.GetByType(typeof(TModel));
            if (mapping == null)
                throw new InvalidOperationException($"Model mapping for type {typeof(TModel)} was not found.");

            return mapping.GetData(element, driver);
        }
    }
}