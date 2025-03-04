using OpenQA.Selenium;

public class PageHelper {

    IWebDriver WebDriver;
    public PageHelper(IWebDriver webDriver) {

        this.WebDriver = webDriver;

    }

    public void findAndClickElement(string xPath) {
        WebElement element = (WebElement) WebDriver.FindElement(By.XPath(xPath));
        element.Click();
    }

    public string findElementAndGetText(string xPath) {
        WebElement element = (WebElement) WebDriver.FindElement(By.XPath(xPath));
        return element.Text;
    }

}