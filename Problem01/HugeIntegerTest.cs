//ID: 1775227
//Name: Marissa Goncalves
//Assignment 4 - Problem 1: HugeInteger

using System;

namespace Problem01
{
    class HugeIntegerTest
    {

        public static HugeInteger Input()
        {
            Console.Write("Please enter a postive or negative huge number with 40 digits or less: ");
            string input = Console.ReadLine();

            while (input.Length > 40)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid Input. Please try again");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Please enter a positive or negative huge number with 40 digits or less: ");
                input = Console.ReadLine();
            }

            Console.WriteLine();

            return new HugeInteger(input);
        }


        static void Main(string[] args)
        {

            bool agreeToInputAgain = true;

            do
            {

                HugeInteger firstInteger = Input();
                HugeInteger secondInteger = Input();

                Console.WriteLine();
                Console.WriteLine($"The value of the first integer:                                       {firstInteger.ToString(), 4}");
                Console.WriteLine($"The value of the second integer:                                      {secondInteger.ToString(), 4}");
                Console.WriteLine();
                Console.WriteLine($"The value of the first integer input is zero:                         {firstInteger.IsZero(), 4}");
                Console.WriteLine($"The value of the second integer input is zero:                        {secondInteger.IsZero(), 4}");
                Console.WriteLine();
                Console.WriteLine($"The sum of the first integer and the second integer:                  {firstInteger + secondInteger, 4}");
                Console.WriteLine($"The difference of the first integer and the second integer:           {firstInteger - secondInteger, 4}");
                Console.WriteLine($"The product of the first integer and the second integer:              {firstInteger * secondInteger, 4}");
                Console.WriteLine($"The quotient of the first integer and the second integer:             {firstInteger / secondInteger, 4}");
                Console.WriteLine($"The remainder of the first integer and the second integer:            {firstInteger % secondInteger,4}");
                Console.WriteLine();
                Console.WriteLine($"The sum of the second integer and the first integer:                  {secondInteger + firstInteger, 4}");
                Console.WriteLine($"The difference of the second integer and the first integer:           {secondInteger - firstInteger, 4}");
                Console.WriteLine($"The product of the second integer and the first integer:              {secondInteger * firstInteger, 4}");
                Console.WriteLine($"The quotient of the second integer and the first integer:             {secondInteger / firstInteger, 4}");
                Console.WriteLine($"The remainder of the first integer and the second integer:            {firstInteger % secondInteger,4}");
                Console.WriteLine();
                Console.WriteLine($"The first integer is equal to the second integer:                     {firstInteger == secondInteger,4}");
                Console.WriteLine($"The first integer is not equal to the second integer:                 {firstInteger != secondInteger,4}");
                Console.WriteLine($"The first integer is greater than the second integer:                 {firstInteger > secondInteger,4}");
                Console.WriteLine($"The first integer is less than the second integer:                    {firstInteger < secondInteger,4}");
                Console.WriteLine($"The first integer is greater than or equal to the second integer:     {firstInteger >= secondInteger,4}");
                Console.WriteLine($"The first integer is less than or equal to the second integer:        {firstInteger <= secondInteger,4}");
                Console.WriteLine();
                Console.WriteLine($"The second integer is equal to the first integer:                     {secondInteger == firstInteger,4}");
                Console.WriteLine($"The second integer is not equal to the first integer:                 {secondInteger != firstInteger,4}");
                Console.WriteLine($"The second integer is greater than the first integer:                 {secondInteger > firstInteger,4}");
                Console.WriteLine($"The second integer is less than the first integer:                    {secondInteger < firstInteger,4}");
                Console.WriteLine($"The second integer is greater than or equal to the first integer:     {secondInteger >= firstInteger,4}");
                Console.WriteLine($"The second integer is less than or equal to the first integer:        {secondInteger <= firstInteger,4}");
                Console.WriteLine();


                Console.Write($"Would you like to input values again? Yes(YES) or End(END). ");

                string decision = Console.ReadLine();

                Console.WriteLine();

               
                if (decision == "YES")
                {             
                    agreeToInputAgain = true;
                    Console.WriteLine();
                }

                else if (decision == "END")
                {
                    agreeToInputAgain = false;
                    Console.WriteLine();
                }

            }
            while (agreeToInputAgain == true);

        }
    }
}
