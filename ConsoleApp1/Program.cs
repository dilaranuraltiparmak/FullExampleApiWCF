﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();
          
            var hede= service.UrunleriGetir();


        }
    }
}
