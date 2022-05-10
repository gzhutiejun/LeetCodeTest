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


            //Two Sum
            //int[] src = new int[6] { 1, 2, 3, 4, 5, 6 };
            //int[] result = this.TwoSum(src, 6);

            //Palindrome Number
            //bool result = IsPalindrome(12345);

            //Roman to Integer
            //I             1
            //V             5
            //X             10
            //L             50
            //C             100
            //D             500
            //M             1000

            //int result = RomanToInt("MCMXCIV");
            //int result = RomanToInt("III");

            //Implement Stack using Queues
            MyStack myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            int topValue = myStack.Top();
            textBox1.Text += "Top:" + topValue.ToString() + Environment.NewLine;
            topValue = myStack.Pop();
            myStack.Push(4);
            topValue = myStack.Pop();
            textBox1.Text += "Top:" + topValue.ToString() + Environment.NewLine;

            bool finish = true;
        }

        public class Node
        {
            public Node Previous;
            public int Data;

        }

        public class MyStack
        {

            private Node topNode = null;
            private int size = 0;

            public MyStack()
            {
                this.topNode = null;
                this.size = 0;
            }

            public void Push(int x)
            {
                Node node = new Node();
                node.Data = x;
                node.Previous = this.topNode;
                this.topNode = node;
                this.size += 1;
            }

            public int Pop()
            {
                if (this.topNode != null)
                {
                    Node temp = this.topNode;
                    this.topNode = temp.Previous;
                    this.size -= 1;
                    return temp.Data;
                }
                else
                {
                    return int.MaxValue;
                }
            }

            public int Top()
            {
                if (this.topNode != null)
                {
                    return this.topNode.Data;
                }
                else
                {
                    return int.MaxValue;
                }
            }

            public bool Empty()
            {
                if (this.size > 0)
                    return false;
                else
                    return true;
            }
        }

        public int RomanToInt(string s)
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
        public bool IsPalindrome(int x)
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

        public int[] TwoSum(int[] nums, int target)
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
