namespace Homework13.PageObjects.Pages
{
    public static class GenericPages
    {
        public static BaseElementsPage BaseElementsPage => GetPage<BaseElementsPage>();

        public static CheckBoxPage CheckBoxPage => GetPage<CheckBoxPage>();

        public static RadioButtonPage RadioButtonPage => GetPage<RadioButtonPage>();

        public static WebTablePage WebTablePage => GetPage<WebTablePage>();

        public static ButtonPage ButtonPage => GetPage<ButtonPage>();

        public static LinkPage LinkPage => GetPage<LinkPage>();

        private static T GetPage<T>() where T : new() => new T();
    }
}