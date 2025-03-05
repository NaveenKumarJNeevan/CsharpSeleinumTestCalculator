using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

public class ArithmeticOperationCalciTests : IDisposable
  { 

    IWebDriver Driver;

    private readonly ITestOutputHelper output;

    public ArithmeticOperationCalciTests(ITestOutputHelper output) {
      Driver = new ChromeDriver();
      Driver.Navigate().GoToUrl(StageHelper.getStage());
      this.output = output;
     }

    public void Dispose() {
      if(Driver != null) {
        Driver.Quit();
      }
    }

    [Theory]
    [InlineData(1, 2, "3")]
    [InlineData(-4, -6, "-10")]
    [InlineData(-2, 2, "0")]
    [InlineData(-2.2, 2, "-0.2")]
    [InlineData(0, 0, "0")]
    public void VerifyAdditionOfTwoNumbers(float number1, float number2, string result)
    {
      CommonHelper commonHelper = new(Driver,output);
      PageHelper pageHelper = new(Driver);
      Dictionary<string,string> xpathsMap = Transformation.CreateMap();
      commonHelper.parseAndClickNumbers(number1);
      pageHelper.findAndClickElement(xpathsMap["+"]);
      commonHelper.parseAndClickNumbers(number2);
      pageHelper.findAndClickElement(xpathsMap["="]);
      Assert.Equal(result, pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
      pageHelper.findAndClickElement(ConstantXpaths.clearXpath);
      Assert.Equal("0", pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
    }

    [Theory]
    [InlineData(1, 2, "-1")]
    [InlineData(2, 1, "1")]
    [InlineData(-4, -6, "-10")] //As per current case second number cannot have the negative sign
    [InlineData(-2, 2, "-4")]
    [InlineData(-2.2, 2, "-4.2")]
    [InlineData(0, 0, "-0")] //As per current case second number cannot have the negative sign
    public void VerifySubtractionOfTwoNumbers(float number1, float number2, string result)
    {
      CommonHelper commonHelper = new(Driver,output);
      PageHelper pageHelper = new(Driver);
      Dictionary<string,string> xpathsMap = Transformation.CreateMap();
      commonHelper.parseAndClickNumbers(number1);
      pageHelper.findAndClickElement(xpathsMap["-"]);
      commonHelper.parseAndClickNumbers(number2);
      pageHelper.findAndClickElement(xpathsMap["="]);
      Assert.Equal(result, pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
      pageHelper.findAndClickElement(ConstantXpaths.clearXpath);
      Assert.Equal("0", pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
    }

    [Theory]
    [InlineData(1, 2, "2")]
    [InlineData(2, 1, "2")]
    [InlineData(-4, -6, "-10")] //As per current case Multiply with second number as negative ignores the multiply and performs operation as subtraction instead
    [InlineData(-2, 2, "-4")]
    [InlineData(-2.2, 2, "-4.4")]
    [InlineData(0, 0, "0")]
    public void VerifyMultiplicationOfTwoNumbers(float number1, float number2, string result)
    {
      CommonHelper commonHelper = new(Driver,output);
      PageHelper pageHelper = new(Driver);
      Dictionary<string,string> xpathsMap = Transformation.CreateMap();
      commonHelper.parseAndClickNumbers(number1);
      pageHelper.findAndClickElement(xpathsMap["*"]);
      commonHelper.parseAndClickNumbers(number2);
      pageHelper.findAndClickElement(xpathsMap["="]);
      Assert.Equal(result.ToString(), pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
      pageHelper.findAndClickElement(ConstantXpaths.clearXpath);
      Assert.Equal("0", pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
    }

    [Theory]
    [InlineData(1, 2, "0.5")]
    [InlineData(2, 1, "2")]
    [InlineData(-4, -6, "-10")] //As per current case Divide with second number as negative ignores the divison and performs operation as subtraction instead
    [InlineData(-2, 2, "-1")]
    [InlineData(-2.2, 2, "-1.1")]
    [InlineData(0, 2, "0")]
    [InlineData(0, 0, "Error")]
    public void VerifyDivisonOfTwoNumbers(float number1, float number2, string result)
    {
      CommonHelper commonHelper = new(Driver,output);
      PageHelper pageHelper = new(Driver);
      Dictionary<string,string> xpathsMap = Transformation.CreateMap();
      commonHelper.parseAndClickNumbers(number1);
      pageHelper.findAndClickElement(xpathsMap["/"]);
      commonHelper.parseAndClickNumbers(number2);
      pageHelper.findAndClickElement(xpathsMap["="]);
      Assert.Equal(result, pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
      pageHelper.findAndClickElement(ConstantXpaths.clearXpath);
      Assert.Equal("0", pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
    }

    [Theory]
    [InlineData(new float[] {1,2,3,4,5,6},"21","+")]
    [InlineData(new float[] {1,-2,43,-4,50,61},"149","+")]
    [InlineData(new float[] {1,2,3,4,5,6},"-19","-")]
    [InlineData(new float[] {1,-2,43,-4,50,61},"-159","-")]
    [InlineData(new float[] {1,2,3,4,5,6},"720","*")]
    [InlineData(new float[] {1,-2,43,-4,50,61},"-143350","*")]
    [InlineData(new float[] {1,-2,43,-4,50,61,0},"0","*")]
    [InlineData(new float[] {1,2,3,4,5,6},"0.00138888889","/")]
    [InlineData(new float[] {1,-2,43,-4,50,61},"-0.00131910027","/")]
    [InlineData(new float[] {1,-2,43,-4,50,61,0},"Error","/")]

    public void VerifySpecifiedOperationForGivenNumbers(float[] numbers, string result, string operation) {
      CommonHelper commonHelper = new(Driver,output);
      PageHelper pageHelper = new(Driver);
      Dictionary<string,string> xpathsMap = Transformation.CreateMap();
      commonHelper.parseAndClickEachNumbersWithOperation(numbers,operation);
      pageHelper.findAndClickElement(xpathsMap["="]);
      Assert.Equal(result, pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
      pageHelper.findAndClickElement(ConstantXpaths.clearXpath);
      Assert.Equal("0", pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
    }

    [Theory, Trait("Category","TestCat")]
    [InlineData(new float[] {1,2,3,4,5,6},"6",new string[] {"+","-","*","/","+"})]
    [InlineData(new float[] {1,-2,43,-4,50,61},"60.04",new string[] {"+","-","*","/","+"})]

    public void VerifySpecifiedOperationsForGivenNumbers(float[] numbers, string result, string[] operation) {
      CommonHelper commonHelper = new(Driver,output);
      PageHelper pageHelper = new(Driver);
      Dictionary<string,string> xpathsMap = Transformation.CreateMap();
      commonHelper.parseAndClickEachNumbersWithOperations(numbers,operation);
      pageHelper.findAndClickElement(xpathsMap["="]);
      Assert.Equal(result, pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
      pageHelper.findAndClickElement(ConstantXpaths.clearXpath);
      Assert.Equal("0", pageHelper.findElementAndGetText(ConstantXpaths.resultXpath));
    }

  }
