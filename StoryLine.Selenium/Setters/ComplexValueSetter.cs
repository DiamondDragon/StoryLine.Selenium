using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Setters
{
    public class ComplexValueSetter<TModel> : IValueSetter
    {
        public void Set(object value, IWebElement element, IWebDriver driver)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            var mapping = Config.MappingRegistry.GetByType(typeof(TModel));
            if (mapping == null)
                throw new InvalidOperationException($"Model mapping for type {typeof(TModel)} was not found.");

            mapping.SetData(value, element, driver);
        }
    }
}
