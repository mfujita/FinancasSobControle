using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasSobControle
{
    class Extrato
    {
        public DateTime dataCompra { get; set; }
        public string local { get; set; }
        public decimal valor { get; set; }
        public string formaPag { get; set; }
        public string parcela { get; set; }
        public DateTime dataVencimento { get; set; }
        //public string dataVencimento;
        public string classificacao { get; set; }
        public string especificacao { get; set; }
        public string comentario { get; set; }
        public string indice { get; set; }

        public Extrato(DateTime DTdataCompra, string Slocal, decimal Dvalor, string SformaPag, string Sparcela, DateTime DTdataVencimento, string Sclassificacao, string Sespecificacao, string Scomentario, string sIndice)
        //public Extrato(DateTime DTdataCompra, string Slocal, decimal Dvalor, string SformaPag, string Sparcela, string DTdataVencimento, string Sclassificacao, string Sespecificacao, string Scomentario, string sIndice)
        {
            dataCompra = DTdataCompra;
            local = Slocal;
            valor = Dvalor;
            formaPag = SformaPag;
            parcela = Sparcela;
            dataVencimento = DTdataVencimento;
            classificacao = Sclassificacao;
            especificacao = Sespecificacao;
            comentario = Scomentario;
            indice = sIndice;
        }
    }
}
