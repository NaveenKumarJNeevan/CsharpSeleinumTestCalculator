using OpenQA.Selenium;
using Xunit.Abstractions;

public class CommonHelper {
    
    IWebDriver webDriver;
    private readonly ITestOutputHelper output;

    public CommonHelper(IWebDriver webDriver, ITestOutputHelper output) {
        this.webDriver = webDriver;
        this.output = output;
    }

    public void parseAndClickNumbers(float number) {
        List<char> parsedNum = Transformation.ParsedNumber(number);
        Dictionary<string,string> xpathsMap = Transformation.CreateMap();
        PageHelper pageHelper = new(webDriver);
        foreach (var item in parsedNum) {
            pageHelper.findAndClickElement(xpathsMap[item.ToString()]);
        }
    }

    public void parseAndClickEachNumbersWithOperation(float[] number, string operation) {
        foreach (var nums in number) {
            List<char> parsedNum = Transformation.ParsedNumber(nums);
            Dictionary<string,string> xpathsMap = Transformation.CreateMap();
            PageHelper pageHelper = new(webDriver);
            foreach (var item in parsedNum) {
                pageHelper.findAndClickElement(xpathsMap[item.ToString()]);
            }
            pageHelper.findAndClickElement(xpathsMap[operation]);
        }
    }

    public void parseAndClickEachNumbersWithOperations(float[] number, string[] operation) {
        int counter = 0;
        foreach (var nums in number) {
            List<char> parsedNum = Transformation.ParsedNumber(nums);
            Dictionary<string,string> xpathsMap = Transformation.CreateMap();
            PageHelper pageHelper = new(webDriver);
            foreach (var item in parsedNum) {
                pageHelper.findAndClickElement(xpathsMap[item.ToString()]);
            }
            if(counter<number.Length-1)
                pageHelper.findAndClickElement(xpathsMap[operation[counter++]]);
        }
    }
}