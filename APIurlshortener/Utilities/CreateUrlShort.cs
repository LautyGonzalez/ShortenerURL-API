namespace APIurlshortener.Utilities
{
    public class CreateUrlShort
    {
            public static string GenerateShortUrl()
            {
                const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                const int length = 6;

                Span<char> randomChars = stackalloc char[length];

                Random random = new Random();

                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(chars.Length);
                    randomChars[i] = chars[index];
                }

                return new string(randomChars);
            }
        
    }
}
