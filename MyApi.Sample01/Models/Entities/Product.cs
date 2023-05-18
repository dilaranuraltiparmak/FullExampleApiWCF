using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Sample01.Models.Entities
{
    public class Product:IEntity
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        //public int MyProperty { get; set; }
    }
}
