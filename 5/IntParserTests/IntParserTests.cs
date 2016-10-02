using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntParserTests
{
    [TestClass]
    public class IntParserTests
    {
        /*
        +13230 --> 13230
//       -0 --> 0
//       1,390,146: Bad Format
//       $190,235,421,127: Bad Format
//       0xFA1B: Bad Format
//       163042 --> 163042
//       -10 --> -10
//       2147483647 --> 2147483647
//       2147483648: Overflow
//       16e07: Bad Format
//       134985.0: Bad Format
//       -12034 --> -12034
//       -2147483648 --> -2147483648
//       -2147483649: Overflow
        */
        [TestMethod]
        public void TestParseSignPlus()
        {
            // Arrange
            string input = "+13230";
            int expected = 13230;

            RunTest(input, expected);
        }

        [TestMethod]
        public void TestParseSignMinus()
        {
            // Arrange
            string input = "-13230";
            int expected = -13230;

            RunTest(input, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParseBadFormat()
        {
            // Arrange
            string input = "1,390,146";
            int expected = int.MaxValue;

            RunTest(input, expected);
        }

        [TestMethod]
        public void TestParseSignZero()
        {
            // Arrange
            string input = "-0";
            int expected = 0;

            RunTest(input, expected);
        }

        private static void RunTest(string input, int expected)
        {
            // Act
            var parser = new IntParser.IntParser();
            int actual = parser.Parse(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
