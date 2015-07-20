/****************************
 * Author: Helga Banerjee
 * Version: 1.0
 * Date : 17 July 2015
 * Description : To find indexes  where subtext matches text
 * 
 * *********************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
   public static class SearchHelper 
    {
        /// <summary>
        /// To get list of matched indexes
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subText"></param>
        /// <returns></returns>
        public static List<int> FindMatchedLocations(string text, string subText)
        {
            int textLength = text.Length;
            int subTextLength = subText.Length;
            List<int> matchedLocations = new List<int>();
            
            int matchIndex = 0;
            int incrementTextIndex = 0;
            StringBuilder strMainCompare = new StringBuilder();

            while (incrementTextIndex < textLength && (incrementTextIndex + subTextLength - 1) <textLength)
                {
                    //check if first and last character of text and subtext are same
                    if (text[incrementTextIndex] == subText[0] && text[incrementTextIndex + subTextLength - 1] == subText[subTextLength - 1])
                    {
                        matchIndex = incrementTextIndex; //for output
                        int i = incrementTextIndex;
                        int loop = 0;
                        while (loop < subTextLength) // build new string to compare with subtext
                        {
                            strMainCompare.Append(text[i]);
                            loop++;
                            i++;
                        }

                        if (linearCompare(strMainCompare.ToString(), subText))
                        {
                            matchedLocations.Add((matchIndex + 1));
                            strMainCompare.Clear();
                        }
                        else
                        { 
                            //contiue looking for next match 
                            strMainCompare.Clear();
                        }
                        //reset index of maintext for next comparison by adding subtext length
                        incrementTextIndex = incrementTextIndex + subTextLength-1;
                    }
                    else
                    {
                        incrementTextIndex = incrementTextIndex + 1;
                    }
                }
           
            return matchedLocations;
        }

        /// <summary>
        /// Use this function if requirement is to use custom function for comparison 
        /// instead of this function you can use "==" to compare strings are equal
        /// </summary>
        /// <param name="strMainCompare"></param>
        /// <param name="subText"></param>
        /// <returns></returns>
        static  bool linearCompare(string strMainCompare, string subText)
        {
            int txtSize = strMainCompare.Length;
            int matchtimes = 0;
            for (int j = 0; j < txtSize; j++)
            {
                if (strMainCompare[j] == subText[j])
                {
                    matchtimes = matchtimes + 1;
                }
                else
                {
                    return false;
                }
            }

            if (matchtimes == txtSize)
                return true;
            else
                return false;
        }

    }
}
