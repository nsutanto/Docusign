using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodHotSuccess()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "HOT 8, 6, 4, 2, 1, 7";
            string expectedOutput = "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);

        }

        [TestMethod]
        public void TestMethodColdSuccess()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "COLD 8, 6, 3, 4, 2, 5, 1, 7";
            string expectedOutput = "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);

        }

        [TestMethod]
        public void TestMethodHotFailDuplicate()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "HOT 8, 6, 6";
            string expectedOutput = "Removing PJs, shorts, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);

        }

        [TestMethod]
        public void TestMethodHotFailSocks()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "HOT 8, 6, 3";
            string expectedOutput = "Removing PJs, shorts, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestMethodHotFailJacket()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "HOT 8, 6, 5";
            string expectedOutput = "Removing PJs, shorts, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }



        [TestMethod]
        public void TestMethodColdIncomplete()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "COLD 8, 6, 3, 4, 2, 5, 7";
            string expectedOutput = "Removing PJs, pants, socks, shirt, hat, jacket, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestMethodColdShoesBeforeSocks()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "COLD 8, 6, 1, 3, 4, 2, 5, 7";
            string expectedOutput = "Removing PJs, pants, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestMethodColdShoesBeforePants()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "COLD 8, 3, 1, 7";
            string expectedOutput = "Removing PJs, socks, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestMethodColdHeadwearBeforeShirt()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "COLD 8, 2";
            string expectedOutput = "Removing PJs, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestMethodHotHeadwearBeforeShirt()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "HOT 8, 2";
            string expectedOutput = "Removing PJs, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestMethodColdJacketBeforeShirt()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "COLD 8, 5";
            string expectedOutput = "Removing PJs, fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestColdInvalidRemovePajamas()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "COLD 6";
            string expectedOutput = "fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestInvalidWeather()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "FALL 8, 6, 4, 2, 1, 7";
            string expectedOutput = "fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestInvalidCommand()
        {
            DressValidation dressValidation = new DressValidation();

            string input = "FALL 8, 6, 4, 2, 9, 1, 7";
            string expectedOutput = "fail";
            string output = dressValidation.Validate(input);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
