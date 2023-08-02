namespace GraphTheory
{
    public static class ReverseWordsInAString
    {
        public static string ReverseWords(string s)
        {
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", words.Reverse());
        }
    }
}