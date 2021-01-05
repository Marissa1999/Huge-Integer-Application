//ID: 1775227
//Name: Marissa Goncalves
//Assignment 4 - Problem 1: HugeInteger

using System;
using System.Collections.Generic;

namespace Problem01
{

    class HugeInteger
    {

        private const int MAXIMUM_SIZE = 40;
        public char NumberSign { get; set; } = '+';
        public int[] HugeIntegerArray { get; set; } = new int[MAXIMUM_SIZE];


        public HugeInteger(HugeInteger calculatedNumber)
        {
            HugeIntegerArray = calculatedNumber.HugeIntegerArray;
            NumberSign = calculatedNumber.NumberSign;
        }

 
        public HugeInteger(string inputNumber)
        {

            if (inputNumber[0] == '+')
            {
                inputNumber = inputNumber.Remove(0, 1);
            }

            else if (inputNumber[0] == '-')
            {
                inputNumber = inputNumber.Remove(0, 1);
                NumberSign = '-';
            }


            if (inputNumber == "")
            {
                inputNumber = "0";
            }


            int leadingZeros = 0;
            int i = 0;

            while (int.Parse(inputNumber[i].ToString()) == 0)
            {
                if (i == inputNumber.Length - 1)
                {
                    inputNumber = "0";
                    leadingZeros = 0;
                    break;
                }

                leadingZeros++;
                i++;
            }

            HugeIntegerArray = new int[inputNumber.Length - leadingZeros];

            for (int k = leadingZeros; k < inputNumber.Length; k++)
            {
                HugeIntegerArray[k - leadingZeros] = int.Parse(inputNumber[k].ToString());
            }


        }



        public override string ToString()
        {

            string hugeIntegerStringOuput = "";

            if (NumberSign == '-')
            {
                hugeIntegerStringOuput += '-';
            }

            foreach (var number in HugeIntegerArray)
            {
                hugeIntegerStringOuput += number;
            }

            return hugeIntegerStringOuput;
           
        }



        public bool IsZero()
        {

            foreach (var element in HugeIntegerArray)
            {
                if (element != 0)
                {
                    return false;
                }
            }

            return true;
        }




        public override bool Equals(object obj)
        {
            var integer = obj as HugeInteger;
            return integer != null &&
                   NumberSign == integer.NumberSign &&
                   EqualityComparer<int[]>.Default.Equals(HugeIntegerArray, integer.HugeIntegerArray);
        }





        public override int GetHashCode()
        {
            var hashCode = -618711958;
            hashCode = hashCode * -1521134295 + NumberSign.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(HugeIntegerArray);
            return hashCode;
        }




