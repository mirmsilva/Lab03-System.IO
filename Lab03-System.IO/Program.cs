using System;
using System.IO;

namespace Lab03_System.IO
{
    class Program
    {
        static void Main(string[] args)
        {
            Challenge1();
            Challenge2();
            Challenge3();

            //Challenge6
            Console.WriteLine("Please enter a word and hit enter:");
            string wordIn = Console.ReadLine();
            //make sure the test file is placed in bin/debug/net5.0 but not in ref
            string path = "./Test.txt";
            Challenge6(wordIn, path);

            //Challenge 7 wrapped into Challange 6

            Challenge8(wordIn);
            Challenge9();

        }
        public static int Challenge1()
        {
            Console.WriteLine("Please enter in 3 numbers on one line, separated by spaces.");
            string res = Console.ReadLine();
            int productRes = Product(res);
            Console.WriteLine($"The product of these 3 nums is {productRes}");
            return productRes;
        }
        public static int Product(string numbers)
        {
            int product = 1;
            string[] productArr = numbers.Split(' ');
            if (productArr.Length < 3) return 0;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    int intNum = Convert.ToInt32(productArr[i]);
                    product = product * intNum;
                }
                catch (Exception e)
                {
                    product = product * 1;
                }
            }
            return product;
        }
        public static int Challenge2()
        {
            try
            {
                Console.WriteLine("Please enter in a number between 2 - 10");
                int arrLength = Convert.ToInt32(Console.ReadLine());
                if (arrLength < 2 || arrLength > 10) throw new Exception("Out of range. Please try again.");
                int[] arr = new int[arrLength - 1];
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"{i + 1} of {arr.Length} - Enter a number:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num < 0)
                    {
                        throw new Exception("Num cannot be lesser than 0");
                    }
                    arr[i] = num;
                    sum += num;
                }
                int avg = sum / arr.Length;
                Console.WriteLine($"The average of these numbers is {avg}");
                return avg;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter in an integer for your value.");
                return -1;
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
        public static void Challenge3()
        {
            Console.Write("    * \n\n   *** \n\n  *****\n\n *******\n\n*********\n\n *******\n\n  *****\n\n   ***\n\n    * ");
        }


        //Challenge 6
        public static void Challenge6(string word, string path)
        {
            //add on the word as a string, after putting in a character return
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, word);
            //console write to prove we have everything made
            string feedback = File.ReadAllText(path);
            Console.WriteLine(feedback);
        }

        public static void Challenge8(string wordIn)
        {

            string filePath = "../../../../string.txt";
            string fileText = File.ReadAllText(filePath);
            string[] words = fileText.Split(' ');
            for (int i = 0; i < words.GetLength(0); i++)
            {
                if (words[i] == badWord)
                {
                    words[i] = "";
                }
            }
            string newText = String.Join(' ', words);
            try
            {
                Console.WriteLine("test");
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    try
                    {
                        sw.Write(newText);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void Challenge9()
        {
            Console.WriteLine("Please write a sentence with no punctuation");
            string userInput = Console.ReadLine();
            string[] inputArray = userInput.Split(" ");
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = inputArray[i] + ": " + inputArray[i].Length.ToString();
                Console.WriteLine(inputArray[i]);
            }
        }
    }
}

