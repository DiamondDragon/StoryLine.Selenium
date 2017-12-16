using System;
using System.Linq.Expressions;

namespace StoryLine.Selenium.Services
{
    public interface IReflectionService
    {
        string GetPropertyName<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda);
        object GetPropertyValue(string propertyName, object model);
        void SetPropertyValue(string propertyName, object model, object value);
    }
}