        public static HugeInteger operator + (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (firstInteger.NumberSign == '+' && secondInteger.NumberSign == '+')
            {

                string sumString = "";
                int smallLength = Math.Min(firstInteger.HugeIntegerArray.GetLength(0), secondInteger.HugeIntegerArray.GetLength(0));
                int longLength = Math.Max(firstInteger.HugeIntegerArray.GetLength(0), secondInteger.HugeIntegerArray.GetLength(0));
                int carry = 0;

                for (int counter = 1; counter <= smallLength; counter++)
                {

                    int sum = firstInteger.HugeIntegerArray[firstInteger.HugeIntegerArray.GetLength(0) - counter] + secondInteger.HugeIntegerArray[secondInteger.HugeIntegerArray.GetLength(0) - counter] + carry;

                    if (firstInteger.HugeIntegerArray.GetLength(0) == secondInteger.HugeIntegerArray.GetLength(0) && counter == smallLength)
                    {
                        sumString = sumString.Insert(0, "" + sum);
                        break;
                    }

                    else
                    {
                        sumString = sumString.Insert(0, "" + sum % 10);
                    }

                    if (sum >= 10)
                    {
                        carry = 1;
                    }

                    else
                    {
                        carry = 0;
                    }

                }

                for (int counter = smallLength + 1; counter <= longLength; counter++)
                {
                    int additionColumn;

                    try
                    {
                        additionColumn = firstInteger.HugeIntegerArray[firstInteger.HugeIntegerArray.GetLength(0) - counter] + carry;
                    }

                    catch
                    {
                        additionColumn = secondInteger.HugeIntegerArray[secondInteger.HugeIntegerArray.GetLength(0) - counter] + carry;
                    }

                    sumString = sumString.Insert(0, "" + additionColumn % 10);

                    if (additionColumn >= 10)
                    {
                        carry = 1;

                        if (counter == longLength)
                        {
                            sumString = sumString.Insert(0, "" + carry);
                        }

                    }

                    else
                    {
                        carry = 0;
                    }

                }

                return new HugeInteger(sumString);
            }

            else if (firstInteger.NumberSign == '+' && secondInteger.NumberSign == '-')
            {
                HugeInteger temp = new HugeInteger(secondInteger);
                temp.NumberSign = '+';
                return firstInteger - temp;
            }

            else if (firstInteger.NumberSign == '-' && secondInteger.NumberSign == '+')
            {
                HugeInteger temp = new HugeInteger(firstInteger);
                temp.NumberSign = '+';
                return secondInteger - temp;
            }

            else
            {
                HugeInteger firstIntegerTemp = new HugeInteger(firstInteger);
                HugeInteger secondIntegerTemp = new HugeInteger(secondInteger);
                firstIntegerTemp.NumberSign = '+';
                secondIntegerTemp.NumberSign = '+';

                HugeInteger sum = firstIntegerTemp + secondIntegerTemp;
                sum.NumberSign = '-';
                return sum;
            }
            
        }
   
   

        
        public static HugeInteger operator - (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (firstInteger.NumberSign == '+' && secondInteger.NumberSign == '+')
            {
                if (firstInteger >= secondInteger)
                {
                    string differenceString = "";
                    int smallLength = Math.Min(firstInteger.HugeIntegerArray.GetLength(0), secondInteger.HugeIntegerArray.GetLength(0));
                    int longLength = Math.Max(firstInteger.HugeIntegerArray.GetLength(0), secondInteger.HugeIntegerArray.GetLength(0));
                    int borrow = 0;

                    for (int counter = 1; counter <= smallLength; counter++)
                    {
                        int difference = firstInteger.HugeIntegerArray[firstInteger.HugeIntegerArray.GetLength(0) - counter] - secondInteger.HugeIntegerArray[secondInteger.HugeIntegerArray.GetLength(0) - counter] - borrow;

                        if (difference < 0)
                        {
                            difference += 10;
                            borrow = 1;
                        }

                        else
                        {
                            borrow = 0;
                        }

                        differenceString = differenceString.Insert(0, "" + difference);
                    }

                    for (int counter = smallLength + 1; counter <= longLength; counter++)
                    {
                        int subtractionColumn;

                        try
                        {
                            subtractionColumn = firstInteger.HugeIntegerArray[firstInteger.HugeIntegerArray.GetLength(0) - counter] - borrow;
                        }
                        catch
                        {
                            subtractionColumn = secondInteger.HugeIntegerArray[secondInteger.HugeIntegerArray.GetLength(0) - counter] - borrow;
                        }

                        if (subtractionColumn < 0)
                        {
                            subtractionColumn += 10;
                            borrow = 1;
                        }

                        else
                        {
                            borrow = 0;
                        }

                        differenceString = differenceString.Insert(0, "" + subtractionColumn);
                    }

                    return new HugeInteger(differenceString);
                }

                else
                {
                    HugeInteger difference = secondInteger - firstInteger;
                    difference.NumberSign = '-';
                    return difference;
                }
            }

            else if (firstInteger.NumberSign == '+' && secondInteger.NumberSign == '-')
            {
                HugeInteger temp = new HugeInteger(secondInteger);
                temp.NumberSign = '+';
                return new HugeInteger(firstInteger + temp);
            }

            else if (firstInteger.NumberSign == '-' && secondInteger.NumberSign == '+')
            {
                HugeInteger temp = new HugeInteger(firstInteger);
                temp.NumberSign = '-';
                return new HugeInteger(secondInteger + temp);
            }

            else
            {
                HugeInteger firstIntegerTemp = new HugeInteger(firstInteger);
                HugeInteger secondIntegerTemp = new HugeInteger(secondInteger);
                firstIntegerTemp.NumberSign = '+';
                secondIntegerTemp.NumberSign = '+';
                HugeInteger difference = secondIntegerTemp - firstIntegerTemp;
                return new HugeInteger(difference);
            }
        }



        public static HugeInteger operator * (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (firstInteger.IsZero() || secondInteger.IsZero())
            {
                return new HugeInteger("0");
            }


            HugeInteger firstIntegerTemp = new HugeInteger(firstInteger);
            HugeInteger secondIntegerTemp = new HugeInteger(secondInteger);
            firstIntegerTemp.NumberSign = '+';
            secondIntegerTemp.NumberSign = '+';


            if (firstIntegerTemp < secondInteger)
            {
                return secondInteger * firstInteger;
            }

            HugeInteger resultProduct = new HugeInteger("0");

            int zeros = 0;

            for (int shortRow = secondInteger.HugeIntegerArray.Length - 1; shortRow >= 0; shortRow--)
            {
                int product = 0;
                int carry = 0;
                string productString = "";

                for (int i = 0; i < zeros; i++)
                {
                    productString += "0";
                }

                for (int longRow = firstInteger.HugeIntegerArray.Length - 1; longRow >= 0; longRow--)
                {
                    product = secondInteger.HugeIntegerArray[shortRow] * firstInteger.HugeIntegerArray[longRow] + carry;

                    if (longRow == 0)
                    {
                        productString = productString.Insert(0, product.ToString());
                        break;
                    }

                    if (product >= 10)
                    {
                        carry = product / 10;
                        product %= 10;
                    }

                    else
                    {
                        carry = 0;
                    }

                    productString = productString.Insert(0, product.ToString());

                }

                resultProduct += new HugeInteger(productString);
                zeros++;
            }

            if (firstInteger.NumberSign != secondInteger.NumberSign)
            {
                resultProduct.NumberSign = '-';
            }

            return resultProduct;

        }




