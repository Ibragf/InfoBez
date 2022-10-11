using System;
using System.Diagnostics;
using System.Text;

namespace BruteForce
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ввод количества потоков: ");
            int threadCount = 1;
            bool flag=int.TryParse(Console.ReadLine(), out threadCount);
            while(!flag || threadCount<1)
            { 
                Console.Write("Ввод количества потоков(целое число): ");
                flag = int.TryParse(Console.ReadLine(), out threadCount);
            }
            Info.ThreadsCount = threadCount;
            Info.InitialThreadsCount = threadCount;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            byte[] buffer;

            using (FileStream fs = new FileStream("hash256.txt", FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.ReadAsync(buffer, 0, buffer.Length);
            }
            
            string hash256=Encoding.UTF8.GetString(buffer);
            string[] passwords=hash256.Split('\n');
            for (int i = 0; i < passwords.Length; i++)
            {
                passwords[i] = passwords[i].Replace("\r", "");
            }

            List<Hash256BruteForce> bruteForceList = new List<Hash256BruteForce>(3);
            List<Hash256BruteForce> listWithPassword=new List<Hash256BruteForce>(3);
            foreach (string password in passwords)
            {
                Hash256BruteForce bruteForce = new Hash256BruteForce(password);
                bruteForceList.Add(bruteForce);
            }

            if(Info.ThreadsCount<5)
            {
                foreach (var bruteforce in bruteForceList)
                {
                    bruteforce.Start();
                }
            }
            else
            {
                while (bruteForceList.Where(x => x.isMatched==false).FirstOrDefault()!=null)
                {
                    if (Info.ThreadsCount > 4 && bruteForceList.Count>0)
                    {
                        Info.ThreadsCount--;
                        Thread thread = new Thread(bruteForceList[0].Start);
                        listWithPassword.Add(bruteForceList[0]);
                        bruteForceList.RemoveAt(0);
                        thread.Start();
                    }
                }
            }

            while(listWithPassword.Where(x => x.isMatched==false).FirstOrDefault()!=null)
            {

            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            string time = string.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds/10);
            Console.WriteLine("Затраченное время: " + time);
        }
    }
}