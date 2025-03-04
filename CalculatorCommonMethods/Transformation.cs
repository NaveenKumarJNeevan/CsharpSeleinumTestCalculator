using System.Collections.Generic;
using System.Numerics;

public class Transformation { 

public static Dictionary<string, string> CreateMap() {
    Dictionary<string, string> calculatorElement =  
           new Dictionary<string, string>();
        calculatorElement.Add("1", ConstantXpaths.one); 
        calculatorElement.Add("2", ConstantXpaths.two); 
        calculatorElement.Add("3", ConstantXpaths.three); 
        calculatorElement.Add("4", ConstantXpaths.four); 
        calculatorElement.Add("5", ConstantXpaths.five); 
        calculatorElement.Add("6", ConstantXpaths.six);
        calculatorElement.Add("7", ConstantXpaths.seven); 
        calculatorElement.Add("8", ConstantXpaths.eight); 
        calculatorElement.Add("9", ConstantXpaths.nine); 
        calculatorElement.Add("0", ConstantXpaths.zero);
        calculatorElement.Add("-", ConstantXpaths.subtractionXpath);
        calculatorElement.Add("+", ConstantXpaths.additionXpath);
        calculatorElement.Add("/", ConstantXpaths.divisionXpath);  
        calculatorElement.Add("*", ConstantXpaths.multiplicationXpath);
        calculatorElement.Add("=", ConstantXpaths.equalsXpath);
        calculatorElement.Add(".", ConstantXpaths.decimalXpath);          
    return calculatorElement;

}

public static List<char> ParsedNumber(float number) {
    
    string convertedNumber = number.ToString();
    return [.. convertedNumber];

}

}