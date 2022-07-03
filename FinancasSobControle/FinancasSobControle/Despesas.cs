using System;

namespace FinancasSobControle
{
    public class Despesas
    {
        public DateTime data { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public string formaPag { get; set; }
        public string parcela { get; set; }
        public DateTime vencimento { get; set; }
        public string classificacao { get; set; }
        public string especificacao { get; set; }
        public string comentario { get; set; }

        public Despesas(DateTime data, string descricao, decimal valor, string formaPag, string parcela, DateTime vencimento, string classficacao, string especificacao, string comentario)
        {
            this.data = data;
            this.descricao = descricao;
            this.valor = valor;
            this.formaPag = formaPag;
            this.parcela = parcela;
            this.vencimento = vencimento;
            this.classificacao = classficacao;
            this.especificacao = especificacao;
            this.comentario = comentario;
        } 
    }
}

