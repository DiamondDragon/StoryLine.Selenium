using System.Reflection;
using OpenQA.Selenium;
using StoryLine.Selenium.Actions;
using StoryLine.Selenium.Runner.GuidGenerator.Actions;
using StoryLine.Selenium.Runner.RealtOnliner.Actions;
using StoryLine.Selenium.Runner.RealtOnliner.Models;
using StoryLine.Selenium.Runner.RealtOnliner.Pages;
using StoryLine.Selenium.Runner.SimpleAdviceInvestment.Actions;
using StoryLine.Utils.Expectations;

namespace StoryLine.Selenium.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.RegisterMappingsFromAssembly(Assembly.GetExecutingAssembly());

            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver(@".\bin\Debug\netcoreapp2.0\");
            //IWebDriver driver = new FirefoxDriver(@"d:\_Tests\DotNetCore20.SeleniumPoC\DotNetCore20.SeleniumPoC\bin\Debug\netcoreapp2.0\");

            var actor = new Actor();

            actor.Artifacts.Add(driver);

            //Scenario.New()
            //    .Given(actor)
            //        .HasPerformed<GoogleSearch>(x => x.Text("TestingBot"))
            //    .When()
            //        .Performs<GetModel>(x => x.Type<GoogleSearchModel>())
            //    .Then()
            //        .Expects<Artifact<GoogleSearchModel>>(x => x.Meets(p => p.Text == "TestingBot"))
            //    .Run();


            //Scenario.New()
            //    .Given(actor)
            //    .HasPerformed<Search>(x => x.Text("Парус"))
            //    .When()
            //    .Performs<SwitchTo>(x => x.Frame(EstatePage.ResultsFrame))
            //    .Performs<GetModel>(x => x.Type<SearchResultCollectionModel>())
            //    .Performs<SwitchTo>(x => x.DefaultContent())
            //    .Then()
            //    .Expects<Artifact<SearchResultCollectionModel>>(x => x.Meets(p => p.Items.Length > 0))
            //    .Run();

            //Scenario.New()
            //    .When(actor)
            //        .Performs<GenerateGuids>()
            //    .Run();


            Scenario.New()
                .When(actor)
                //.Performs<GoToLoginPage>()
                .Performs<LoginToPFP>()
                .Run();

            driver.Quit();
        }
    }
}
