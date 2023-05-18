using Microsoft.AspNetCore.Mvc;
using MyApi.MyUI.ApiProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.MyUI.Controllers
{
    public class UrunController : Controller
    {
        DenemeApiProvider _servisBaglantiClass;
        public UrunController(DenemeApiProvider servisBaglantiClass)
        {
            _servisBaglantiClass = servisBaglantiClass;
        }
        //http://localhost:60147/api/deneme
        public async  Task<IActionResult> Index()
        {
            var apidenGelenSonucKumesi= await _servisBaglantiClass.VerileriGetir();
            return View(apidenGelenSonucKumesi);
        }
    }
}
