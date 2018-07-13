using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionsTest
{
    class Program
    {

        static void Main(string[] args)
        {
            //基于角色的安全性
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string str = windowsIdentity.Name;
            WindowsPrincipal principal = new WindowsPrincipal(windowsIdentity);
            Thread.CurrentPrincipal = principal;
            ATest();

            CodeAccessPermission p = new FileIOPermission(FileIOPermissionAccess.Read,@"E:\");
            p.PermitOnly();
            File.OpenWrite(@"E:\a.txt").Close();


            Console.Read();

        }

        [PrincipalPermission(SecurityAction.Demand, Name = @"MicroWin10-2332\Administrator")]
        public static void ATest()
        {
            Console.WriteLine("Permission Admin！");
        }

    }
}
