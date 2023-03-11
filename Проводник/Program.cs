using System.Diagnostics;

namespace Проводник
{
    internal class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine("  " + drive + " " + drive.TotalSize + " свободно байт из " + drive.AvailableFreeSpace);
            }
            Navigation Menu = new Navigation(drives.Length);
            Menu.Draw(0);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Menu.DownMove();
                        break;
                    case ConsoleKey.UpArrow:
                        Menu.UpMove();
                        break;
                    case ConsoleKey.Enter:
                        ShowDirectory(drives[Menu.position].RootDirectory);
                        break;
                }
            }
        }

        static void ShowDirectory(DirectoryInfo root)
        {
            FileSystemInfo[] fileinfo = root.GetFileSystemInfos();
            Console.SetCursorPosition(0, 0);
            foreach (var info in fileinfo)
            {
                Console.WriteLine("  " + info);
            }
            Navigation Menu = new Navigation(fileinfo.Length);
            Menu.Draw(0);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Menu.DownMove();
                        break;
                    case ConsoleKey.UpArrow:
                        Menu.UpMove();
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo info = fileinfo[Menu.position];
                        if (info is DirectoryInfo directory)
                        {
                            Console.Clear();
                            GowDirectory(directory);
                        }
                        else
                        {
                            Process.Start(info.FullName);
                        }
                        break;
                    case ConsoleKey.Escape:
                        string path = root.FullName;
                        Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        Console.WriteLine("  " + path);
                        break;
                }
            }
        }
        static void GowDirectory(DirectoryInfo root)
        {
            FileSystemInfo[] inf = root.GetFileSystemInfos();
            Console.SetCursorPosition(0, 0);
            foreach (var info in inf)
            {
                Console.WriteLine("  " + info);
            }
            Navigation MenuNavigation = new Navigation(inf.Length);
            MenuNavigation.Draw(0);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        MenuNavigation.DownMove();
                        break;
                    case ConsoleKey.UpArrow:
                        MenuNavigation.UpMove();
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo info = inf[MenuNavigation.position];
                        if (info is DirectoryInfo directory)
                        {
                            GowDirectory(directory);
                        }
                        else
                        {
                            Process.Start(info.FullName);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Main();
                        break;
                }

            }
        }
    }
}