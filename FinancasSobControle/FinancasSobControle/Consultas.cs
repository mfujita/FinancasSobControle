using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancasSobControle
{
    public partial class Consultas : Form
    {
        Size dim;
        TextBox txtMes;
        TextBox txtAno;
        public static string mes;
        public static string ano;
        public static Consultas instancia;
        private MovimentacaoBancaria movimentacaoBancaria = null;

        public Consultas(MovimentacaoBancaria mb)
        {
            InitializeComponent();
            movimentacaoBancaria = mb;
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            dim = new Size(Screen.PrimaryScreen.Bounds.Width * 20 / 100, Screen.PrimaryScreen.WorkingArea.Height * 20 / 100);
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - dim.Width,
                Screen.PrimaryScreen.WorkingArea.Height * 20 / 100);
        }

        public void DesenhaComponentes(string opcao)
        {
            switch (opcao)
            {
                case "fatura":
                    Text = "Cartão de crédito";
                    txtMes = new TextBox();
                    Controls.Add(txtMes);
                    txtMes.Name = "txtMes";
                    txtMes.Text = "Mês";
                    txtMes.Font = new Font("Microsoft Sans Serif", 12F);
                    txtMes.Width = dim.Width * 40 / 100;
                    txtMes.Location = new Point((dim.Width - txtMes.Width) / 2, txtMes.Height);
                    txtMes.Enter += TxtMes_Enter;
                    txtMes.Leave += TxtMes_Leave;
                    txtMes.KeyPress += TxtMes_KeyPress;

                    txtAno = new TextBox();
                    Controls.Add(txtAno);
                    txtAno.Text = "Ano";
                    txtAno.Name = "txtAno";
                    txtAno.Font = new Font("Microsoft Sans Serif", 12F);
                    txtAno.Width = txtMes.Width;
                    txtAno.Location = new Point((dim.Width - txtAno.Width) / 2, txtMes.Bottom + txtMes.Height);
                    txtAno.Enter += TxtAno_Enter;
                    txtAno.Leave += TxtAno_Leave;
                    txtAno.KeyPress += TxtAno_KeyPress;

                    Button btnConfirmar = new Button();
                    Controls.Add(btnConfirmar);
                    btnConfirmar.Text = "Confirmar";
                    btnConfirmar.Font = new Font("Microsoft Sans Serif", 12F);
                    Size tamanho = TextRenderer.MeasureText(btnConfirmar.Text, btnConfirmar.Font);
                    btnConfirmar.Size = new Size(tamanho.Width + 10, tamanho.Height + 5);
                    btnConfirmar.Location = new Point((dim.Width - btnConfirmar.Width) / 2, txtAno.Bottom + txtAno.Height);
                    btnConfirmar.Click += BtnConfirmar_Click;

                    //Instruções para facilitar o preenchimento de campos para analisar cartão de crédito
                    Utilidade utilidade = new Utilidade();
                    txtMes.Text = utilidade.GetMes();
                    txtAno.Text = utilidade.GetAno();
                    break;
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e) 
        {
            //http://pt.stackoverflow.com/questions/3035/como-fazer-form-filho-alterar-valores-no-form-pai-c
            //O form MovimentacaBancaria chamou o form Consultas, coletou informações e exibiu o resultado no form MovimentacaoBancaria
            mes = txtMes.Text;
            if (Convert.ToInt32(mes) < 10)
                mes = mes.PadLeft(2, '0');
            ano = txtAno.Text;
            movimentacaoBancaria.ListaFaturaCartaoCredito();
            Close();
        }


        private void TxtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TxtAno_Leave(object sender, EventArgs e)
        {
            if (txtAno.Text.Equals(""))
                txtAno.Text = "Ano";
        }

        private void TxtAno_Enter(object sender, EventArgs e)
        {
            txtAno.Text = "";
        }

        private void TxtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TxtMes_Leave(object sender, EventArgs e)
        {
            if (txtMes.Text.Equals(""))
                txtMes.Text = "Mês";
        }

        private void TxtMes_Enter(object sender, EventArgs e)
        {
            txtMes.Text = "";
        }
    }
}
