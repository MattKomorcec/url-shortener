using System;
using System.Text;

namespace Application.Helpers
{
    public static class ShortUrlGenerator
    {
        private static int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 9);
        }

        private static char GenerateRandomCharacter()
        {
            Random random = new Random();

            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        }

        public static string GenerateRandomShortUrl()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(GenerateRandomCharacter());
            builder.Append(GenerateRandomNumber());
            builder.Append(GenerateRandomCharacter());
            builder.Append(GenerateRandomNumber());
            builder.Append(GenerateRandomCharacter());
            builder.Append(GenerateRandomNumber());

            return builder.ToString();
        }
    }
}
