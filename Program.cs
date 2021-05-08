using System;
using System.Collections.Generic;

namespace CSVParsing
{

    
    class Program
    {
        public static List<String> getCSV(string s)
        {
            List<string> output = new List<string>();

            string temp = "";

            for (int i = 0; i < s.Length; i++)
            {
                
                if (s[i] == '\"')
                {
                    i++;
                    while (s[i] != '\"') 
                    {
                        temp += s[i];
                        i++; 
                    } 
                }

                if (s[i] != '\"' && s[i] != ',')
                {
                    temp += s[i];
                }
                
                if (s[i] == ',' || s[i] == '\n' || i == s.Length - 1)
                {
                    output.Add(temp);
                    temp = "";
                }
            }

            return output;
        }

        static void Main(string[] args)
        {/**************************
          * read CSV with embedded commas
          * parse CSV into separate fields and
          * ignore commas within quoted string
          * ***********************/
            Console.WriteLine("Reading CSV with embedded commas");
            List<string> myList = new List<string>();


            string input1 = "\"a,b\",c"; 
            myList.Add(input1);

            string input2 = "\"Obama, Barack\",\"August 4, 1961\",\"Washington, D.C.\"";
            myList.Add(input2); 


            string input3 = 
                "\"Ft. Benning, Georgia\",32.3632N,84.9493W," + 
                "\"Ft. Stewart, Georgia\",31.8691N,81.6090W," + 
                "\"Ft. Gordon, Georgia\",33.4302N,82.1267W"; 
            myList.Add(input3);


            foreach (string s in myList)
            {
                Console.WriteLine($"Current input is {s}");
                List<string> output = getCSV(s); 
                int len = output.Count;
                Console.WriteLine($"This line has {len} fields. They are:");
                foreach (string s1 in output)
                    Console.WriteLine(s1);
            }
        }
    }
}
