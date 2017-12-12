using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using StoryLine.Selenium.Mappings;

namespace StoryLine.Selenium.Bindings
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

            var mapping = MappingRegistry.GetByType(typeof(TModel));

            return 
                (from element in elements
                 select (TModel)mapping.GetData(element, driver))
                .ToArray();
        }
    }
}