        public static HugeInteger operator / (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (secondInteger.ToString() == "0")
            {
                return null;
            }

            HugeInteger quotient = new HugeInteger("0");
            HugeInteger firstIntegerTemp = new HugeInteger(firstInteger);
            HugeInteger secondIntegerTemp = new HugeInteger(secondInteger);
            firstIntegerTemp.NumberSign = '+';
            secondIntegerTemp.NumberSign = '+';


            HugeInteger difference = new HugeInteger(firstIntegerTemp);
            HugeInteger zero = new HugeInteger("0");


            bool condition = difference >= secondIntegerTemp;

            while (condition == true)
            {
                quotient += new HugeInteger("1");
                difference -= secondIntegerTemp;
                condition = (difference - secondIntegerTemp) >= zero;
            }

            if (firstInteger.NumberSign != secondInteger.NumberSign && quotient != new HugeInteger("0"))
            {
                quotient.NumberSign = '-';
            }

            return quotient;

        }





        public static HugeInteger operator % (HugeInteger firstInteger, HugeInteger secondInteger)
        {       
            HugeInteger quotient = firstInteger / secondInteger;
            HugeInteger remainder = firstInteger - (secondInteger * quotient);

            return remainder;
        }

       



        public static bool operator == (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (firstInteger.ToString().Equals(secondInteger.ToString()))
            {
                return true;
            }

            return false;
        }





        public static bool operator != (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (!firstInteger.ToString().Equals(secondInteger.ToString()))
            {
                return true;
            }

            return false;
        }




        public static bool operator > (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (firstInteger.NumberSign == '+' && secondInteger.NumberSign == '+')
            {

                if (firstInteger.HugeIntegerArray.Length > secondInteger.HugeIntegerArray.Length)
                {
                    return true;
                }

                else if (firstInteger.HugeIntegerArray.Length < secondInteger.HugeIntegerArray.Length)
                {
                    return false;
                }

                else
                {
                    for (int counter = 0; counter < firstInteger.HugeIntegerArray.Length; counter++)
                    {
                        if (firstInteger.HugeIntegerArray[counter] > secondInteger.HugeIntegerArray[counter])
                        {
                            return true;
                        }

                        else if (firstInteger.HugeIntegerArray[counter] < secondInteger.HugeIntegerArray[counter])
                        {
                            return false;
                        }
                    }

                    return false;
                }
            }

            else if (firstInteger.NumberSign == '+' && secondInteger.NumberSign == '-')
            {
                return true;
            }

            else if (firstInteger.NumberSign == '-' && secondInteger.NumberSign == '+')
            {
                return false;
            }

            else
            {


                if (firstInteger.HugeIntegerArray.Length < secondInteger.HugeIntegerArray.Length)
                {
                    return true;
                }

                else if (firstInteger.HugeIntegerArray.Length > secondInteger.HugeIntegerArray.Length)
                {
                    return false;
                }

                else
                {
                    for (int counter = 0; counter < firstInteger.HugeIntegerArray.Length; counter++)
                    {
                        if (firstInteger.HugeIntegerArray[counter] < secondInteger.HugeIntegerArray[counter])
                        {
                            return true;
                        }

                        else if (firstInteger.HugeIntegerArray[counter] > secondInteger.HugeIntegerArray[counter])
                        {
                            return false;
                        }
                    }

                    return false;
                }
             
            }

        }




        public static bool operator < (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if (!(firstInteger >= secondInteger))
            {
                return true;
            }

            else
            {
                return false;
            }

        }





        public static bool operator <= (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if ((firstInteger < secondInteger) || (firstInteger == secondInteger))
            {
                return true;
            }

            else
            {
                return false;
            }

        }




        public static bool operator >= (HugeInteger firstInteger, HugeInteger secondInteger)
        {

            if ((firstInteger > secondInteger) || (firstInteger == secondInteger))
            {
                return true;
            }

            else
            {
                return false;
            }

        }
 
    }
}

