using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace FinancasSobControle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] leituraDados;
            leituraDados = File.ReadAllLines(@"D:\desenvolvimento\Financas\FinancasSobControle\FinancasSobControle\bin\Debug\ControleFinanceiro.txt");

            DateTime data;
            string descricao; 
            decimal valor;
            string formaPag; 
            string parcela;
            DateTime vencimento;
            string classificacao;
            string especificacao;
            string comentario;
            List<Despesas> myList = new List<Despesas>();

            /*
0 data da compra
1 descrição do local do gasto
2 valor
3 forma de pagamento
4 parcelas
5 data vencimento do cartão do crédito
6 classificação
7 especificacao
8 comentário
*/
            foreach (var item in leituraDados)
            {
                string[] linhas = item.Split(new char[] { '|' });
                string diaCompra, mesCompra, anoCompra;
                diaCompra = linhas[0].Substring(0, 2);
                mesCompra = linhas[0].Substring(3, 2);
                anoCompra = linhas[0].Substring(6, 4);
                data = DateTime.Parse(anoCompra + "-" + mesCompra + "-" + diaCompra);
                descricao = linhas[1];
                valor = decimal.Parse(linhas[2]);
                formaPag = linhas[3];
                parcela = linhas[4];
                if (linhas[5] != "")
                {
                    string diaVencimento, mesVencimento, anoVencimento;
                    diaVencimento = linhas[5].Substring(0, 2);
                    mesVencimento = linhas[5].Substring(3, 2);
                    anoVencimento = linhas[5].Substring(6, 4);
                    vencimento = DateTime.Parse(anoVencimento + "-" + mesVencimento + "-" + diaVencimento);
                }
                else
                {
                    vencimento = DateTime.MinValue;
                }
                classificacao = linhas[6];
                especificacao = linhas[7];
                comentario = linhas[8];

                Despesas desp = new Despesas(data, descricao, valor, formaPag, parcela, vencimento, classificacao, especificacao, comentario);
                myList.Add(desp);
            }
            Relatorio rel = new Relatorio(myList);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            CultureInfo ci = new CultureInfo("pt-BR");

            Console.WriteLine("1. Extrato geral");
            Console.WriteLine("2. Extrato despesas geral");
            Console.WriteLine("3. Extrato mês/ano cartão do crédito");
            Console.WriteLine("4. Extrato débitos");
            Console.WriteLine("5. Extrato entre datas");
            Console.WriteLine("6. Extrato de contas futuras");
            Console.WriteLine("7. Extrato débito entre datas");
            Console.WriteLine("8. Separa por categorias e entre datas");
            Console.WriteLine("9. Depósito identificado");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    rel.Extrato(ci);
                    break;
                case "2":
                    rel.ExtratoDespesas(ci);
                    break;
                case "3":
                    Console.Write("Digite o número do mês: ");
                    string mes = Console.ReadLine();
                    if (int.Parse(mes) < 10)
                        mes = mes.PadLeft(2, '0');
                    Console.Write("Digite o ano: ");
                    string ano = Console.ReadLine();
                    rel.FaturaCartaoCredito(ci, mes, ano);
                    break;
                case "4":
                    rel.ExtratoDebito(ci);
                    break;
                case "5": 
                    Console.Write("Digite a data inicial: ");
                    string dataInicial = Console.ReadLine();
                    DateTime inicial = new DateTime(int.Parse(dataInicial.Substring(6, 4)), int.Parse(dataInicial.Substring(3, 2)), int.Parse(dataInicial.Substring(0, 2)));
                    Console.Write("Digite a data final: ");
                    string dataFinal = Console.ReadLine();
                    DateTime final = new DateTime(int.Parse(dataFinal.Substring(6, 4)), int.Parse(dataFinal.Substring(3, 2)), int.Parse(dataFinal.Substring(0, 2)));
                    rel.ExtratoEntreDatas(ci, inicial, final);
                    break;
                case "6":
                    rel.ContasFuturas(ci);
                    break;
                case "7":
                    Console.Write("Digite a data inicial: ");
                    dataInicial = Console.ReadLine();
                    inicial = new DateTime(int.Parse(dataInicial.Substring(6, 4)), int.Parse(dataInicial.Substring(3, 2)), int.Parse(dataInicial.Substring(0, 2)));
                    Console.Write("Digite a data final: ");
                    dataFinal = Console.ReadLine();
                    final = new DateTime(int.Parse(dataFinal.Substring(6, 4)), int.Parse(dataFinal.Substring(3, 2)), int.Parse(dataFinal.Substring(0, 2)));
                    rel.ExtratoDebitoEntreDatas(ci, inicial, final);
                    break;
                case "8":
                    Console.Write("Digite a data inicial: ");
                    dataInicial = Console.ReadLine();
                    inicial = new DateTime(int.Parse(dataInicial.Substring(6, 4)), int.Parse(dataInicial.Substring(3, 2)), int.Parse(dataInicial.Substring(0, 2)));
                    Console.Write("Digite a data final: ");
                    dataFinal = Console.ReadLine();
                    final = new DateTime(int.Parse(dataFinal.Substring(6, 4)), int.Parse(dataFinal.Substring(3, 2)), int.Parse(dataFinal.Substring(0, 2)));
                    rel.SeparaPorCategoriaData(ci, inicial, final);
                    //for (int i = 1; i <= 12; i++)
                    //{
                    //    if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                    //        rel.SeparaPorCategoriaData(ci, new DateTime(2018, i, 01), new DateTime(2018, i, 31));
                    //    else if (i == 4 || i == 6 || i == 9 || i == 11)
                    //        rel.SeparaPorCategoriaData(ci, new DateTime(2018, i, 01), new DateTime(2018, i, 30));
                    //    else
                    //        rel.SeparaPorCategoriaData(ci, new DateTime(2018, i, 01), new DateTime(2018, i, 28));
                    //}
                    break;
                case "9":
                    Console.WriteLine("Identifique o nome:");
                    string nome = Console.ReadLine();
                    Console.Write("Digite a data inicial: ");
                    dataInicial = Console.ReadLine();
                    inicial = new DateTime(int.Parse(dataInicial.Substring(6, 4)), int.Parse(dataInicial.Substring(3, 2)), int.Parse(dataInicial.Substring(0, 2)));
                    Console.Write("Digite a data final: ");
                    dataFinal = Console.ReadLine();
                    final = new DateTime(int.Parse(dataFinal.Substring(6, 4)), int.Parse(dataFinal.Substring(3, 2)), int.Parse(dataFinal.Substring(0, 2)));
                    rel.DepositoNome(ci, nome, inicial, final);
                    break;
                default:
                    break;
            }
        }
    }
}
