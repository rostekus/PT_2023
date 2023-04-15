namespace PTTaskZero
{

    public class StringManipulator
    {
        public static string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool IsPalindrome(string input)
        {
            string reversed = Reverse(input);
            return String.Equals(reversed, input);
        }


        public static string ConcatenateStrings(string[] strings)
        {
            return string.Concat(strings);
        }


    }

}
