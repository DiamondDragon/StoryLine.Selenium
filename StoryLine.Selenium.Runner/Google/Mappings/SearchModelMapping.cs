using StoryLine.Selenium.Getters;
using StoryLine.Selenium.Mappings;
using StoryLine.Selenium.Runner.Google.Models;
using StoryLine.Selenium.Runner.Google.Pages;
using StoryLine.Selenium.Setters;

namespace StoryLine.Selenium.Runner.Google.Mappings
{
    public class GoogleSearchMapping : ModelMapping<SearchModel>
    {
        public override void Configure()
        {
            Property(x => x.Text, SearchPage.QueryTextBox, new TextValueGetter(), new TextValueSetter());
        }
    }
}
