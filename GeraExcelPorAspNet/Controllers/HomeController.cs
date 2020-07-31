using GeraExcelPorAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeraExcelPorAspNet.Controllers
{
    public class HomeController : Controller
    {
        AppEstacionamentoEntities db = new AppEstacionamentoEntities();

        public ActionResult Index()
        {

            List<EstacionarViewModel> lista = db.Estacionars.Select(x => new EstacionarViewModel
            {
                Id = x.Id,
                ModeloVeiculo = x.ModeloVeiculo
            }).ToList();

            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}