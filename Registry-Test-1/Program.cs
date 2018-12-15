using System;
using System.IO;
using Microsoft.Win32;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey rKey = Registry.CurrentUser.CreateSubKey(@"Software\Fuck");
            String Data = rKey.GetValue("Data").ToString();
        }
    }
}


