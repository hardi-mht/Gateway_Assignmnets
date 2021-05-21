using System;
using UnitTest_2;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        //testing method to convert string into upper case
        [Fact]
        public void ConvertToUpper_mthd1()
        {
            string str = "input";
            string result = str.ConvertToUpper();
            Assert.Equal("INPUT", result);
        }
        [Fact]
        public void ConvertToUpper_mthd2()
        {
            string str = "input";
            string result = str.ConvertToUpper();
            Assert.NotEqual("Input", result);
        }

        //testing method to convert string into lower case
        [Fact]
        public void ConvertToLower_mthd1()
        {
            string str = "INPUT";
            string result = str.ConvertToLower();
            Assert.Equal("input", result);
        }
        [Fact]
        public void ConvertToLower_mthd2()
        {
            string str = "INPUT";
            string result = str.ConvertToLower();
            Assert.NotEqual("Input", result);
        }

        //testing method to convert the string to Sentence Case
        [Fact]
        public void ConvertToTitleCase_mthd1()
        {
            string str = "this is a demo";
            string result = str.ConvertToTitleCase();
            Assert.Equal("This Is A Demo", result);
        }
        [Fact]
        public void ConvertToTitleCase_mthd2()
        {
            string str = "this is a demo";
            string result = str.ConvertToTitleCase();
            Assert.NotEqual("This Is A demo", result);
        }

        //testing method to check is string in lower method or not
        [Fact]
        public void IsLower_mthd1()
        {
            string str = "input";
            bool result = str.IsLower();
            Assert.True(result);
        }
        [Fact]
        public void IsLower_mthd2()
        {
            string str = "Input";
            bool result = str.IsLower();
            Assert.False(result);
        }

        //testing method to check is string in upper case or not
        [Fact]
        public void IsUpper_mthd1()
        {
            string str = "INPUT";
            bool result = str.IsUpper();
            Assert.True(result);
        }
        [Fact]
        public void IsUpper_mthd2()
        {
            string str = "iNpUt";
            bool result = str.IsUpper();
            Assert.False(result);
        }

        //testing method to convert the letter to Capitalize
        [Fact]
        public void ConvertToCapitalize_mthd1()
        {
            string str = "this is a demo";
            string result = str.ConvertToCapitalize();
            Assert.Equal("This is a demo", result);
        }
        [Fact]
        public void ConvertToCapitalize_mthd2()
        {
            string str = "this is a demo";
            string result = str.ConvertToCapitalize();
            Assert.NotEqual("This Is A Demo", result);
        }

        //testing method to count total words in a string
        [Fact]
        public void CountingTotalWord_mthd1()
        {
            string str = "this is a demo";
            int result = str.CountingWord();
            Assert.Equal(4, result);
        }
        [Fact]
        public void CountingTotalWord_mthd2()
        {
            string str = "this is a demo";
            int result = str.CountingWord();
            Assert.NotEqual(1, result);
        }

        //testing method to remove last charater from string
        [Fact]
        public void RemoveLastCharacterFrom_mthd1()
        {
            string str = "input";
            string result = str.RemoveLastCharacterFrom();
            Assert.Equal("inpu", result);
        }
        [Fact]
        public void RemoveLastCharacterFrom_mthd2()
        {
            string str = "input";
            string result = str.RemoveLastCharacterFrom();
            Assert.NotEqual("inp", result);
        }

        //testing method to check wether the number is valid numeric or not 
        [Fact]
        public void IsValidNumeric_mthd1()
        {
            string str = "2012";
            bool result = str.IsValidNumeric();
            Assert.True(result);
        }
        [Fact]
        public void IsValidNumeric_mthd2()
        {
            string str = "2012H";
            bool result = str.IsValidNumeric();
            Assert.False(result);
        }

        //testing method to convert the string to number
        [Fact]
        public void ConvertStringToNumber_mthd1()
        {
            string str = "2012";
            int? result = str.ConvertStringToNumber();
            Assert.Equal(1929, result);
        }
        [Fact]
        public void ConvertStringToNumber_mthd2()
        {
            string str = "2012H";
            int? result = str.ConvertStringToNumber();
            Assert.Null(result);
        }
    }
}
