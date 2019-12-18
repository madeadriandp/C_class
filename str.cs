using System.Xml.Linq;
using System.Globalization;
using System;
using System.Linq;
using System.IO;  
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
namespace basic2
{
    public class str
    {
       public static void manipulate()
       {
            string input;            
            Console.Write("Input: "); 
            input = Console.ReadLine();
            Console.WriteLine($"Lowercase: {input.ToLower()}");
            Console.WriteLine($"Uppercase: {input.ToUpper()}");
            TextInfo textInfo = new CultureInfo ("en-US",false).TextInfo;
            Console.WriteLine($"Capital: {textInfo.ToTitleCase(input)}");
            
            string kata2 = string.Join(" ", input
               .Split(" ")
               .Select(x=> new String(x.Reverse().ToArray())));
            Console.WriteLine($"Reversed: {kata2}");
            Console.Write("Does Input contains the word 'makan'? :");
            Console.WriteLine(input.Contains("makan"));
            Console.Write("Does Input contains the word 'rujak'? :");
            Console.WriteLine(input.Contains("rujak"));

            Console.Write("Number of character(s) in Input: ");
            Console.WriteLine(input.Length);

            Console.Write("Number of word(s) in Input: ");

            string[] input2 = input.Split(" ");
            Console.WriteLine(input2.Length);
            
            string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ";
            string short_lorem = lorem.Substring(0, 20);
            Console.WriteLine(short_lorem);
            Console.WriteLine($"{short_lorem}.....");

            string[] loremarr= lorem.Split(" ");
            List<string> loremlist = loremarr.ToList();
            List<string> first20 = loremlist.GetRange(0,20);
            Console.WriteLine(String.Join(" ", first20 ));
            // List<string> first20dot = first20.Add("....");


       }  

       public static void slug()
       {
          string title = "JavaScript, TypeScript & Dart - Bahasa mana yang akan populer di 2018?";
           title = Regex.Replace(title.ToLower(), @"[\W\s]", "-" );
           title = Regex.Replace(title, "---", "-");
           title = Regex.Replace(title, "--", "-");
           
          Console.WriteLine(title);
// Str.slug(title)      // javascript-typescript-dart-bahasa-mana-yang-akan-populer-di-2018
// Str.slug(title, '_') // javascript_typescript_dart_bahasa_mana_yang_akan_populer_di_2018
       }
            
            private static Random random = new Random();
            public static string RandomString(int length)
            {
                const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

            }

           public static string ToUrlSlug(string value){ 

            //First to lower case 
            value = value.ToLowerInvariant(); 

            //Remove all accents
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value); 

            value = Encoding.ASCII.GetString(bytes); 

            //Replace spaces 
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled); 

            //Remove invalid chars 
            value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "",RegexOptions.Compiled); 

            //Trim dashes from end 
            value = value.Trim('-', '_'); 

            //Replace double occurences of - or \_ 
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled); 

            return value ; 
          }



        
    }
}