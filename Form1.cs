using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeetCodeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int[] intArrayResult;
            bool boolResult;
            int intResult;
            //Two Sum
            //int[] src = new int[6] { 1, 2, 3, 4, 5, 6 };
            //intArrayResult = this.TwoSum(src, 6);

            //Palindrome Number
            //boolResult = IsPalindrome(12345);

            //Roman to Integer
            //I             1
            //V             5
            //X             10
            //L             50
            //C             100
            //D             500
            //M             1000

            //intResult = RomanToInt("MCMXCIV");
            intResult = RomanToInt("III");
            bool finish = true;
        }

        private int RomanToInt(string s)
        {
            int rev = 0;
            
            Dictionary<string, int> mappingDictionary = new Dictionary<string, int>();
            mappingDictionary.Add("I", 1);
            mappingDictionary.Add("V", 5); 
            mappingDictionary.Add("X", 10); 
            mappingDictionary.Add("L", 50); 
            mappingDictionary.Add("C", 100);
            mappingDictionary.Add("D", 500);
            mappingDictionary.Add("M", 1000);
            string currentSymbol;
            int i = 0;
            while (i < s.Length)
            {
                int currentValue = 0;
                int nextValue = 0;
                string nextSymbol;
                currentSymbol = s.Substring(i, 1);
                currentValue = mappingDictionary[currentSymbol];
                if (i < s.Length -1)
                {
                    nextSymbol = s.Substring(i + 1, 1);
                    nextValue = mappingDictionary[nextSymbol];

                    if (currentValue < nextValue)
                    {
                        currentValue = nextValue - currentValue;
                        i++;
                    }

                }

                rev += currentValue;
                i++;
            }
            return rev;
        }
        private bool IsPalindrome(int x)
        {

            if (x < 0 || (x != 0 && x % 10 == 0))
            {
                return false;
            }


            string str = x.ToString();
            int middle = str.Length / 2;
            int length = str.Length;
            int index = 0;
            for (int i = 0; i < middle; i++)
            {
                index = length - i - 1;
                if (str.Substring(i, 1) != str.Substring(index, 1))
                {
                    return false;
                }
            }


            return true;
        }

        private int[] TwoSum(int[] nums, int target)
        {
            int len = nums.Length;
            
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
    }
}
