using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");

            string line = Console.ReadLine();
            string vowels = "aeiouy";
            string longestSubstring = "";
            string wrongChars = "";


            char[] charsEnglish = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] chars = line.ToCharArray();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            List<char> invalidCharsList = new List<char>();



            foreach (char c in line)
            {
                if (!charsEnglish.Contains(c))
                {
                    if (!invalidCharsList.Contains(c))
                    {
                        invalidCharsList.Add(c);
                    }
                }
            }

            if (invalidCharsList.Count > 0)
            {
                string invalidCharsString = string.Join(", ", invalidCharsList.ToArray());

                Console.WriteLine($"Не подходящие символы: {invalidCharsString}");
                Console.ReadKey();
            }

            foreach (char c in chars)
            {
                if (!charsEnglish.Contains(c))
                {
                    wrongChars += c + " ";
                }
            }


            foreach (char c in chars)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount.Add(c, 1);
                }
            }



            if (wrongChars != "")
            {

            }

            else
            {

                if ((line.Length % 2) == 0)
                {
                    Console.Write("Четная обработаная строка: ");

                    var str1 = line.Substring(0, line.Length / 2);
                    var str2 = line.Substring(line.Length / 2, line.Length / 2);


                    char[] charArray1 = str1.ToCharArray();
                    char[] charArray2 = str2.ToCharArray();
                    Array.Reverse(charArray1);
                    Array.Reverse(charArray2);


                    string s1 = new string(charArray1);
                    string s2 = new string(charArray2);
                    string LinePlus = s1 + s2;
                    Console.WriteLine(LinePlus);

                    for (int i = 0; i < LinePlus.Length; i++)
                    {
                        for (int j = i + 1; j <= LinePlus.Length; j++)
                        {
                            string subString = LinePlus.Substring(i, j - i);

                            if (vowels.Contains(subString[0]) && vowels.Contains(subString[subString.Length - 1]))
                            {
                                if (subString.Length > longestSubstring.Length)
                                {
                                    longestSubstring = subString;
                                }
                            }
                        }
                    }

                    Console.WriteLine("Самая длинная подстрока, начинающаяся и заканчивающаяся гласной буквой, - это: " + longestSubstring);

                }
                else
                {
                    Console.Write("Не четная обработаная строка: ");

                    char[] charArray1 = line.ToCharArray();
                    Array.Reverse(charArray1);
                    string a1 = new string(charArray1);
                    string LineMinus = a1 + line;
                    Console.WriteLine(LineMinus);


                    for (int i = 0; i < LineMinus.Length; i++)
                    {
                        for (int j = i + 1; j <= LineMinus.Length; j++)
                        {
                            string subString = LineMinus.Substring(i, j - i);

                            if (vowels.Contains(subString[0]) && vowels.Contains(subString[subString.Length - 1]))
                            {
                                if (subString.Length > longestSubstring.Length)
                                {
                                    longestSubstring = subString;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Самая длинная подстрока, начинающаяся и заканчивающаяся гласной буквой, - это: " + longestSubstring);
                }

                Console.WriteLine("Cколько раз входил в обработанную строку каждый символ:");

                foreach (KeyValuePair<char, int> kvp in charCount)
                {
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                }
                Console.ReadKey();

            }
        }
    }
}