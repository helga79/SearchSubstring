using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
   public class Program
    {
        static string text          = string.Empty ;   
        static string subText       = string.Empty ;
        static bool repeatSearch    = true;
        static void Main(string[] args)
        {
            while (repeatSearch)
            {
                SetSearchInput();     

                if (subText.Length > text.Length)
                {
                    Console.WriteLine("Subtext should be smaller than Text. Please try again !");
                }
                else
                {
                    text    = text.ToLower();
                    subText = subText.ToLower();
                    List<int> matchedLocations = SearchHelper.FindMatchedLocations(text, subText);
                    FormatOutput(matchedLocations);                   
                }
                //to repeat search
                Console.WriteLine("Do you want to continue search? Enter Y or N ");
                string repeat = Console.ReadLine();

                if (repeat.ToUpper() == "Y")
                {
                    repeatSearch = true;
                }
                else
                {
                    repeatSearch = false;
                }
            }//end of while
          
        }

        public static void SetSearchInput()
        {
            Console.WriteLine("Enter Text ");
            text = Console.ReadLine();
            Console.WriteLine("Enter Subtext ");
            subText = Console.ReadLine();

            
        }
        public static void FormatOutput(List<int> matchedLocations)
        {
            StringBuilder outputLocations = new StringBuilder();
            if (matchedLocations.Count > 0)
            {
                foreach (int item in matchedLocations)
                {
                    if (string.IsNullOrEmpty(outputLocations.ToString()))                        
                    {
                        outputLocations.Append(item);
                    }
                    else
                    {
                        outputLocations.Append(", " + item); //to get formatted output 
                    }
                }
                Console.WriteLine("Output : " + outputLocations);
            }
            else
            {
                Console.WriteLine("No Matches");
            }
        }

       
    }
}
