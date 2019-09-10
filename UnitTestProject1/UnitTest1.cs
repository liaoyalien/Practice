using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        public bool CheckPairSum(int[] arr, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsValue(target - arr[i]))
                {
                    return true;
                }
                dict.Add(i + 1, arr[i]);
            }
            return false;

        }

        static string findNumber(List<int> arr, int k)
        {

            if (arr.Any(x => x == k)) return "YES";


            return "NO";
        }

        public List<string> missing(string s, string t)
        {
         
            string[] wholeS = s.Split(' ');
            string[] partialS = t.Split(' ');
            var result = new List<string>();
            foreach (var item in partialS)
            {                
                var index = Array.IndexOf(wholeS, item);

                for(int i = 0; i< index; i++)
                {
                    result.Add(wholeS[i]);
                }

                wholeS = wholeS.Skip(index+1).ToArray();
            }
            result.AddRange(wholeS);
            return result;
            //foreach (string item in wholeS)
            //{

            //    if(!partialS.Any(x => x.Equals(item)))
            //    {
            //       result.Add(item);
            //    }
            //}

        }

        public int GetMostVisited(int n, List<int> sprints)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < sprints.Count - 1; i++)
            {
                int from;
                int to;
                if (sprints[i] > sprints[i + 1])
                {
                    to = sprints[i];
                    from = sprints[i + 1];
                }
                else
                {
                    from = sprints[i];
                    to = sprints[i + 1];
                }
          
                for (int j = from ; j <= to; j++)
                {
                    if (dict.ContainsKey(j))
                    {
                        dict[j]++;
                    }
                    else
                    {
                        dict.Add(j, 1);
                    }
                }
            }
            var max = from x in dict where x.Value == dict.Max(v => v.Value) select x.Key;
            return max.Min();
        }
        /// <summary>
        /// 回傳出現最多次的數字
        /// </summary>
        /// <returns></returns>
        public int GroupByPractice()
        {
            List<int> list = new List<int>
            {
                1,
                2,
                2,
                2,
                3,
                4,
                5,
                5,
                5
            };

            var query = list.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
          
            return query;
        }

        public int getMostVisited2(int n, List<int> sprints)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> list = new List<int>();
            for (int i = 0; i < sprints.Count - 1; i++)
            {
                int from;
                int to;
                if (sprints[i] > sprints[i + 1])
                {
                    to = sprints[i];
                    from = sprints[i + 1];
                }
                else
                {
                    from = sprints[i];
                    to = sprints[i + 1];
                }
                list.AddRange(Enumerable.Range(from, to).ToList());

            }

            //var list2 = list.GroupBy(i => i).Select(x => new
            //{
            //    id = x.Key,
            //    qty = x.Count()
            //}).ToList();


            var most = (from i in list
                group i by i into grp
                orderby grp.Count() descending
                select grp.Key).OrderBy(x => x).First();

            return most;
        }


        public long RepeatedString(string s, long n)
        {

            var count = s.Count(x => x == 'a');
            var charactersLeft = n % s.Length;
            var numOfcharactersLeft = 0;
            if (charactersLeft > 0)
            {
                numOfcharactersLeft = s.Substring(0, (int)charactersLeft).Count(x => x == 'a');
            }
            var test = n / s.Length;
             var result = count * test + numOfcharactersLeft;

            return result;
        }

        public string winner(List<int> andrea, List<int> maria, string s)
        {
            int aScore = 0;
    
                int start = s.Equals("Even") ? 0 : 1;
                for (int i = start; i < andrea.Count; i += 2)
                {
                    aScore = aScore + (andrea[i] - maria[i]);
                }
       

            return aScore == 0 ? "Tie": aScore> 0? "Andrea" : "Maria";
        }

        int longestPalSubstr(string str)
        {
            int maxLength = 1; // The result (length of LPS) 

            int start = 0;
            int len = str.Length;

            int low, high;

            // One by one consider every  
            // character as center point 
            // of even and length palindromes  
            for (int i = 1; i < len; ++i)
            {
                // Find the longest even length  
                // palindrome with center points  
                // as i-1 and i.  
                low = i - 1;
                high = i;
                while (low >= 0 && high < len &&
                       str[low] == str[high])
                {
                    if (high - low + 1 > maxLength)
                    {
                        start = low;
                        maxLength = high - low + 1;
                    }
                    --low;
                    ++high;
                }

                // Find the longest odd length  
                // palindrome with center point as i  
                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < len &&
                       str[low] == str[high])
                {
                    if (high - low + 1 > maxLength)
                    {
                        start = low;
                        maxLength = high - low + 1;
                    }
                    --low;
                    ++high;
                }
            }



            return maxLength;

        }


        [TestMethod]
        public void TestMethod2()
        {
            var test = GroupByPractice();


            //var result = getMostVisited2(10, new List<int>
            //{
            //     7,9,3,1
            //});

            //var test = winner(new List<int>
            //{
            //    1,
            //    2,
            //    3
            //}, new List<int>
            //{
            //    2,
            //    1,
            //    3
            //}, "Even");
            //var result = missing("I am milian liao", "milian");
            //var result = getMostVisited(10, new List<int>
            //{
            //     1,5
            //});
        }

        [TestMethod]
        public void TestMethod3()
        {
            var hashSet = new HashSet<object>();
        }
    }
}
