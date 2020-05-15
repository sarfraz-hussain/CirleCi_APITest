using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Report.Extent;
using System;

namespace APItestRestSharp
{
   /// <summary>
   /// Test Base Class, this class provides basic attributes for Test Setup and Test Closuer
   /// </summary>
    [TestFixture]
    public abstract class TestBase
    {
        protected ExtentReportsHelper extent;
        

        [OneTimeSetUp]
        public void SetUpReporter()
        {
            extent = new ExtentReportsHelper();
            
        }
        [SetUp]
        public void StartUpTest()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        //extent.AddTestFailureScreenshot(browser.getDriver.ScreenCaptureAsBase64String());
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                //browser.Close();
            } 
        }
        [OneTimeTearDown]
        public void CloseAll()
        {
            try
            {
                extent.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}