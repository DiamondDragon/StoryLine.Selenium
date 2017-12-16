using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Getters
{
    public class CollectionValueGetter<TModel> : ICollectionValueGetter
        where TModel : new()
    {
        public object Get(IEnumerable<IWebElement> elements, IWebDriver driver)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            var mapping = Config.MappingRegistry.GetByType(typeof(TModel));
            if (mapping == null)
                throw new InvalidOperationException($"Model mapping for type {typeof(TModel)} was not found.");

            return
                (from element in elements
                 select (TModel)mapping.GetData(element, driver))
                .ToArray();
        }
    }
}
