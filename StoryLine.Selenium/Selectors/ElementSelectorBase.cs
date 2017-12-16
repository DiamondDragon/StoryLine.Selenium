using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Selectors
{
    public abstract class ElementSelectorBase : IElementSelector
    {
        protected abstract string SelectorType { get; }
        protected string Pattern { get; }
        protected string Description { get; }

        protected ElementSelectorBase(string pattern, string description)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException("Value cannot be null or empty.", nameof(pattern));

            Pattern = pattern;
            Description = description ?? pattern;
        }

        public virtual string GetElementDescription()
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(Description))
                builder.Append(Description);

            if (builder.Length > 0)
                builder.Append(" (");

            builder.Append(SelectorType);
            builder.Append(": ");
            builder.Append(Pattern);

            if (!string.IsNullOrEmpty(Description))
                builder.Append(')');

            return builder.ToString();
        }

        public abstract IWebElement Find(ISearchContext element, IWebDriver driver);

        public abstract IEnumerable<IWebElement> FindAll(ISearchContext element, IWebDriver driver);
    }
}