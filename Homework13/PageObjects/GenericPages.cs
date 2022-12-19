﻿namespace Homework13.PageObjects
{
    public static class GenericPages
    {
        public static T GetPage<T>() where T : new() => new T();

        public static BaseElementsPage BaseElementsPage => GetPage<BaseElementsPage>();

        public static CheckBoxPage CheckBoxPage => GetPage<CheckBoxPage>();

        public static RadioButtonPage RadioButtonPage => GetPage<RadioButtonPage>();

        public static WebTablePage WebTablePage => GetPage<WebTablePage>();

        public static ButtonPage ButtonPage => GetPage<ButtonPage>();

        public static LinkPage LinkPage => GetPage<LinkPage>();
    }
}