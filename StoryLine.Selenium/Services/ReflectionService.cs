using System;
using System.Linq.Expressions;
using System.Reflection;

namespace StoryLine.Selenium.Services
{
    public class ReflectionService : IReflectionService
    {
        public string GetPropertyName<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof(TSource);

            if (!(propertyLambda.Body is MemberExpression member))
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo.Name;
        }

        public object GetPropertyValue(string propertyName, object model)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance).GetValue(model);
        }

        public void SetPropertyValue(string propertyName, object model, object value)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var property = model.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            
            property.SetValue(model, Convert.ChangeType(value, property.PropertyType));
        }
    }
}
