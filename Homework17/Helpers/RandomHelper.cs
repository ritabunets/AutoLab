﻿namespace Homework17.Helpers
{
    public static class RandomHelper
    {
        public static string GetRandomString(int length)
        {
            Guid g = Guid.NewGuid();
            var guidString = g.ToString().Substring(0, length);

            return guidString;
        }

        public static int GetRandomInt(int maxValue)
        {
            var random = new Random();
            int newRandomInt = random.Next(0, maxValue);

            return newRandomInt;
        }
    }
}