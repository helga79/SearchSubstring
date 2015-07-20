using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Search.Tests
{
    [TestClass]
    public class UnitTestSearch
    {
     
        [TestMethod]
        public void Set3MatchesSearchInput()
        {
           string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
           string subText = "Polly";
           text = text.ToLower();
           subText = subText.ToLower();
           List<int> matchedLocations = SearchHelper.FindMatchedLocations(text, subText);
           string display = TestFormatMatchedLocations(matchedLocations);

           Assert.AreEqual(display,"1, 26, 51");
        }
         [TestMethod]
        public void SetNoMatchesSearchInput()
        {
            string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
            string subText = "Pollx";
            text = text.ToLower();
            subText = subText.ToLower();
            List<int> matchedLocations = SearchHelper.FindMatchedLocations(text, subText);
            string display = TestFormatMatchedLocations(matchedLocations);

            Assert.AreEqual(display, "No Matches");
        }
         [TestMethod]
        public void Set4NumericMatchesSearchInput()
        {
            string text = "11111";
            string subText = "11";
            text = text.ToLower();
            subText = subText.ToLower();
            List<int> matchedLocations = SearchHelper.FindMatchedLocations(text, subText);
            string display = TestFormatMatchedLocations(matchedLocations);

            Assert.AreEqual(display, "1, 2, 3, 4");
        }

         [TestMethod]
         public void SetSpacesMatchesSearchInput()
         {
             string text = "11 11 11 11 ";
             string subText = "11";
             text = text.ToLower();
             subText = subText.ToLower();
             List<int> matchedLocations = SearchHelper.FindMatchedLocations(text, subText);
             string display = TestFormatMatchedLocations(matchedLocations);

             Assert.AreEqual(display, "1, 4, 7, 10");
         }
         [TestMethod]
         public void SetFirstLastCharSameMatchesSearchInput()
         {
             string text = "abetbatbet";
             string subText = "bet";
             text = text.ToLower();
             subText = subText.ToLower();
             List<int> matchedLocations = SearchHelper.FindMatchedLocations(text, subText);
             string display = TestFormatMatchedLocations(matchedLocations);

             Assert.AreEqual(display, "2, 8");
         }


        #region private
         private string TestFormatMatchedLocations(List<int> matchedLocations)
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
                 return outputLocations.ToString();
             }
             else
             {
                 return "No Matches";
             }
         }
#endregion

    }

   
}
