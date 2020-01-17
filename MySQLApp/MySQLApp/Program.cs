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
                Console.WriteLine("\n請選擇: (1) 登入  (2) 申請帳號\n");
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

                        // 實體化連線物件
                        var signIn = new SignIn(id, password);
                        if (signIn.Pass)
                        {
                            Console.WriteLine("登入成功");
                            // 實體化命令物件
                            var cmd = new Command(signIn.connection);
                            // 選取表單
                            Console.Write("請選擇您要顯示的表單: ");
                            cmd.getTables();
                            int idx = 1;
                            cmd.tableName.ForEach(delegate(string name)
                            {
                                Console.Write("(" + idx + ")" + name + " ");
                                idx += 1;
                            });
                            option = Console.ReadKey().KeyChar;
                            signIn.connection.Close();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("請重新輸入您的帳號及密碼或申請帳號\n");
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
