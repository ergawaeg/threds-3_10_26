using System.Diagnostics;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread Notepad = new Thread(() =>
            {
                Console.WriteLine("[Поток 1] Запуск потока");
                Console.WriteLine("[Поток 1] Запуск Notepad");
                Process notepad = Process.Start("notepad.exe");
                Console.WriteLine("[Поток 1] Ожидание завершения Notepad...");
                Thread.Sleep(3000);
                notepad.CloseMainWindow();
            });
            Thread Cmd = new Thread(() =>
            {
                Console.WriteLine("[Поток 2] Запуск потока");
                Console.WriteLine("[Поток 2] Запуск cmd");
                Process cmd = Process.Start("cmd.exe", "/c dir");
                Console.WriteLine("[Поток 2] "/*, cmd.StandardOutput.ReadToEnd()*/);
            });
            Notepad.Start();
            Cmd.Start();
        }
    }
}
