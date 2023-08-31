namespace API.Shared.Utilities
{
    public static class GuidFormatter
    {

        public static string RemoveHyphens(string guidString)
        {
            string guidWithoutHyphens = "";

            for (int i = 1; i < guidString.Length; i++)
            {
                char c = guidString[i];
                if (!c.Equals("-"))
                {
                    guidWithoutHyphens += c;
                }
            }
            Console.WriteLine("guid: " + guidWithoutHyphens);

            return guidWithoutHyphens;
        }

        public static string RemoveGuidHyphens(Guid guid)
        {
            //Guid id = new();
            string guidId = guid.ToString("N");
            return guidId;
        }
    }
}
