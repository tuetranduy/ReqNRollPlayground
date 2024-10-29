using NUnit.Framework;
using Reqnroll;
using ReqnRollPlayground.Drivers;
using System;

namespace ReqnRollPlayground.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private readonly BrowserFactory _browserFactory;

        public Hooks(BrowserFactory browserFactory)
        {
            _browserFactory = browserFactory;
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            Console.WriteLine("BaseTest Set up");

            _browserFactory.InitializeDriver("chrome");
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            TestContext.Progress.WriteLine("=========> Global OneTimeTearDown");
            BrowserFactory.CleanUp();
        }
    }
}
