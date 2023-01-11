namespace Homework13.UIElements
{
    public static class GenericElements
    {
        public static RegistrationFormPopup Popup => GetElement<RegistrationFormPopup>();

        private static T GetElement<T>() where T : new() => new T();
    }
}