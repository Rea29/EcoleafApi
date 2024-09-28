namespace Common.Helpers
{
    public static class TextManipulationHelper
    {
        public static string TruncateStart(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            {
                return text;
            }
            return "..." + text.Substring(text.Length - maxLength + 3);
        }

    }
}
