using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;

namespace KillProcessByName
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Process p = Process.Start("msedge", "-inprivate --process-per-tab");
            //p.WaitForInputIdle();
            //IntPtr h = p.MainWindowHandle;
            //KillHelper.SetForegroundWindow(h);
            ////SendKeys.SendWait("k");
            //SendKeys.Send("^{v}");

            KillHelper.killProcess("chrome");
            //var wrap = new ChromeWrapper();
            //wrap.SendKey('%');
        }
    }

    public class ChromeWrapper
    {
        // you might as well use those methods from your helper class
        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr point);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        // the keystroke signals. you can look them up at the msdn pages
        private static uint WM_KEYDOWN = 0x100, WM_KEYUP = 0x101;

        //// the reference to the chrome process
        //private Process chromeProcess;

        //public ChromeWrapper(string url)
        //{
        //    // i'm using the process class as it gives you the MainWindowHandle by default
        //    chromeProcess = new Process();
        //    chromeProcess.StartInfo = new ProcessStartInfo("chrome.exe", url);
        //    chromeProcess.Start();
        //}

        public void SendKey(char key)
        {
            var chromeProcesses = Process.GetProcesses().Where(x => x.ProcessName.ToLower().Contains("chrome") );

            foreach (var chromeProcess in chromeProcesses)
            {
                if (chromeProcess.MainWindowHandle != IntPtr.Zero)
                {
                    // send the keydown signal
                    SendMessage(chromeProcess.MainWindowHandle, ChromeWrapper.WM_KEYDOWN, (IntPtr)key, IntPtr.Zero);

                    // give the process some time to "realize" the keystroke
                    System.Threading.Thread.Sleep(100);

                    // send the keyup signal
                    SendMessage(chromeProcess.MainWindowHandle, ChromeWrapper.WM_KEYUP, (IntPtr)key, IntPtr.Zero);
                }
            }
        }
    }

    public class KillHelper
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool CloseWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        public static void killProcess(string processName)
        {
            var proc = Process.GetProcesses().Where(x => x.ProcessName.ToLower().Contains(processName.ToLower()));

            foreach (Process prs in proc)
            {
                //if (prs.MainWindowHandle != IntPtr.Zero)
                {
                    Console.WriteLine($"ProcessId:{prs.Id} MainHandle:{prs.MainWindowHandle}");
                }
                if (WmiTest(prs.Id))
                {
                    //prs.Kill();
                    Console.WriteLine("criteria met");
                    //To test SendKeys, not working, but gives you the idea
                    //SetForegroundWindow(prs.MainWindowHandle);
                    //SendKeys.SendWait("%{F4}");
                    //int iHandle = FindWindow("Notepad", "Untitled - Notepad");    
                    //if (iHandle > 0)
                    //{
                    //    SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
                    //} 
                    //SendKeys.Send("%({F4})");
                    //SendMessage(prs.MainWindowHandle.ToInt32(), WM_SYSCOMMAND, SC_CLOSE, 0);
                    CloseWindow(prs.Handle);
                }
            }
        }

        private static bool WmiTest(int processId)
        {
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(
                       $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {processId}"))
                foreach (ManagementObject mo in mos.Get())
                {
                    //Console.WriteLine($"ProcessId:{processId} Commandline:{mo["CommandLine"].ToString()}");
                    if (mo["CommandLine"].ToString().Contains("--disable-databases"))
                        return true;
                }
            return false;
        }
    }
}
