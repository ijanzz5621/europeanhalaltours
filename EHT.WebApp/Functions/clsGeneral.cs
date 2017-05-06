using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHT.WebApp.Functions
{
    public class clsGeneral
    {
        public static string CreateRandomCode(int Size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            Random rand = new Random();
            char ch;
            for (int i = 0; i < Size; i++)
            {
                ch = input[rand.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
