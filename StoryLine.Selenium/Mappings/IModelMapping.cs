using System;
using OpenQA.Selenium;

namespace StoryLine.Selenium.Mappings
{
    public interface IModelMapping
    {
        Type GetModelType();
        void SetData(object model, ISearchContext container, IWebDriver browser);
        object GetData(ISearchContext container, IWebDriver browser);
    }
}