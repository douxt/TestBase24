using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;

namespace TestBase24
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("请选择服务器：1-PVP,2-X");
            string type = System.Console.ReadLine();
            int num;
            if (type.Equals("1"))
            {
                num = 0;
            }
            else if (type.Equals("2"))
            {
                num = 1;
            }
            else
            {
                System.Console.WriteLine("类型不对!");
                return;
            }

            while (true)
            {


                System.Console.WriteLine("请输入小凡币金额：");
                string input = System.Console.ReadLine();

                Random rd = new Random();
                int rand = rd.Next(10000, 99999);

                input = "Coin:" + input + ":" + rand;

                int sum = 0;
                foreach (char c in input)
                {
                    sum += (int)c;
                }

                sum += num;
                sum = sum % 100;
                input = input + ":" + sum;


                byte[] data = new byte[input.Length];
                int j = 0;
                foreach (char c in input)
                {
                    data[j++] = (byte)c;
                }

                string text = Base24Encoding.Default.GetString(data);
                text = text.TrimStart(Base24Encoding.DefaultMap[0]);
                text = text.PadLeft(25, Base24Encoding.DefaultMap[0]);
                for (int i = text.Length - 5; i > 0; i -= 5)
                {
                    text = text.Insert(i, "-");
                }
                System.Console.WriteLine("/eve redeem " + text);

                string t = text.Replace("-", "");
                byte[] data2 = Base24Encoding.Default.GetBytes(t);
                String str = System.Text.Encoding.ASCII.GetString(data2);
                str = str.TrimStart('\0');
                System.Console.WriteLine('(' + str + ')');
            }

            
            

        }
    }
}
