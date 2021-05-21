using System;

namespace UnitTest_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "Hardi";
            string num = "2012H";
            //check wether the number is numeric or not
            if (num.IsValidNumeric() == true)
                Console.WriteLine("\"" + num + "\" is not valid numeric value");
            else
                Console.WriteLine("\"" + num + "\" is not valid numeric value");
            Console.WriteLine("##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==");

            //convert string to number
            if (num.ConvertStringToNumber() == null)
                Console.WriteLine("\"" + num + "\" can not convert in numeric value");
            else
                Console.WriteLine("\"" + num + "\" numeric value is : " + num.ConvertStringToNumber());
            //convert to upper
            Console.WriteLine("Input : \"" + input + "\" into Uppercase Letter : " + input.ConvertToUpper());
            input = "HARDI";

            //convert to lower
            Console.WriteLine("Input : \"" + input + "\" into Lowercase Letter : " + input.ConvertToLower());
            input = "hardi mehta";

            //convert into Titlecase
            Console.WriteLine("Input : \"" + input + "\" into Titlecase Letter : " + input.ConvertToTitleCase());
            input = "hardi";

            //check all character isLower or not
            Console.WriteLine("Check all the character of string is lower case or not : \"" + input + "\" : " + input.IsLower());
            input = "hardi mehta";

            //convert to Capital
            Console.WriteLine("Input : \"" + input + "\" into Capitalize : " + input.ConvertToCapitalize());
            input = "HARDI";

            //check all character isUpper or not
            Console.WriteLine("Is input in uppercase : \"" + input + "\" : " + input.IsUpper());
            input = "hardi mehta";

            //count number of letters 
            Console.WriteLine("No of words in the input : \"" + input + "\" : " + input.CountingWord());
            input = "Hardi Mehta";

            //remove last character from string
            Console.WriteLine("Removing last character from input : \"" + input + "\" : "+ input.RemoveLastCharacterFrom());            
            Console.WriteLine("##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==");
        }
    }
}
