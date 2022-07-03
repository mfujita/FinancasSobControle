using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinancasSobControle
{
    class Utilidade
    {
        //private string mes;
        //private string ano;

        //public int getMes(int Mes)
        //{
        //    return mes;
        //}
        //public int getAno(int Ano)
        //{
        //    return ano;
        //}

        public DateTime Texto2Data(string textoData)
        {
            char[] dataToChar = textoData.ToCharArray();

            int posicaoBarra1 = textoData.IndexOf('/');
            int posicaoBarra2 = textoData.LastIndexOf('/');

            string dia = "";
            for (int i = 0; i < posicaoBarra1; i++)
            {
                dia += dataToChar[i];
            }
            if (dia.Equals(""))
            {
                dia = DateTime.MinValue.Day.ToString();
            }
            else if (Convert.ToInt16(dia) < 10)
                dia = dia.PadLeft(2, '0');
            

            string mes = "";
            for (int i = posicaoBarra1 + 1; i < posicaoBarra2; i++)
            {
                mes += dataToChar[i];
            }
            if (mes.Equals(""))
            {
                mes = DateTime.MinValue.Month.ToString();
            }
            else if (Convert.ToInt16(mes) < 10)
                mes = mes.PadLeft(2, '0');

            try
            {
                string ano = textoData.Substring(posicaoBarra2 + 1);
                return DateTime.Parse(ano + "-" + mes + "-" + dia);
            }
            catch
            {
                return DateTime.Parse("0001-" + mes + "-" + dia);
            }
        }

        public bool VerificaFormatoData(string datas)
        {
            bool condicao = false;
            char[] dataChar = datas.ToCharArray();
            int qtdeBarras = 0;
            int posBarra1 = datas.IndexOf('/');
            int posBarra2 = datas.LastIndexOf('/');
            string sDia="", sMes="", sAno="";
            int dia=0, mes=0, ano=0;
            for (int i = 0; i < dataChar.Length; i++)
            {
                if(dataChar[i].Equals('/'))
                {
                    qtdeBarras++;
                }
            }

            if (qtdeBarras ==2)
            {
                for (int i = 0; i < posBarra1; i++)
                {
                    sDia += dataChar[i];
                }
                dia = Convert.ToInt32(sDia);

                for (int i = posBarra1+1; i < posBarra2; i++)
                {
                    sMes += dataChar[i];
                }
                mes = Convert.ToInt32(sMes);

                for (int i = posBarra2+1; i < dataChar.Length; i++)
                {
                    sAno += dataChar[i];
                }
                ano = Convert.ToInt32(sAno);

                if ((dia > 0 && dia < 32) && (mes > 0 && mes < 13) && ano > 2016)
                    condicao = true;
            }
            else
                condicao = false;

            return condicao;
        }

        /// <summary>
        /// Obtém o número de linhas do arquivo ControleFinanceiro.txt para usar como índice do registro
        /// </summary>
        /// <returns></returns>
        public int NumeroRegistroTxt()
        {
            int registro = 0;
            StreamReader sr = new StreamReader("ControleFinanceiro.txt");
            while (sr.ReadLine() != null)
            {
                registro++;
            }
            sr.Close();

            return registro;
        }

        /// <summary>
        /// Encontra a linha que tem o índice do registro do arquivo ControleFinanceiro.txt e modifica de acordo com a alteração no dataGridView
        /// </summary>
        /// <param name="registro"></param>
        public void AtualizaRegistroArquivoTxt(string cd, string place, string val, string fp, string parc, string venc, string clas, string esp, string com, string registro)
        {
            string[] todoTexto = File.ReadAllLines("ControleFinanceiro.txt");

            File.Delete("ControleFinanceiro.txt");

            FileStream fs = new FileStream("ControleFinanceiro.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            foreach (string linha in todoTexto)
            {
                string[] dado = linha.Split('|');
                if (!dado[9].Equals(registro))
                {
                    sw.WriteLine(dado[0] + "|" + dado[1] + "|" + dado[2] + "|" + dado[3] + "|" + dado[4] + "|" + dado[5] + "|" + dado[6] + "|" + dado[7] + "|" + dado[8] + "|" + dado[9] + "|");
                }
                else
                {
                    sw.WriteLine(cd + "|" + place + "|" + val + "|" + fp + "|" + parc + "|" + venc + "|" + clas + "|" + esp + "|" + com + "|" + registro + "|");
                }
            }
            sw.Close();
            fs.Close();
        }

        public string GetMes()
        {
            int mes = DateTime.Now.Month;
            if (mes < 12)
                mes = DateTime.Now.Month + 1;
            else
                mes = 1;
            return mes.ToString();
        }

        public string GetAno()
        {
            int mes = DateTime.Now.Month;
            int ano = 0;
            if (mes < 12)
                ano = DateTime.Now.Year;
            else
                ano = DateTime.Now.Year + 1;
            return ano.ToString();
        }
    }
}
