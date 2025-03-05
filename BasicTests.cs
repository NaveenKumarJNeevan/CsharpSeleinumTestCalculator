using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class BasicTests : IDisposable
  {

    IWebDriver Driver;

    public BasicTests() {
      Driver = new ChromeDriver();
    }

    public void Dispose() {
      if(Driver != null) {
        Driver.Quit();
      }
    }

    [Fact]
    public void VerifyApplication()
    {
      Driver.Navigate().GoToUrl(StageHelper.getStage());
      Assert.Contains("Calculator", Driver.Title);
    }

    [Fact]
    public void VerifyApplicationIncorrectUrl()
    {
      Driver.Navigate().GoToUrl(Constants.IncorrectAppUrl);
      Assert.Contains("Page not found", Driver.Title);
    }

  }
