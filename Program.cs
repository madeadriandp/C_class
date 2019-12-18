
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Collections;
using System.Globalization;

namespace basic2
{
    class Program
    {
        static void Main(string[] args)
        {
            // csv();
            // palindrome2();
            // json.getJson();
            // JsonData.findFebruary();
            JsonData.findAri();
            // combinelists();
            // str.slug();
            // CSVObject();
            // JsonData.getJson();

            //  json.JsonSerialize();
            // str.manipulate();
            // str.ToUrlSlug("Cyrillic");
        //    Console.WriteLine(str.RandomString(6));
        //    Console.WriteLine(str.RandomString(32));
        }

        public static bool palindrome1(string value)
        {
            
        int min = 0;
        int max = value.Length - 1;
        while (true)
        {
            if (min > max)
            {
                return true;
            }
            char a = value[min];
            char b = value[max];

            // Scan forward for a while invalid.
            while (!char.IsLetterOrDigit(a))
            {
                min++;
                if (min > max)
                {
                    return true;
                }
                a = value[min];
            }

            // Scan backward for b while invalid.
            while (!char.IsLetterOrDigit(b))
            {
                max--;
                if (min > max)
                {
                    return true;
                }
                b = value[max];
            }

            if (char.ToLower(a) != char.ToLower(b))
            {
                return false;
            }
            min++;
            max--;
        }
        }

        public static void palindrome2()
        {
            string[] input=
            {
                "ibu ratna antar ubi",
                "kasur ini rusak",                 
                "A nut for a jar of tuna.",                 
                 "Borrow or rob?",                
                 "Was it a car or a cat I saw?",                 
                 "Yo, banana boy!",                 
                 "UFO tofu?",
                 "cobacobaaja"
            };
            
        foreach (string value in input)
        {
            Console.WriteLine("{0} = {1}", value, palindrome1(value));
        }

        }

        public static void combinelists()
        {
            List<string> first = new List<string>(){"Behind", "every", "great", "man"};
            List<string> second = new List<string>(){"is", "a", "woman"};
            List<string> third = new List<string>(){"rolling", "her", "eyes"};
             var combo = first.Concat(second).Concat(third).ToList();
             string gabung = String.Join(" ", combo);
                 
             Console.WriteLine(gabung); 
            
        }

        static void CSVObject () {
            string test = @"NAME, CATEGORY, PRICE
Xiaomi Redmi 5A, Smartphone, 1199000
Macbook Air, Laptop, 13775000
Samsung Galaxy J7, Smartphone, 3549000
DELL XPS 13, Laptop, 26799000
Xiaomi Mi 6, Smartphone, 5399000
LG V30 Plus, Smartphone, 10499000";
            var stuffs = test.Split ("\n").Skip (1).ToList ();
            List<Test> result = new List<Test> ();
           
            for (int i = 0; i < stuffs.Count; i++) {
                string[] content = stuffs[i].Split (", ");
                Test map = new Test ();
                map.name = content[0];
                map.category = content[1];
                map.price = decimal.Parse (content[2]);
                result.Add (map);
            }
            Console.WriteLine("Before Sorted:");
            foreach (var item in result) {
                Console.WriteLine ($"{item.name}, {item.price.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"))}, {item.category}");
            }
            Console.WriteLine();

             Console.WriteLine("After Sorted:");
            var resultSort = result.OrderBy (x => x.price);
            foreach (var item in resultSort) {
                Console.WriteLine ($"{item.name}, {item.price.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"))}, {item.category}");
            }
        }

        public static void censor()
        {   string[] word = { "dolor", "elit", "quis", "nisi", "fugiat", "proident", "laborum" };
            string text= @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            ";

            string[] array=Regex.Replace(text, "\n", " ").Split(" ");

            for(int i=0; i<array.Length; i++){
                for(int x=0; x<word.Length; x++){
                    if(array[i]==word[x])
                    {
                        List<char> tampung = new List<char>();
                        for(int z=0; z<word[x].Length; z++)
                        {
                            tampung.Add('*');
                        }
                        array[i]=string.Join("", tampung);
                    }
                }
            }
            string result=String.Join(" ", array);
            Console.WriteLine(result);
        }

        public static void countwords()
        {
            string paragraph = @"
            Aku ingin begini
Aku ingin begitu
Ingin ini itu banyak sekali
Semua semua semua
Dapat dikabulkan
Dapat dikabulkan
Dengan kantong ajaib
Aku ingin terbang bebas
Di angkasa
Hei... baling baling bambu
La... la... la...
Aku sayang sekali
Doraemon
La... la... la...
Aku sayang sekali";
  string[] paragraphSplit = Regex.Replace (paragraph.ToLower (), @"[\n\.]", " ").Split (" ");
            string[] word = { "aku", "ingin", "dapat" };
            for (int i = 0; i < word.Length; i++) {
                int count = 0;
                for (int j = 0; j < paragraphSplit.Length; j++) {
                    if (paragraphSplit[j] == word[i]) {
                        count++;
                    }
                }
                Console.WriteLine ($"{word[i]}: {count}");
            }

        }


    }



    class GFG : IComparer<string> 
{ 
    public int Compare(string x, string y) 
    { 
          
        if (x == null || y == null) 
        { 
            return 0; 
        } 
          
        // "CompareTo()" method 
        return x.CompareTo(y); 
          
    } 
} 

class Test {
            public string name { get; set; }
            public string category { get; set; }
            public decimal price { get; set; }
        }
        
        
            
        
  
}
