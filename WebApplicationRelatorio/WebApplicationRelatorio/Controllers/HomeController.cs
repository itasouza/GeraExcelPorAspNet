using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationRelatorio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //================================================================
       public class Precificacao
        {
            public Precificacao() { }
            public string Nome { get; set; }
            public string Valor { get; set; }

            public Precificacao(string nome, string valor)
            {
                this.Nome = nome;
                this.Valor = valor;
            }

        }


        public ActionResult Reports(string ReportType)
        {

            List<Precificacao> registros;

            registros = new List<Precificacao>();
            registros.Add(new Precificacao("itamar", "12345"));
            registros.Add(new Precificacao("itamar", "12345"));
            registros.Add(new Precificacao("itamar", "12345"));
            registros.Add(new Precificacao("itamar", "12345"));
            registros.Add(new Precificacao("itamar", "12345"));


            LocalReport localreport = new LocalReport();
            //nome do relatório Dataset
            localreport.ReportPath = Server.MapPath("~/Reports/Precificacao.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSetPrecificacao";
            reportDataSource.Value = registros;
            localreport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;
            if (reportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            else if (reportType == "Word")
            {
                fileNameExtension = "docx";
            }
            else if (reportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "jpg";
            }

            string[] streams;
            Warning[] warning;
            byte[] renderedByte;
            renderedByte = localreport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warning);
            Response.AddHeader("content-disposition", "attachment;filename=relatorio_teste." + fileNameExtension);
            return File(renderedByte, fileNameExtension);

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