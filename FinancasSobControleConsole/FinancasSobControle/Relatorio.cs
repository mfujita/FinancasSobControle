using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;

namespace FinancasSobControle
{
    public class Relatorio
    {
        public List<Despesas> myDespesas {
            get;
            set;
        }

        public Relatorio(List<Despesas> myList)
        {
            myDespesas = myList;
        }

        public void Extrato(CultureInfo ci)
        {
            decimal total = 0;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            var ordemData = myDespesas.OrderBy(p => p.data);
            int[] tam = CalculaTamanhoDescricao(ordemData);

            foreach (var item in ordemData)
            {
                if (item.vencimento.Equals(DateTime.MinValue))
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        null, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                }
                else
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        item.vencimento.ToShortDateString().ToString(ci), //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);                    
                }
                total += item.valor;
            }
            Console.WriteLine("Total: {0,53}", total);
        }

        public void ExtratoDespesas(CultureInfo ci)
        {
            var ordemData = myDespesas.OrderBy(p => p.data);
            int[] tam = CalculaTamanhoDescricao(ordemData);
            decimal total = 0;

            foreach (var item in ordemData)
            {
                if (item.valor < 0)
                {                
                    if (item.vencimento.Equals(DateTime.MinValue))
                    {
                        Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                            item.descricao, //1
                            item.valor, //2
                            item.formaPag, //3
                            item.parcela, //4
                            null, //5
                            item.classificacao.Trim(), //6
                            item.especificacao, //7
                            item.comentario); //8);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                            item.descricao, //1
                            item.valor, //2
                            item.formaPag, //3
                            item.parcela, //4
                            item.vencimento.ToShortDateString().ToString(ci), //5
                            item.classificacao.Trim(), //6
                            item.especificacao, //7
                            item.comentario); //8);                    
                    }
                    total += item.valor;
                }
            }
            Console.WriteLine("Total: {0,53:C}", total);
        }

        public IEnumerable<Despesas> FaturaCartaoCredito(CultureInfo ci, string mes, string ano)
        {
            decimal total = 0;

            IEnumerable<Despesas> next = myDespesas.OrderBy(p => p.data).Where(p => p.vencimento.ToShortDateString().Equals("10/"+mes+"/"+ano));
            int[] tam = CalculaTamanhoDescricao(next);

            foreach (var item in next)
            {
                Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, " + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "} {8,-" + tam[8] + "}", item.data.ToShortDateString().ToString(ci), 
                    item.descricao, //1
                    item.valor, //2
                    item.formaPag, //3
                    item.parcela, //4
                    item.vencimento.ToShortDateString().ToString(ci), //5
                    item.classificacao.Trim(), //6
                    item.especificacao, //7
                    item.comentario); //8);
                total += item.valor;
            }
            Console.WriteLine("Total: {0,"+(tam[0]+tam[1]+2) +"}", total);
            Console.WriteLine();

            //ImprimeHTML(next, tam, ci);
            Console.WriteLine();
            return next;
        }

        public void ExtratoDebito(CultureInfo ci)
        {
            decimal total = 0;
            var debitos = myDespesas.Where(p => p.formaPag.Equals("Débito"));
            int[] tam = CalculaTamanhoDescricao(debitos);

            foreach (var item in debitos)
            {
                if (item.vencimento.Equals(DateTime.MinValue))
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, " + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        null, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                }
                else
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, " + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        item.vencimento, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                }
                total += item.valor;
            }
            Console.WriteLine("Total: {0,"+(tam[1]+13) +"}", total);
            Console.WriteLine();
        }

        public void ExtratoEntreDatas(CultureInfo ci, DateTime inicial, DateTime final)
        {
            decimal total = 0;
            var entreDatas = myDespesas.OrderBy(p => p.data).Where(p => p.data >= inicial && p.data <= final);
            int[] tam = CalculaTamanhoDescricao(entreDatas);

            foreach (var item in entreDatas) 
            {
                if (item.vencimento.Equals(DateTime.MinValue))
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        null, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                }
                else
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        item.vencimento.ToShortDateString().ToString(ci), //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                }
                total += item.valor;          
            }
            Console.WriteLine("Total: {0,"+(tam[0]+tam[1]+tam[2]-5)+"}", total);
            Console.WriteLine();
        }

        public void ExtratoDebitoEntreDatas(CultureInfo ci, DateTime inicial, DateTime final)
        {
            decimal total = 0;
            var debitos = myDespesas.Where(p => p.formaPag.Equals("Débito") && p.data >= inicial && p.data <= final).OrderBy(p => p.data);
            int[] tam = CalculaTamanhoDescricao(debitos);

            foreach (var item in debitos)
            {
                if (item.vencimento.Equals(DateTime.MinValue))
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        null, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                }
                else
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        item.vencimento, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                }
                total += item.valor;
            }
            Console.WriteLine("Total: {0,"+(tam[1]+13) +"}", total);
            Console.WriteLine();
            ImprimeHTMLDebitosEntreDatas(debitos, tam, ci);
        }

        public void SeparaPorCategoriaData(CultureInfo ci, DateTime inicial, DateTime final)
        {
            decimal total = 0;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            //var categoriaData = myDespesas.Where(p => p.classificacao.Equals("Alimentação") && p.data >= inicial && p.data <= final).OrderBy(p => p.data);
            //int[] tam = CalculaTamanhoDescricao(categoriaData);
            //tam[5] = 0;
            //Console.WriteLine("Habitação " + inicial.ToShortDateString() + " - " + final.ToShortDateString());
            //foreach (var item in categoriaData)
            //{
            //        Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
            //            item.descricao, //1
            //            item.valor, //2
            //            item.formaPag, //3
            //            item.parcela, //4
            //            null, //5
            //            item.classificacao.Trim(), //6
            //            item.especificacao, //7
            //            item.comentario); //8);
            //    total += item.valor;
            //}
            //Console.WriteLine("{0, " + (12 + tam[1] + tam[2]) + "}\n", total);
            //total = 0;

            List<string> listaCategorias = new List<string> { "Alimentação", "Habitação", "Educação", "Transporte", "Tributos", "Diversão", "Pessoal", "Saúde" };

            foreach (var categoria in listaCategorias)
            {
                var categoriaData = myDespesas.Where(p => p.classificacao.Equals(categoria) && p.data >= inicial && p.data <= final).OrderBy(p => p.data);
                int[] tam = CalculaTamanhoDescricao(categoriaData);
                tam[5] = 0;
                Console.WriteLine(categoria + " " + inicial.ToShortDateString() + " - " + final.ToShortDateString());
                foreach (var item in categoriaData)
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        null, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
                    total += item.valor;
                }
                Console.WriteLine("{0, " + (12 + tam[1] + tam[2]) + "}\n", total);
                total = 0;
            }

            

            //categoriaData = myDespesas.Where(p => p.classificacao.Equals("Habitação") && p.data >= inicial && p.data <= final).OrderBy(p => p.data);
            //tam = CalculaTamanhoDescricao(categoriaData);
            //tam[5] = 0;
            //Console.WriteLine("Saúde " + inicial.ToShortDateString() + " - " + final.ToShortDateString());
            //foreach (var item in categoriaData)
            //{
            //    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
            //        item.descricao, //1
            //        item.valor, //2
            //        item.formaPag, //3
            //        item.parcela, //4
            //        null, //5
            //        item.classificacao.Trim(), //6
            //        item.especificacao, //7
            //        item.comentario); //8);
            //    total += item.valor;
            //}
            //Console.WriteLine("{0, " + (12 + tam[1] + tam[2]) + "}\n", total);
            //total = 0;

            //categoriaData = myDespesas.Where(p => p.classificacao.Equals("Educação") && p.data >= inicial && p.data <= final).OrderBy(p => p.data);
            //tam = CalculaTamanhoDescricao(categoriaData);
            //tam[5] = 0;
            //Console.WriteLine("Supermercado " + inicial.ToShortDateString() + " - " + final.ToShortDateString());
            //foreach (var item in categoriaData)
            //{
            //    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
            //        item.descricao, //1
            //        item.valor, //2
            //        item.formaPag, //3
            //        item.parcela, //4
            //        null, //5
            //        item.classificacao.Trim(), //6
            //        item.especificacao, //7
            //        item.comentario); //8);
            //    total += item.valor;
            //}
            //Console.WriteLine("{0, " + (12 + tam[1] + tam[2]) + "}\n", total);
            //total = 0;

            //categoriaData = myDespesas.Where(p => p.classificacao.Equals("Transporte") && p.data >= inicial && p.data <= final).OrderBy(p => p.data);
            //tam = CalculaTamanhoDescricao(categoriaData);
            //tam[5] = 0;
            //Console.WriteLine("Combustível " + inicial.ToShortDateString() + " - " + final.ToShortDateString());
            //foreach (var item in categoriaData)
            //{
            //    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
            //        item.descricao, //1
            //        item.valor, //2
            //        item.formaPag, //3
            //        item.parcela, //4
            //        null, //5
            //        item.classificacao.Trim(), //6
            //        item.especificacao, //7
            //        item.comentario); //8);
            //    total += item.valor;
            //}
            //Console.WriteLine("{0, " + (12 + tam[1] + tam[2]) + "}\n", total);

            //total = 0;
            //categoriaData = myDespesas.Where(p => p.classificacao.Equals("Tributos") && p.data >= inicial && p.data <= final).OrderBy(p => p.data);
            //tam = CalculaTamanhoDescricao(categoriaData);
            //tam[5] = 0;
            //Console.WriteLine("Lanchonete " + inicial.ToShortDateString() + " - " + final.ToShortDateString());
            //foreach (var item in categoriaData)
            //{
            //    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, -" + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
            //        item.descricao, //1
            //        item.valor, //2
            //        item.formaPag, //3
            //        item.parcela, //4
            //        null, //5
            //        item.classificacao.Trim(), //6
            //        item.especificacao, //7
            //        item.comentario); //8);
            //    total += item.valor;
            //}
            //Console.WriteLine("{0, " + (12 + tam[1] + tam[2]) + "}\n", total);
        }

        public void DepositoNome(CultureInfo ci, string nome, DateTime inicial, DateTime final)
        {
            var deposito = myDespesas.Where(p => p.classificacao.Equals("Receita") && 
            p.descricao.Contains(nome) && p.data >= inicial && 
            p.data <= final).OrderBy(p => p.data);
            int[] tam = CalculaTamanhoDescricao(deposito);

            foreach (var item in deposito)
            {
                Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {5," + tam[5] + "}  {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        null, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);
            }
        }

        private int[] CalculaTamanhoDescricao(IEnumerable<Despesas> listagem)
        {
            int[] maiorTamanho = new int[9];
            maiorTamanho[0] = 10;
            maiorTamanho[3] = 7;
            maiorTamanho[5] = 10;

            foreach (var item in listagem)
            {
                if (item.descricao.Length > maiorTamanho[1])
                {
                    maiorTamanho[1] = item.descricao.Length;
                }
                if (item.valor.ToString().Length > maiorTamanho[2])
                {
                    maiorTamanho[2] = item.valor.ToString().Length;
                }
                if (item.parcela.Length > maiorTamanho[4])
                {
                    maiorTamanho[4] = item.parcela.Length;
                }
                if (item.classificacao.Length > maiorTamanho[6])
                {
                    maiorTamanho[6] = item.classificacao.Length;
                }
                if (item.especificacao.Length > maiorTamanho[7])
                {
                    maiorTamanho[7] = item.especificacao.Length;
                }
                if (item.comentario.Length > maiorTamanho[8])
                {
                    maiorTamanho[8] = item.comentario.Length;
                }
            }

            return maiorTamanho;
        }


        private void ImprimeHTML(IEnumerable<Despesas> listagem, int[] tam, CultureInfo ci)
        {
            decimal total = 0;
            Console.WriteLine("<html>");
            Console.WriteLine("<body>");
            Console.WriteLine(" <head>");
            Console.WriteLine("  <meta charset=UTF-8>");
            Console.WriteLine("  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            Console.WriteLine(" </head>");
            Console.WriteLine("<style>");
            Console.WriteLine("body {");
            Console.WriteLine("  font: Arial;");
            Console.WriteLine("}");
            Console.WriteLine("tr:nth-child(even) {");
            Console.WriteLine("  background-color:#ffff00");
            Console.WriteLine("}");
            Console.WriteLine("</style>");
            Console.WriteLine("<table border=1>");
//            Console.WriteLine("<tr><th>Data</th><th>Local</th><th>Valor</th><th>Pagamento</th><th>Parcelas</th><th>Vencimento</th><th>Classificação</th><th>Especificação</th><th>Comentário</th></tr>");
            Console.WriteLine("<tr><th>Data</th><th>Local</th><th>Valor</th><th>Parcelas</th><th>Classificação</th><th>Especificação</th><th>Comentário</th></tr>");
            foreach (var item in listagem)
            {
//                Console.WriteLine("<tr><td>{0}</td><td>{1,-"+tam[1]+"}</td><td>{2,"+tam[2]+"}</td><td>{3,-"+tam[3]+"}</td><td>{4,-"+tam[4]+"}</td><td>{5,-"+tam[5]+"}</td><td>{6,-"+tam[6]+"}</td><td>{7,-"+tam[7]+"}</td><td>{8,"+-tam[8]+"}</td></tr>", item.data.ToShortDateString().ToString(ci), 
//                    item.descricao, //1
//                    item.valor, //2
//                    item.formaPag, //3
//                    item.parcela, //4
//                    item.vencimento.ToShortDateString().Replace("01/01/0001",""), //6
//                    item.classificacao.Trim(), //5
//                    item.especificacao,
//                    item.comentario); //7);
//                total += item.valor;
                Console.WriteLine("<tr><td>{0}</td><td>{1,-"+tam[1]+"}</td><td width=60; align=right>{2,"+tam[2]+"}<td>{4,-"+tam[4]+"}</td><td>{6,-"+tam[6]+"}</td><td>{7,-"+tam[7]+"}</td><td>{8,"+-tam[8]+"}</td></tr>", item.data.ToShortDateString().ToString(ci), 
                    item.descricao, //1
                    item.valor, //2
                    item.formaPag, //3
                    item.parcela, //4
                    item.vencimento.ToShortDateString().Replace("01/01/0001",""), //6
                    item.classificacao.Trim(), //5
                    item.especificacao,
                    item.comentario); //7);
                total += item.valor;

            }
            Console.WriteLine("<tr><td colspan=2>Total</td><td colspan=7>"+total+"</td></tr>");
            Console.WriteLine("</table>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }

        private void ImprimeHTMLDebitosEntreDatas(IEnumerable<Despesas> listagem, int[] tam, CultureInfo ci)
        {
            decimal total = 0;
            Console.WriteLine("<meta charset=UTF-8>");
            Console.WriteLine("<style>");
            Console.WriteLine("tr:nth-child(even) {");
            Console.WriteLine("  background-color:#ffff00");
            Console.WriteLine("}");
            Console.WriteLine("</style>");
            Console.WriteLine("<table border=1>");
            Console.WriteLine("<tr><th>Data</th><th>Local</th><th>Valor</th><th>Classificação</th><th>Especificação</th><th>Comentário</th></tr>");

            foreach (var item in listagem)
            {
                Console.WriteLine("<tr><td>{0}</td><td>{1,-"+tam[1]+"}</td><td align=right>{2,"+tam[2]+"}<td>{6,-"+tam[6]+"}</td><td>{7,-"+tam[7]+"}</td><td>{8,"+-tam[8]+"}</td></tr>", item.data.ToShortDateString().ToString(ci), 
                    item.descricao, //1
                    item.valor, //2
                    item.formaPag, //3
                    item.parcela, //4
                    item.vencimento.ToShortDateString().Replace("01/01/0001",""), //6
                    item.classificacao.Trim(), //5
                    item.especificacao,
                    item.comentario); //7);
                total += item.valor;

            }
            Console.WriteLine("<tr><td colspan=2>Total</td><td colspan=7>"+total+"</td></tr>");
            Console.WriteLine("</table>");
        }

        /// <summary>
        /// Levanta tanto créditos como débitos futuros
        /// </summary>
        public void ContasFuturas(CultureInfo ci)
        {
            decimal total = 0;
            int ano = Convert.ToInt32(DateTime.Now.Year);
            int mes = Convert.ToInt32(DateTime.Now.Month);

            Console.Write("Considerar as contas deste mês ("+mes+"/"+DateTime.Now.Year+")? (s/n): ");
            string simNao = Console.ReadLine().ToLower();
            IEnumerable<Despesas> contasFuturas = null;
            if (simNao == "s")
            {
                contasFuturas = myDespesas.OrderBy(x => x.data).Where(x => x.vencimento > DateTime.Now || x.data > DateTime.Now);
            }
            else
            {
                if (DateTime.Now.Day <= 25)
                    mes = Convert.ToInt32(DateTime.Now.Month);
                else
                    mes = Convert.ToInt32(DateTime.Now.Month +1);
                contasFuturas = myDespesas.OrderBy(x => x.data).Where(x => x.vencimento.Year == ano && x.vencimento.Month > mes ||
                x.vencimento.Year > DateTime.Now.Year || x.data > DateTime.Now);
            }

            int[] tam = CalculaTamanhoDescricao(contasFuturas);

            foreach (var item in contasFuturas)
            {
                if (item.formaPag == "Débito")
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, " + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci), 
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        null, //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);                        
                }
                else
                {
                    Console.WriteLine("{0} {1,-" + tam[1] + "} {2," + tam[2] + "} {3, " + tam[3] + "} {4," + tam[4] + "} {5," + tam[5] + "} {6,-" + tam[6] + "}  {7,-" + tam[7] + "}  {8}", item.data.ToShortDateString().ToString(ci),
                        item.descricao, //1
                        item.valor, //2
                        item.formaPag, //3
                        item.parcela, //4
                        item.vencimento.ToShortDateString().ToString(ci), //5
                        item.classificacao.Trim(), //6
                        item.especificacao, //7
                        item.comentario); //8);                        
                }
                total += item.valor;
            }

            Console.WriteLine("Total: {0,"+(tam[0]+tam[1]+tam[2]-5)+"}", total);
            ImprimeHTML(contasFuturas, tam, ci);            
        }
    }
}

