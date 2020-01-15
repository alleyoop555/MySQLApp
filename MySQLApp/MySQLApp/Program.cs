using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQLApp
{
    class Program
    {
        static char option;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("請選擇: (1) 登入  (2) 申請帳號\n");
                Console.Write("您的選擇: ");
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '1':
                        string id; string password;
                        Console.Write("\n請輸入您的帳號: ");
                        id = Console.ReadLine();
                        Console.Write("請輸入您的密碼: ");
                        password = Console.ReadLine();
                        Console.Write("\n");
                        var signIn = new SignIn(id, password);
                        if (signIn.Pass)
                        {
                            // 進行指令輸入 (顯示資料庫中所有表單)
                            break;
                        }
                        else
                        {
                            Console.WriteLine("請重新輸入您的帳號及密碼或申請帳號");
                            break;
                        }

                    case '2':
                        Console.WriteLine("\n暫代");
                        Console.Write("\n");
                        break;

                    default:
                        Console.WriteLine("\n輸入無效，請輸入數字1或2");
                        Console.Write("\n");
                        break;
                }
            }
        }
    }
}
