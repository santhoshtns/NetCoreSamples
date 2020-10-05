using System;
using System.Diagnostics;

namespace StartProc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Process!");

            using (Process myProcess = new Process())
            {
                //myProcess.StartInfo.UseShellExecute = false;
                // You can start any process, HelloWorld is a do-nothing example.
                var startInfo = new ProcessStartInfo();
                myProcess.StartInfo = startInfo;
                startInfo.FileName = "dotnet.exe";
                startInfo.Arguments = "bin\\Debug\\netcoreapp3.1\\Chinsay.ContractManager.Api.dll --environment=Development";
                startInfo.WorkingDirectory = "D:\\Git31\\Chinsay.ContractManager.Api";
                startInfo.CreateNoWindow = false;
                myProcess.Start();
                myProcess.MaxWorkingSet = new IntPtr(214572800);
                // This code assumes the process you are starting will terminate itself.
                // Given that is is started without a window so you cannot terminate it
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
            }
        }
    }
}
