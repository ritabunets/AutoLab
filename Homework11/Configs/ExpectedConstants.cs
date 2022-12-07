using Microsoft.Extensions.Configuration;

namespace Homework11.Configs
{
    public class ExpectedConstants
    {
        public static IConfiguration TestConfiguration = new ConfigurationBuilder().AddJsonFile("Configs\\TestData.json").Build();
        public static string GreenColor => TestConfiguration["Colors:GreenColor"];
        public static string BlueColor => TestConfiguration["Colors:BlueColor"];
        public static string NewEntryValue => TestConfiguration["Values:NewEntryValue"];
        public static string MessageDefaultText => TestConfiguration["Messages:MessageDefaultText"];
        public static string MessageDesktopIsSelected => TestConfiguration["Messages:MessageDesktopIsSelected"];
        public static string MessagePartWithAllSelectedItems => TestConfiguration["Messages:MessagePartWithAllSelectedItems"];
        public static string ExpectedMessageForDoubleClick => TestConfiguration["Messages:ExpectedMessageForDoubleClick"];
        public static string ExpectedMessageForRightClick => TestConfiguration["Messages:ExpectedMessageForRightClick"];
        public static string ExpectedMessageForDynamicClick => TestConfiguration["Messages:ExpectedMessageForDynamicClick"];
        public static string ExpectedMessageCreated => TestConfiguration["Messages:ExpectedMessageCreated"];
        public static string ExpectedMessageNoContent => TestConfiguration["Messages:ExpectedMessageNoContent"];
        public static string ExpectedMessageMoved => TestConfiguration["Messages:ExpectedMessageMoved"];
        public static string ExpectedMessageBadRequest => TestConfiguration["Messages:ExpectedMessageBadRequest"];
        public static string ExpectedMessageUnauthorized => TestConfiguration["Messages:ExpectedMessageUnauthorized"];
        public static string ExpectedMessageForbidden => TestConfiguration["Messages:ExpectedMessageForbidden"];
        public static string ExpectedMessageNotFound => TestConfiguration["Messages:ExpectedMessageNotFound"];
        public static string ExpectedDoubleClickButtonName => TestConfiguration["Names:ExpectedDoubleClickButtonName"];
        public static string ExpectedRightClickButtonName => TestConfiguration["Names:ExpectedRightClickButtonName"];
        public static string ExpectedDynamicClickButtonName => TestConfiguration["Names:ExpectedDynamicClickButtonName"];
    }
}