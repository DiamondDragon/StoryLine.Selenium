using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenQA.Selenium;
using StoryLine.Exceptions;
using StoryLine.Selenium.Bindings;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Mappings
{
    public abstract class ModelMapping<TModel> : IModelMapping
        where TModel : new()
    {
        private readonly Dictionary<string, PropertyConfig> _propertyMappings = new Dictionary<string, PropertyConfig>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, ColllectionConfig> _collectionMappings = new Dictionary<string, ColllectionConfig>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// This methods is expected to be implemented by each model mapping. It defines all property mappings of model.
        /// </summary>
        public abstract void Configure();

        protected void Property(Expression<Func<TModel, object>> property, IElementSelector selector, IValueGetter getter = null, IValueSetter setter = null)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            var propertyName = Config.ReflectionService.GetPropertyName(property);

            _propertyMappings.Add(
                propertyName,
                new PropertyConfig
                {
                    Setter = setter,
                    Getter = getter,
                    Selector = selector
                });
        }

        protected void Collection(Expression<Func<TModel, object>> property, IElementSelector selector, ICollectionValueGetter getter = null, ICollectionValueSetter setter = null)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            var propertyName = Config.ReflectionService.GetPropertyName(property); ;

            _collectionMappings.Add(
                propertyName,
                new ColllectionConfig
                {
                    Setter = setter,
                    Getter = getter,
                    Selector = selector
                });
        }

        public Type GetModelType()
        {
            return typeof(TModel);
        }

        public void SetData(object model, ISearchContext container, IWebDriver browser)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            SetPropertyValues(model, container, browser);
            SetCollectionValues(model, container, browser);
        }

        public object GetData(ISearchContext container, IWebDriver browser)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            var model = new TModel();

            GetPropertyValues(container, browser, model);
            GetCollectionValues(container, browser, model);

            return model;
        }

        private void SetCollectionValues(object model, ISearchContext container, IWebDriver browser)
        {
            foreach (var mapping in _collectionMappings.Where(x => x.Value.Setter != null))
            {
                var value = Config.ReflectionService.GetPropertyValue(mapping.Key, model);
                var matchingControls = mapping.Value.Selector.FindAll(container, browser);
                mapping.Value.Setter.Set(value, matchingControls, browser);
            }
        }

        private void GetCollectionValues(ISearchContext container, IWebDriver browser, TModel model)
        {
            foreach (var mapping in _collectionMappings.Where(x => x.Value.Getter != null))
            {
                var matchingControls = mapping.Value.Selector.FindAll(container, browser);
                var value = mapping.Value.Getter.Get(matchingControls, browser);
                Config.ReflectionService.SetPropertyValue(mapping.Key, model, value);
            }
        }

        private void SetPropertyValues(object model, ISearchContext container, IWebDriver browser)
        {
            foreach (var mapping in _propertyMappings.Where(x => x.Value.Setter != null))
            {
                var control = mapping.Value.Selector.Find(container, browser);
                if (control == null)
                    throw new ExpectationException("Can't find element: " + mapping.Value.Selector.GetElementDescription());

                var value = Config.ReflectionService.GetPropertyValue(mapping.Key, model);
                mapping.Value.Setter.Set(value, control, browser);
            }
        }

        private void GetPropertyValues(ISearchContext container, IWebDriver browser, TModel model)
        {
            foreach (var mapping in _propertyMappings.Where(x => x.Value.Getter != null))
            {
                var control = mapping.Value.Selector.Find(container, browser);
                if (control == null)
                    throw new ExpectationException("Can't find element: " + mapping.Value.Selector.GetElementDescription());

                var value = mapping.Value.Getter.Get(control, browser);
                Config.ReflectionService.SetPropertyValue(mapping.Key, model, value);
            }
        }

        private class PropertyConfig
        {
            public IElementSelector Selector { get; set; }
            public IValueGetter Getter { get; set; }
            public IValueSetter Setter { get; set; }
        }

        private class ColllectionConfig
        {
            public IElementSelector Selector { get; set; }
            public ICollectionValueGetter Getter { get; set; }
            public ICollectionValueSetter Setter { get; set; }
        }
    }
}