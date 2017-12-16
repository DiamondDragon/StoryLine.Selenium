using StoryLine.Selenium.Bindings;
using StoryLine.Selenium.Mappings;
using StoryLine.Selenium.Runner.RealtOnliner.Models;
using StoryLine.Selenium.Runner.RealtOnliner.Pages;

namespace StoryLine.Selenium.Runner.RealtOnliner.Mappings
{
    public class SearchResultModelMapping : ModelMapping<SearchResultModel>
    {
        public override void Configure()
        {
            Property(x => x.Title, SearchItemContainer.Title, new TextValueGetter());
            Property(x => x.Description, SearchItemContainer.Description, new TextValueGetter());
        }
    }
}