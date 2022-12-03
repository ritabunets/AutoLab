using Microsoft.Extensions.Configuration;

namespace Homework11.Configs
{
    public class ExpectedConstants
    {
        public static IConfiguration TestConfiguration = new ConfigurationBuilder().AddJsonFile("C:\\Users\\Marharyta.Bunets\\source\\repos\\AutoLab\\Homework11\\Configs\\TestData.json").Build();
        public static string greenColor => TestConfiguration["Colors:greenColor"];
        public static string blueColor => TestConfiguration["Colors:blueColor"];
        public static string newEntryValue => TestConfiguration["Values:newEntryValue"];
        public static string messageDefaultText => TestConfiguration["Messages:messageDefaultText"];
        public static string messageDesktopIsSelected => TestConfiguration["Messages:messageDesktopIsSelected"];
        public static string messagePartWithAllSelectedItems => TestConfiguration["Messages:messagePartWithAllSelectedItems"];
        public static string expectedMessageForDoubleClick => TestConfiguration["Messages:expectedMessageForDoubleClick"];
        public static string expectedMessageForRightClick => TestConfiguration["Messages:expectedMessageForRightClick"];
        public static string expectedMessageForDynamicClick => TestConfiguration["Messages:expectedMessageForDynamicClick"];
        public static string expectedMessageCreated => TestConfiguration["Messages:expectedMessageCreated"];
        public static string expectedMessageNoContent => TestConfiguration["Messages:expectedMessageNoContent"];
        public static string expectedMessageMoved => TestConfiguration["Messages:expectedMessageMoved"];
        public static string expectedMessageBadRequest => TestConfiguration["Messages:expectedMessageBadRequest"];
        public static string expectedMessageUnauthorized => TestConfiguration["Messages:expectedMessageUnauthorized"];
        public static string expectedMessageForbidden => TestConfiguration["Messages:expectedMessageForbidden"];
        public static string expectedMessageNotFound => TestConfiguration["Messages:expectedMessageNotFound"];        
        public static string expectedDoubleClickButtonName => TestConfiguration["Names:expectedDoubleClickButtonName"];
        public static string expectedRightClickButtonName => TestConfiguration["Names:expectedRightClickButtonName"];
        public static string expectedDynamicClickButtonName => TestConfiguration["Names:expectedDynamicClickButtonName"];
    }
}