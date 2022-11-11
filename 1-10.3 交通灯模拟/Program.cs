using System;
using System.Threading;

namespace _1_10._3_交通灯模拟
{// 为状态机做铺垫
    enum 信号灯
    {
        无,
        红,
        绿,
        黄,
    }

    class Program
    {
        static void Simple()
        {
            while (true)
            {
                Console.Clear();    // 清空再打印
                Console.WriteLine("绿灯");
                // 等待3秒
                Thread.Sleep(3000);

                Console.Clear();
                Console.WriteLine("黄灯");
                // 等待0.4秒
                Thread.Sleep(400);

                Console.Clear();
                Console.WriteLine("红灯");
                // 等待3秒
                Thread.Sleep(3000);
            }
        }



        static void Main(string[] args)
        {
            信号灯 state = 信号灯.无;
            int time = 0;

            int red_time = 30;
            // 状态，状态切换
            while (true)
            {
                switch (state)
                {
                    case 信号灯.红:
                        {
                            Console.Clear();
                            Console.WriteLine($"红灯  总时间：{red_time}");
                            time--;
                            if (time == 0)
                            {
                                state = 信号灯.绿;
                                time = 30;        // 30帧代表三秒
                            }
                        }
                        break;
                    case 信号灯.绿:
                        {
                            Console.Clear();
                            Console.WriteLine("绿灯");
                            time--;
                            if(time == 0)
                            {
                                state = 信号灯.黄;
                                time = 4;  // 4帧代表0.4秒
                            }
                        }
                        break;
                    case 信号灯.黄:
                        {
                            Console.Clear();
                            Console.WriteLine("黄灯");
                            time--;
                            if (time == 0)
                            {
                                state = 信号灯.红;
                                time = red_time;  
                            }
                        }
                        break;
                    default:
                        {
                            state = 信号灯.红;
                            time = red_time;  // 30帧
                        }
                        break;

                }
                while(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        red_time++;
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        red_time--;
                    }
                }
                Thread.Sleep(100);
                
            }

        }
    }
}
