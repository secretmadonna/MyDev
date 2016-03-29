using MyDev.Common;
using MyDev.Common.PartnerApi.Tencent;
using MyDev.Common.PartnerApi.Tencent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.UserInterface.Test.TestClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TenHelper.GetAccessToken());

            Console.ReadKey();
        }
    }
}
