using MyApi.Sample01.DAL.Interfaces;
using MyApi.Sample01.Models;
using MyApi.Sample01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Sample01.DAL.Concrete
{
    public class EfProductRepoBaseDAL:EfRepoBase<Product,MyContext>,IProductDAL
    {
    }
}
