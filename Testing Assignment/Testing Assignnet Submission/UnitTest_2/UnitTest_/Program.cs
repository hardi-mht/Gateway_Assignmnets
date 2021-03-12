using System;

namespace UnitTest_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "Hardi";
            string num = "2012H";
            if (num.IsValidNumeric() == true)
                Console.WriteLine("\"" + num + "\" is not valid numeric value");
            else
                Console.WriteLine("\"" + num + "\" is not valid numeric value");
            Console.WriteLine("##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==");
            if (num.ConvertStringToNumber() == null)
                Console.WriteLine("\"" + num + "\" can not convert in numeric value");
            else
                Console.WriteLine("\"" + num + "\" numeric value is : " + num.ConvertStringToNumber());
            Console.WriteLine("Input : \"" + input + "\" into Uppercase Letter : " + input.ConvertToUpper());
            input = "HARDI";
            Console.WriteLine("Input : \"" + input + "\" into Lowercase Letter : " + input.ConvertToLower());
            input = "hardi mehta";
            Console.WriteLine("Input : \"" + input + "\" into Titlecase Letter : " + input.ConvertToTitleCase());
            input = "hardi";
            Console.WriteLine("Check all the character of string is lower case or not : \"" + input + "\" : " + input.IsLower());
            input = "hardi mehta";
            Console.WriteLine("Input : \"" + input + "\" into Capitalize : " + input.ConvertToCapitalize());
            input = "HARDI";
            Console.WriteLine("Is input in uppercase : \"" + input + "\" : " + input.IsUpper());
            input = "hardi mehta";
            Console.WriteLine("No of words in the input : \"" + input + "\" : " + input.CountingWord());
            input = "hardi mehta";
            Console.WriteLine("Removing last character from input : \"" + input + "\" : "+ input.RemoveLastCharacterFrom());            
            Console.WriteLine("##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==##==");
        }
    }
}
