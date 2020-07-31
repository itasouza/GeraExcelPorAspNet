using System;

namespace GeraExcelPorAspNet.Models
{
    public class EstacionarViewModel
    {
        public Guid Id { get; set; }
        public decimal ValorHora { get; set; }
        public int NumeroVaga { get; set; }
        public string PlacaVeiculo { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public decimal ValorDevido { get; set; }
        public string TempoDecorrido { get; set; }
        public bool Ativo { get; set; }
    }
}