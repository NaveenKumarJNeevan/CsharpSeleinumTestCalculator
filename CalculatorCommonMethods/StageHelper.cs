public class StageHelper {
    public static string getStage()
    {
        string stage = Environment.GetEnvironmentVariable("Stage");
        if(stage != null) {
            switch(stage) {
                case "Prod":
                    return Constants.ProdApplicationUrl;
                case "Stage":
                    return Constants.StageApplicationUrl;
                default :
                    break;
            }
        }
        return "";
    }
}