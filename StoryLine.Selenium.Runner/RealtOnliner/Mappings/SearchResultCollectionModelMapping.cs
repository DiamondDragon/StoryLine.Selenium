using StoryLine.Selenium.Bindings;
using StoryLine.Selenium.Mappings;
using StoryLine.Selenium.Runner.RealtOnliner.Models;
using StoryLine.Selenium.Runner.RealtOnliner.Pages;

namespace StoryLine.Selenium.Runner.RealtOnliner.Mappings
{
    public class SearchResultCollectionModelMapping : ModelMapping<SearchResultCollectionModel>
    {
        public SearchResultCollectionModelMapping()
        {
            Collection(x => x.Items, SearchResultContainer.Items, new CollectionValueGetter<SearchResultModel>());
        }
    }
}
