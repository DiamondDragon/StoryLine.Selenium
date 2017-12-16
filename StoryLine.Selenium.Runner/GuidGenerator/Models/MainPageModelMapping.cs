using StoryLine.Selenium.Getters;
using StoryLine.Selenium.Mappings;
using StoryLine.Selenium.Runner.GuidGenerator.Pages;
using StoryLine.Selenium.Setters;

namespace StoryLine.Selenium.Runner.GuidGenerator.Models
{
    public class MainPageModelMapping : ModelMapping<MainPageModel>
    {
        public override void Configure()
        {
            Property(x => x.Count, MainPage.GuidCountTextBox, new TextValueGetter(), new TextValueSetter());
            Property(x => x.Results, MainPage.GuidCountTextBox, new TextValueGetter(), new TextValueSetter());
        }
    }
}