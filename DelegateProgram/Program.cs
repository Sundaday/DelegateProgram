using System;
using System.Linq;

namespace DelegateProgram
{
    public delegate string CharValidation(string s);
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = AskSomethingToUser("What is your name ?", NameValidator);
            string phone = AskSomethingToUser("What is your phone number ?", PhoneValidator);

            Console.WriteLine("Hi ! My name is " + name + " and you can join my at " + phone);
        }

        static string AskSomethingToUser(string message, CharValidation ValidationFunction = null)
        {
            Console.Write(message + " ");
            string responseMessage = Console.ReadLine();
            Console.WriteLine();
            if(ValidationFunction != null)
            {
                string error = ValidationFunction(responseMessage);
                if(error != null)
                {
                    Console.WriteLine("ERROR n° " + error);
                    Console.WriteLine();
                    return AskSomethingToUser(message, ValidationFunction);
                }
            }
            return responseMessage;
        }

        static string NameValidator(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "1 ... Name can't be empty";
            }
            if (s.Any(char.IsDigit))
            {
                return "2 ... Name can't be a number";
            }
            return null; 
        }

        static string PhoneValidator(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "3 ... Name can't be empty";
            }

            if (s.Length != 10)
            {
                return "4 ... Phone Number can't be longer than 10";
            }

            if (!s.All(char.IsDigit))
            {
                return "5 ... Phone Number have to be compose by number only";
            }
            return null; 
        }
    }
}
