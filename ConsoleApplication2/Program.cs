using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(args.ToString());
            StringBuilder sb = new StringBuilder();
            foreach(string s in args){
                sb.AppendLine(s);
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
