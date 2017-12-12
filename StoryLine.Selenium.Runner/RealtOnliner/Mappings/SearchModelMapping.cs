using StoryLine.Selenium.Bindings;
using StoryLine.Selenium.Mappings;
using StoryLine.Selenium.Runner.RealtOnliner.Models;
using StoryLine.Selenium.Runner.RealtOnliner.Pages;

namespace StoryLine.Selenium.Runner.RealtOnliner.Mappings
{
    public class SearchModelMapping : ModelMapping<SearchModel>
    {
        public SearchModelMapping()
        {
            Property(x => x.Text, EstatePage.SearchTextBox, new InputValueGetter(), new TextValueSetter());
        }
    }
}
