using PTTaskZero;

namespace TestPTTaskZero
{
    [TestClass]
    public class UnitTest1
    {
        // Reverse String Method Tests
        // ===========================================================

        [TestMethod]
        public void TestReverseStringWithSpaces()
        {
            string input = "Hello World!";
            string want = "!dlroW olleH";
            string got = StringManipulator.Reverse(input);
            Assert.AreEqual(want, got);

        }


        [TestMethod]
        public void TestReverseString()
        {
            string input = "Hello";
            string want = "olleH";
            string got = StringManipulator.Reverse(input);
            Assert.AreEqual(want, got);

        }

        [TestMethod]
        public void TestReverseEmptyString()
        {
            string input = "";
            string want = "";
            string got = StringManipulator.Reverse(input);
            Assert.AreEqual(want, got);

        }
        [TestMethod]
        public void TestReverseSpaces()
        {
            string input = "   ";
            string want = "   ";
            string got = StringManipulator.Reverse(input);
            Assert.AreEqual(want, got);

        }
        // IsPalindrome Method Tests
        // ===========================================================

        [TestMethod]
        public void TestIsPalindromeString()
        {
            string input = "kamilslimak";
            bool want = true;
            bool got = StringManipulator.IsPalindrome(input);
            Assert.AreEqual(want, got);

        }
        [TestMethod]
        public void TestIsPalindromeSpaces()
        {
            string input = "  ";
            bool want = true;
            bool got = StringManipulator.IsPalindrome(input);
            Assert.AreEqual(want, got);


        }
        [TestMethod]
        public void TestIsPalindromeEmptyString()
        {
            string input = "";
            bool want = true;
            bool got = StringManipulator.IsPalindrome(input);
            Assert.AreEqual(want, got);


        }
        [TestMethod]
        public void TestIsPalindromeNotPolindromeString()
        {
            string input = "1234";
            bool want = false;
            bool got = StringManipulator.IsPalindrome(input);
            Assert.AreEqual(want, got);

        }
        // Concatenate Strings Method Tests
        // ===========================================================

        [TestMethod]
        public void TestConcatenateStringsgArray()
        {
            string[] input = {"Hello", " World!"};
            string want = "Hello World!";
            string got = StringManipulator.ConcatenateStrings(input);
            Assert.AreEqual(want, got);

        }

        [TestMethod]
        public void TestConcatenateStringsgEmptyArray()
        {
            string[] input = {};
            string want = "";
            string got = StringManipulator.ConcatenateStrings(input);
            Assert.AreEqual(want, got);

        }

        [TestMethod]
        public void TestConcatenateStringsgArrayEmptyStrings()
        {
            string[] input = {"", "", "" ,"" };
            string want = "";
            string got = StringManipulator.ConcatenateStrings(input);
            Assert.AreEqual(want, got);

        }
    }
}