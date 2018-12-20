using System;

namespace OnlineQuizSamples
{
    public static class Extensions
    {
        public static int ToInt(this string input)
        {
            return Convert.ToInt32(input);
        }

        public static int ToInt(this char input)
        {
            return Convert.ToInt32(input);
        }
    }
}
