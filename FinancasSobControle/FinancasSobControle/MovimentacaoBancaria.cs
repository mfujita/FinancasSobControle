using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FinancasSobControle
{
    public partial class MovimentacaoBancaria : Form
    {
        public int alturaLabel { get; set; }
        List<Extrato> myExtrato { get; set; }

        public MovimentacaoBancaria()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tabFinancas.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            tabFinancas.Location = new Point(0, 0);
            panelLancamentos.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 10, Screen.PrimaryScreen.WorkingArea.Height - 100);
            panelLancamentos.Location = new Point(0, 0);
            panelLancamentos.BorderStyle = BorderStyle.FixedSingle;

            //Posicionamento dos cabeçalhos (Data da compra, local, ...)
            Size alturaLabel = TextRenderer.MeasureText(lblFormaPag.Text, new Font("Microsoft Sans Serif", 12));
            //int alturaLabel = 17;
            lblDataCompra.Size = new Size(panelLancamentos.Width * 7 / 100, alturaLabel.Height);
            lblLocal.Size = new Size(panelLancamentos.Width * 17 / 100, alturaLabel.Height);
            lblValor.Size = new Size(panelLancamentos.Width * 5 / 100, alturaLabel.Height);
            lblFormaPag.Size = new Size(panelLancamentos.Width * 7 / 100, alturaLabel.Height);
            lblVencimento.Size = new Size(panelLancamentos.Width * 7 / 100, alturaLabel.Height);
            lblParcela.Size = new Size(panelLancamentos.Width * 4 / 100, alturaLabel.Height);
            lblClassificacao.Size = new Size(panelLancamentos.Width * 8 / 100, alturaLabel.Height);
            lblEspecificacao.Size = new Size(panelLancamentos.Width * 9 / 100, alturaLabel.Height);
            lblComentario.Size = new Size(panelLancamentos.Width * 21 / 100, alturaLabel.Height);

            lblDataCompra.AutoSize = false;
            lblLocal.AutoSize = false;
            lblValor.AutoSize = false;
            lblFormaPag.AutoSize = false;
            lblParcela.AutoSize = false;
            lblVencimento.AutoSize = false;
            lblClassificacao.AutoSize = false;
            lblEspecificacao.AutoSize = false;
            lblComentario.AutoSize = false;

            //lblDataCompra.BorderStyle = BorderStyle.FixedSingle;
            //lblLocal.BorderStyle = BorderStyle.FixedSingle;
            //lblValor.BorderStyle = BorderStyle.FixedSingle;
            //lblFormaPag.BorderStyle = BorderStyle.FixedSingle;
            //lblParcela.BorderStyle = BorderStyle.FixedSingle;
            //lblClassificacao.BorderStyle = BorderStyle.FixedSingle;
            //lblComentario.BorderStyle = BorderStyle.FixedSingle;

            lblDataCompra.Location = new Point(0, 0);
            lblLocal.Location = new Point(lblDataCompra.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);
            lblValor.Location = new Point(lblLocal.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);
            lblFormaPag.Location = new Point(lblValor.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);
            lblParcela.Location = new Point(lblFormaPag.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);
            lblVencimento.Location = new Point(lblParcela.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);
            lblClassificacao.Location = new Point(lblVencimento.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);
            lblEspecificacao.Location = new Point(lblClassificacao.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);
            lblComentario.Location = new Point(lblEspecificacao.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100);

            //alturaTextbox = lblDataCompra.Bottom + lblDataCompra.Height;
            txtDataCompra.Location = new Point(lblDataCompra.Left, alturaLabel.Height);
            txtLocal.Location = new Point(lblLocal.Left, alturaLabel.Height);
            txtValor.Location = new Point(lblValor.Left, alturaLabel.Height);
            cbFormaPag.Location = new Point(lblFormaPag.Left, alturaLabel.Height);
            txtParcela.Location = new Point(lblParcela.Left, alturaLabel.Height);
            txtVencimento.Location = new Point(lblVencimento.Left, alturaLabel.Height);
            cbClassificacao.Location = new Point(lblClassificacao.Left, alturaLabel.Height);
            cbEspecificacao.Location = new Point(lblEspecificacao.Left, alturaLabel.Height);
            txtComentario.Location = new Point(lblComentario.Left, alturaLabel.Height);

            txtDataCompra.Width = lblDataCompra.Width;
            txtLocal.Width = lblLocal.Width;
            txtValor.Width = lblValor.Width;
            cbFormaPag.Width = lblFormaPag.Width;
            txtParcela.Width = lblParcela.Width;
            txtVencimento.Width = lblVencimento.Width;
            cbClassificacao.Width = lblClassificacao.Width;
            cbEspecificacao.Width = lblEspecificacao.Width;
            txtComentario.Width = lblComentario.Width;

            txtDataCompra.Tag = "DataCompra1";
            txtLocal.Tag = "Local1";
            txtValor.Tag = "Valor1";
            cbFormaPag.Tag = "FormaPag1";
            txtParcela.Tag = "Parcela1";
            txtVencimento.Tag = "Vencimento1";
            cbClassificacao.Tag = "Classificacao1";
            cbEspecificacao.Tag = "Especificacao1";
            txtComentario.Tag = "Comentario1";

            cbFormaPag.Items.Add("Crédito");
            cbFormaPag.Items.Add("Débito");

            //Evento de txtDataCompra
            txtDataCompra.KeyPress += TxtDataCompra_KeyPress;

            //Evento de cbClassificacao
            cbClassificacao.SelectedIndexChanged += CbClassificacao_SelectedIndexChanged;

            //Evento de txtValor
            txtValor.KeyPress += TxtValor_KeyPress;

            ItensClassificacao(cbClassificacao);

            //botões Acrescentar e remover linhas
            btnAdd.Location = new Point(txtComentario.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100, alturaLabel.Height);
            btnRemover.Location = new Point(btnAdd.Right + Screen.PrimaryScreen.WorkingArea.Width * 1 / 100, alturaLabel.Height);

            //btmLimpar
            btnLimpar.Location = new Point(panelLancamentos.Left, panelLancamentos.Bottom + 10);
            btnLimpar.Font = new Font("Microsoft Sans Serif", 10F);
            tabLancamentos.Controls.Add(btnLimpar);

            //btnSalvar.Text = "Salvar";
            btnSalvar.Location = new Point(btnAdd.Left, panelLancamentos.Bottom + 10);
            btnSalvar.Font = new Font("Microsoft Sans Serif", 10F);
            tabLancamentos.Controls.Add(btnSalvar);

            dgvExtrato.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 10, Screen.PrimaryScreen.WorkingArea.Height * 8 / 10);
            dgvExtrato.Location = new Point(1, Screen.PrimaryScreen.WorkingArea.Height * 1 / 10);
            cdata.Width = Screen.PrimaryScreen.WorkingArea.Width * 7 / 100;
            cLocal.Width = Screen.PrimaryScreen.WorkingArea.Width * 19 / 100;
            cValor.Width = Screen.PrimaryScreen.WorkingArea.Width * 5 / 100;
            cFormPag.Width = Screen.PrimaryScreen.WorkingArea.Width * 8 / 100;
            cParcela.Width = Screen.PrimaryScreen.WorkingArea.Width * 4 / 100;
            cVencimento.Width = Screen.PrimaryScreen.WorkingArea.Width * 7 / 100;
            cClassificacao.Width = Screen.PrimaryScreen.WorkingArea.Width * 8 / 100;
            cEspecificacao.Width = Screen.PrimaryScreen.WorkingArea.Width * 8 / 100; 
            cComentario.Width = Screen.PrimaryScreen.WorkingArea.Width * 30 / 100;

            //Evento para gerar o degradê na aba Lançamentos
            panelLancamentos.Paint += PanelLancamentos_Paint;

            //txtDataCompra.Text = "30/12/2017";
            //txtLocal.Text = "Local";
            //txtValor.Text = "-15,00";
            //cbFormaPag.Text = "Crédito"; 
            //txtParcela.Text = "1/1";
            //txtVencimento.Text = "10/01/2011";
            //cbClassificacao.Text = "Alimentação";
            //cbEspecificacao.Text = "Mercado";
            //txtComentario.Text = "Bolsa Família";

            if (!File.Exists("ControleFinanceiro.txt"))
            {
                FileStream fs = new FileStream("ControleFinanceiro.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Close();
            }


            //Aba Extrato
            lblExtrato_descricao.Text = "";

            menuStrip1.Paint += MenuStrip1_Paint;

            Button btnExtratoFimScroll = new Button();
            tabExtratos.Controls.Add(btnExtratoFimScroll);
            btnExtratoFimScroll.Text = "Última linha";
            btnExtratoFimScroll.Font = new Font("Microsoft Sans Serif", 12F);
            Size tamanhoTexto = TextRenderer.MeasureText(btnExtratoFimScroll.Text, btnExtratoFimScroll.Font);
            btnExtratoFimScroll.Size = new Size(tamanhoTexto.Width + 20, tamanhoTexto.Height + 5);
            btnExtratoFimScroll.Location = new Point(dgvExtrato.Right - btnExtratoFimScroll.Width, (dgvExtrato.Top-btnExtratoFimScroll.Height)/2);
            btnExtratoFimScroll.Click += BtnExtratoFimScroll_Click;

            myExtrato = new List<Extrato>();
            txtDataCompra.Focus();
            //tudo();
            LerArquivoTexto();

            txtDataCompra.PreviewKeyDown += TxtDataCompra_PreviewKeyDown;
            txtDataCompra.KeyDown += TxtDataCompra_KeyDown;
            txtDataCompra.PreviewKeyDown += TxtDataCompra_Colar;
            txtDataCompra.KeyDown += TxtDataCompra_Colar;
        }

        private void TxtDataCompra_Colar(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                e.IsInputKey = true;
            }
        }

        private void TxtDataCompra_Colar(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                txtDataCompra.Paste();
            }
        }

        private void TxtDataCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                txtDataCompra.Copy();
            }
        }

        private void TxtDataCompra_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                e.IsInputKey = true;
            }
        }

        private void MenuStrip1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(0, 0, menuStrip1.Width, menuStrip1.Height);
            LinearGradientBrush linear = new LinearGradientBrush(r, Color.LightBlue, Color.Blue, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(linear, r);
        }

        private void LerArquivoTexto()
        {
            int identificacao = 0;

            try
            {
                if (File.Exists("ControleFinanceiro.txt"))
                {
                    string[] todoTexto = File.ReadAllLines("ControleFinanceiro.txt");

                    foreach (var campo in todoTexto)
                    {
                        string[] linha = campo.Split('|');

                        Utilidade util = new Utilidade();
                        DateTime dCompra = util.Texto2Data(linha[0]);
                        DateTime dVencimento = util.Texto2Data(linha[5]);
                        identificacao =  Convert.ToInt32(linha[9])+1;

                        Extrato extrato = new Extrato(dCompra, linha[1], Convert.ToDecimal(linha[2]), linha[3], linha[4], dVencimento, linha[6], linha[7], linha[8], linha[9]);
                        myExtrato.Add(extrato);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veja a identificação " + identificacao + " do arquivo ControleFinanceiro.txt", "Aviso de erro!");
            }
        }

        private void BtnExtratoFimScroll_Click(object sender, EventArgs e)
        {
            //Vai para o extremo inferior da barra de rolagem
            dgvExtrato.FirstDisplayedScrollingRowIndex = dgvExtrato.RowCount - 1;
        }

        private void PanelLancamentos_Paint(object sender, PaintEventArgs e)
        {
            //https://social.msdn.microsoft.com/Forums/vstudio/pt-BR/0e0f6921-ba0f-4749-ab67-41d36a5a909a/gerar-smooth-gradient-degrad-suave?forum=vscsharppt
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(0, 0, panelLancamentos.Width, panelLancamentos.Height);
            LinearGradientBrush linear = new LinearGradientBrush(r, Color.LightBlue, Color.Blue, LinearGradientMode.ForwardDiagonal);
            e.Graphics.FillRectangle(linear, r);
        }

        //private bool checaDataCompra()
        //{
        //    foreach (Control)
        //}

        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 44 && e.KeyChar != 45 && e.KeyChar != 8)
                e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbClassificacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numero = ((ComboBox)sender).Tag.ToString().Replace("Classificacao","");

            //Apaga o combobox ESPECIFICAÇÃO de acordo com o combobox CLASSIFICAÇÂO
            foreach (Control item in panelLancamentos.Controls.OfType<ComboBox>())
            {
                if (item.Tag.ToString().Equals("Especificacao" + numero))
                {
                    item.Text = "";
                }
            }

            //Preenche uma nova listagem se modificar o combobox CLASSIFICAÇÂO
            foreach (Control item in panelLancamentos.Controls)
            {
                if (item is ComboBox && item.Tag.ToString().Equals("Especificacao" + numero))
                {
                    preencheComboboxEspecificacao((ComboBox)item, numero);
                }
            }
        }

/// <summary>
        /// cbEspecificacao é o nome do combobox que tem as especificações de cada classificação
        /// A variável escolha armazena o texto que escolhido no combobox cbClassificacao. Só então entra no switch
        /// </summary>
        /// <param name="cbEspecificacao"></param>
        /// <param name="numero"></param>
        private void preencheComboboxEspecificacao(ComboBox cbEspecificacao, string numero)
        {
            string escolha = "";
            foreach (Control item in panelLancamentos.Controls)
            {
                if (item is ComboBox && item.Tag.ToString().Equals("Classificacao" + numero))
                {
                    escolha = item.Text;
                }
            }

            switch (escolha)
            {
                case "Alimentação":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Supermercado");
                    cbEspecificacao.Items.Add("Padaria");
                    cbEspecificacao.Items.Add("Restaurante");
                    cbEspecificacao.Items.Add("Lanchonete");
                    cbEspecificacao.Items.Add("Bar");
                    cbEspecificacao.Items.Add("Feira");
                    break;
                case "Habitação":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Aluguel");
                    cbEspecificacao.Items.Add("Condomínio");
                    cbEspecificacao.Items.Add("Energia elétrica");
                    cbEspecificacao.Items.Add("Água");
                    cbEspecificacao.Items.Add("Gás");
                    cbEspecificacao.Items.Add("Internet");
                    cbEspecificacao.Items.Add("TV");
                    cbEspecificacao.Items.Add("Telefone");
                    cbEspecificacao.Items.Add("Financiamento");
                    cbEspecificacao.Items.Add("Itens para casa");
                    break;
                case "Educação":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Faculdade");
                    cbEspecificacao.Items.Add("Cursos");
                    cbEspecificacao.Items.Add("Material escolar");
                    cbEspecificacao.Items.Add("Babá");
                    break;
                case "Transporte":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Combustível");
                    cbEspecificacao.Items.Add("Seguro particular");
                    cbEspecificacao.Items.Add("Manutenção");
                    cbEspecificacao.Items.Add("Mobilidade");
                    cbEspecificacao.Items.Add("Vistoria");
                    break;
                case "Tributos":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Licenciamento");
                    cbEspecificacao.Items.Add("IPVA");
                    cbEspecificacao.Items.Add("IPTU");
                    break;
                case "Diversão":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Festa");
                    cbEspecificacao.Items.Add("Viagem");
                    break;
                case "Pessoal":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Telefone");
                    cbEspecificacao.Items.Add("Higiene");
                    cbEspecificacao.Items.Add("Vestuário");
                    cbEspecificacao.Items.Add("Calçado");
                    cbEspecificacao.Items.Add("Presentes");
                    cbEspecificacao.Items.Add("Estética");
                    break;
                case "Saúde":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Farmácia");
                    cbEspecificacao.Items.Add("Exame clínico");
                    cbEspecificacao.Items.Add("Plano de saúde");
                    cbEspecificacao.Items.Add("Médico");
                    cbEspecificacao.Items.Add("Dentista");
                    break;
                case "Receita":
                    cbEspecificacao.Items.Clear();
                    cbEspecificacao.Items.Add("Salário");
                    cbEspecificacao.Items.Add("Presente");
                    cbEspecificacao.Items.Add("Restituição Imposto de Renda");
                    cbEspecificacao.Items.Add("Ajuda financeira");
                    cbEspecificacao.Items.Add("Acerto de empréstimo");
                    cbEspecificacao.Items.Add("Caixa 2");
                    break;
                default: break;
            }
        }

        private void ItensClassificacao(ComboBox cbClassificacao)
        {
            //Lista do Combobox Classificação
            cbClassificacao.Items.Add("Alimentação");
            cbClassificacao.Items.Add("Habitação");
            cbClassificacao.Items.Add("Educação");
            cbClassificacao.Items.Add("Transporte");
            cbClassificacao.Items.Add("Tributos");
            cbClassificacao.Items.Add("Diversão");
            cbClassificacao.Items.Add("Pessoal");
            cbClassificacao.Items.Add("Saúde");
            cbClassificacao.Items.Add("Receita");
        }

        private void TxtDataCompra_KeyPress(object sender, KeyPressEventArgs e) // Permite números e backspace no campo txtDataCompra
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 47 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) //Adiciona campos
        {
            txtDataCompra = new TextBox();
            txtLocal = new TextBox();
            txtValor = new TextBox();
            cbFormaPag = new ComboBox();
            txtParcela = new TextBox();
            txtVencimento = new TextBox();
            cbClassificacao = new ComboBox();
            cbEspecificacao = new ComboBox();
            txtComentario = new TextBox();

            AdicionaNovaLinha(txtDataCompra, txtLocal, txtValor, cbFormaPag, txtParcela, txtVencimento, cbClassificacao, cbEspecificacao, txtComentario);
            panelLancamentos.Controls.Add(txtDataCompra);
            panelLancamentos.Controls.Add(txtLocal);
            panelLancamentos.Controls.Add(txtValor);
            panelLancamentos.Controls.Add(cbFormaPag);
            panelLancamentos.Controls.Add(txtParcela);
            panelLancamentos.Controls.Add(txtVencimento);
            panelLancamentos.Controls.Add(cbClassificacao);
            panelLancamentos.Controls.Add(cbEspecificacao);
            panelLancamentos.Controls.Add(txtComentario);

            ItensClassificacao(cbClassificacao);

            txtDataCompra.Focus();
        }

        private string NumeroLinhas()
        {
            int linhas = 1;
            foreach (Control item in panelLancamentos.Controls.OfType<TextBox>())
            {
                if (item is TextBox && item.Tag.ToString().Contains("DataCompra"))
                    linhas++;
            }
            return linhas.ToString();
        }

        /// <summary>
        /// Desenha os TextBoxes e os ComboBoxes quando adiciona uma linha
        /// </summary>
        /// <param name="tDataCompra"></param>
        /// <param name="tLocal"></param>
        /// <param name="tValor"></param>
        /// <param name="cbFormaPag"></param>
        /// <param name="tParcela"></param>
        /// <param name="tVencimento"></param>
        /// <param name="cbClassificacao"></param>
        /// <param name="cbEspecificacao"></param>
        /// <param name="tComentario"></param>
        private void AdicionaNovaLinha(TextBox tDataCompra, TextBox tLocal, TextBox tValor, ComboBox cbFormaPag, TextBox tParcela, TextBox tVencimento, ComboBox cbClassificacao, ComboBox cbEspecificacao, TextBox tComentario)
        {
            int qtdeLinhas = Convert.ToInt16(NumeroLinhas());
            int alturaBox = 40;
            tDataCompra.Size = lblDataCompra.Size;
            tLocal.Size = lblLocal.Size;
            tValor.Size = lblValor.Size;
            cbFormaPag.Size = lblFormaPag.Size;
            tParcela.Size = lblParcela.Size;
            tVencimento.Size = lblVencimento.Size;
            cbClassificacao.Size = lblClassificacao.Size;
            cbEspecificacao.Size = lblEspecificacao.Size;
            tComentario.Size = lblComentario.Size;

            foreach (Control campo in panelLancamentos.Controls)
            {
                if (campo is TextBox && campo.Tag.ToString().Contains("DataCompra"))
                {
                    tDataCompra.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    tDataCompra.Tag = "DataCompra" + qtdeLinhas;
                    tDataCompra.KeyPress += TxtDataCompra_KeyPress;
                }

                if (campo is TextBox && campo.Tag.ToString().Contains("Local"))
                {
                    tLocal.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    tLocal.Tag = "Local" + qtdeLinhas;
                }

                if (campo is TextBox && campo.Tag.ToString().Contains("Valor"))
                {
                    tValor.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    tValor.Tag = "Valor" + qtdeLinhas;
                    tValor.KeyPress += TxtValor_KeyPress;
                }

                if (campo is ComboBox && campo.Tag.ToString().Contains("FormaPag"))
                {
                    cbFormaPag.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    cbFormaPag.Tag = "FormaPag" + qtdeLinhas;
                    cbFormaPag.Items.Clear();
                    cbFormaPag.Items.Add("Crédito");
                    cbFormaPag.Items.Add("Débito");
                    //Evento do Combobox FormaPag
                    cbFormaPag.SelectedIndexChanged += CbFormaPag_SelectedIndexChanged;
                }

                if (campo is TextBox && campo.Tag.ToString().Contains("Parcela"))
                {
                    tParcela.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    tParcela.Tag = "Parcela" + qtdeLinhas;
                }

                if (campo is TextBox && campo.Tag.ToString().Contains("Vencimento"))
                {
                    txtVencimento.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    txtVencimento.Tag = "Vencimento" + qtdeLinhas;
                }

                if (campo is ComboBox && campo.Tag.ToString().Contains("Classificacao"))
                {
                    cbClassificacao.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    cbClassificacao.Tag = "Classificacao" + qtdeLinhas;
                    cbClassificacao.SelectedIndexChanged += CbClassificacao_SelectedIndexChanged;
                }

                if (campo is ComboBox && campo.Tag.ToString().Contains("Especificacao"))
                {
                    cbEspecificacao.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    cbEspecificacao.Tag = "Especificacao" + qtdeLinhas;
                }

                if (campo is TextBox && campo.Tag.ToString().Contains("Comentario"))
                {
                    tComentario.Location = new Point(campo.Left, campo.Top + alturaBox + alturaLabel * qtdeLinhas);
                    tComentario.Tag = "Comentario" + qtdeLinhas;
                }
            }
        }

        /// <summary>
        /// Se o Combobox FormaPag for "Débito" os campo "Parcela" e "Vencimento" ficam invisíveis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbFormaPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indiceCampo = ((ComboBox)sender).Tag.ToString().Replace("FormaPag","");

            foreach (Control c in panelLancamentos.Controls.OfType<ComboBox>())
            {
                if (c.Tag.ToString().Equals("FormaPag"+indiceCampo) && c.Text.Equals("Débito"))
                {
                    foreach (Control campo in panelLancamentos.Controls.OfType<TextBox>())
                    {
                        if(campo.Tag.ToString().Equals("Parcela"+indiceCampo) || campo.Tag.ToString().Equals("Vencimento" + indiceCampo))
                        {
                            campo.Visible = false;
                        }
                    }
                }
                else if (c.Tag.ToString().Equals("FormaPag" + indiceCampo) && c.Text.Equals("Crédito"))
                {
                    foreach (Control campo in panelLancamentos.Controls.OfType<TextBox>())
                    {
                        if (campo.Tag.ToString().Equals("Parcela" + indiceCampo) || campo.Tag.ToString().Equals("Vencimento" + indiceCampo))
                        {
                            campo.Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Para evitar que aslinhas brancos sejam armazenas no arquivo, este método verifica se os campos de uma linha interira estão em brancos
        /// </summary>
        /// <returns></returns>
        private bool VerificaSeTemLinhasEmBranco()
        {
            string ultimaLinha = (Convert.ToInt16(NumeroLinhas()) - 1).ToString();
            foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
            {
                if (c.Tag.ToString().Equals("DataCompra" + ultimaLinha))
                {
                    if (c.Text.Equals(""))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Regras de negócio
            //Dia preenchido
            //Dia da compra não pode ter diferença maior que 2 anos (permitir se correto)
            //Crédito ou débito deve estar com sinal negativo
            //Crédito deve informar a quantidade de parcelas e a data que fecha a fatura

            int numero = VerificaSeDespesaTemSinalNegativo(out numero);
            //bool condicaoFormatoData = VerificaFormatoData();
            if (VerificaSeTemLinhasEmBranco())
            {
                MessageBox.Show("Remova a última linha.");
            }
            else if (numero > 0)
            {
                MessageBox.Show("Linha " + numero + " deve ter sinal negativo no campo VALOR.");
            }
            //else if (condicaoFormatoData.Equals(false))
            //{
            //    MessageBox.Show("Erro no formato da data.");
            //}
            else
            {
                    int qtdeLinhas = Convert.ToInt32(NumeroLinhas())-1;
                    Utilidade util = new Utilidade();
                    int indiceArquivoTxt = util.NumeroRegistroTxt() + 1;
                    FileStream fs = new FileStream("ControleFinanceiro.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);

                    for (int i = 1; i <= qtdeLinhas; i++)
                    {
                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is TextBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("DataCompra" + i))
                                {
                                    DateTime dtCompra = util.Texto2Data(c.Text.Trim());
                                    sw.Write(dtCompra.ToShortDateString() + "|");
                                }
                            }
                        }

                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is TextBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("Local" + i))
                                    sw.Write(c.Text.Trim() + "|");
                            }
                        }

                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is TextBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("Valor" + i))
                                {
                                    if (!c.Text.Contains(","))
                                    {
                                        c.Text = c.Text + ",";
                                        int tamanho = c.Text.Length;
                                        c.Text = c.Text.PadRight(tamanho + 2, '0');
                                    }
                                    sw.Write((c.Text.Trim()) + "|");
                                }
                            }
                        }

                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is ComboBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("FormaPag" + i))
                                {
                                    if (c.Text.Equals("Crédito"))
                                        sw.Write(c.Text.Trim() + "|");
                                    else 
                                        sw.Write("Débito||");
                                }
                            }
                            else if (c is ComboBox && c.Text == "")
                            {
                                if (c.Tag.ToString().Equals("FormaPag" + i))
                                {
                                    sw.Write("|");
                                }
                            }
                        }

                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is TextBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("Parcela" + i))
                                    sw.Write(c.Text.Trim() + "|");
                            }
                            //else if (c is TextBox && c.Text.Equals(""))
                            //{
                            //    if (c.Tag.ToString().Equals("Parcela" + i))
                            //        sw.Write("|");
                            //}
                        }

                        foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                        {
                            if (c is TextBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("Vencimento" + i) && !c.Text.Equals(""))
                                {
                                    //Utilidade util = new Utilidade();
                                    //DateTime dtVencimento = util.Texto2Data(c.Text.Trim());
                                    //sw.Write(dtVencimento.ToShortDateString() + "|");
                                    sw.Write(c.Text.Trim() + "|");
                                }
                            }
                            else if (c is TextBox && c.Text.Equals(""))
                            {
                                if (c.Tag.ToString().Equals("Vencimento" + i))
                                {
                                    sw.Write("|");
                                }
                            }
                        }

                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is ComboBox && c.Text != "")
                            {
                                //if (c.Tag.ToString().Equals("Classificacao" + i))
                                //    sw.Write(c.Text.Trim() + "|");
                                if (c.Tag.ToString().Equals("Classificacao" + i) && !c.Text.Equals("Receita"))
                                    sw.Write(c.Text.Trim() + "|");
                                else if (c.Tag.ToString().Equals("Classificacao" + i) && c.Text.Equals("Receita"))
                                    sw.Write("|" + c.Text.Trim() + "|");
                            }
                        }

                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is ComboBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("Especificacao" + i))
                                    sw.Write(c.Text.Trim() + "|");
                            }
                        }

                        foreach (Control c in panelLancamentos.Controls)
                        {
                            if (c is TextBox && c.Text != "")
                            {
                                if (c.Tag.ToString().Equals("Comentario" + i))
                                    sw.Write(c.Text.Trim() + "|");
                            }
                        }

                        sw.WriteLine(indiceArquivoTxt + "|");
                        indiceArquivoTxt++;
                    }

                sw.Close();
                fs.Close();
                dgvExtrato.Rows.Clear();
                //tudo();
                btnSalvar.Enabled = false;
                MessageBox.Show("Registro armazenado com sucesso.", "Aviso!");
                
            }
        }

        private int VerificaSeDespesaTemSinalNegativo(out int numero)
        {
            for (int i = 1; i <= Convert.ToInt16(NumeroLinhas()); i++)
            {
                foreach (Control c in panelLancamentos.Controls.OfType<ComboBox>())
                {
                    if (c.Tag.ToString().Equals("Classificacao" + i) && !c.Text.Equals("Receita"))
                    {
                        foreach (Control componente in panelLancamentos.Controls.OfType<TextBox>())
                        {
                            if (componente.Tag.ToString().Equals("Valor" + i) && !componente.Text.Contains("-"))
                            {
                                numero = i;
                                return numero;
                            }
                        }
                    }
                }
            }
            numero = 0;
            return numero;
        }

        private bool VerificaFormatoData()
        {
            bool condicao = false;
            Utilidade util = new Utilidade();
            for (int i = 1; i <= Convert.ToInt16(NumeroLinhas()); i++)
            {
                foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                {
                    if (c.Tag.ToString().Equals("DataCompra" + i) || c.Tag.ToString().Equals("Vencimento" + i))
                    {
                        condicao = util.VerificaFormatoData(c.Text);
                        //Se algum campo estiver com data errada atribui falso e encerra o loop
                        if (condicao == false)
                            break;
                    }
                }
            }
            return condicao;
        }

        //private void ExibeNoGrid()
        //{

        //}

        //private void tudo()
        //{
        //    myExtrato.Clear();

        //    try
        //    { 
        //        if (File.Exists("ControleFinanceiro.txt"))
        //        {
        //            string[] todoTexto = File.ReadAllLines("ControleFinanceiro.txt");

        //            foreach (var campo in todoTexto)
        //            {
        //                string[] linha = campo.Split('|');

        //                Utilidade util = new Utilidade();
        //                DateTime dCompra = util.Texto2Data(linha[0]);
        //                DateTime dVencimento = util.Texto2Data(linha[5]);
        //                //aDataCompra.Add(new DateTime(Convert.ToInt16(ano), Convert.ToInt16(mes), Convert.ToInt16(dia)));
        //                //DataGridViewCellStyle estilo = dgvExtrato.f
        //                //if (Convert.ToDouble(linha[3]) < 0)
        //                //    estilo.ForeColor = Color.Red;

        //                Extrato extrato = new Extrato(dCompra, linha[1], Convert.ToDecimal(linha[2]), linha[3], linha[4], dVencimento, linha[6], linha[7], linha[8], linha[9]);
        //                //Extrato extrato = new Extrato(dCompra, linha[1], Convert.ToDecimal(linha[2]), linha[3], linha[4], linha[5], linha[6], linha[7], linha[8], linha[9]);
        //                myExtrato.Add(extrato);
        //            }
        //        }

        //        ordenaPorData();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Formato de data inválido.", "Data inválida");
        //    }
        //}

        private void ordenaPorData()
        {
            var ordenadoPelaData = myExtrato.OrderBy(p => p.dataCompra);

            foreach (var item in ordenadoPelaData)
            {
                if (item.dataVencimento.ToShortDateString().Equals("01/01/0001"))
                {
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, "", item.classificacao, item.especificacao, item.comentario, item.indice);
                }
                else
                { 
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
                    //dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento, item.classificacao, item.especificacao, item.comentario, item.indice);
                }
            }
        }

        private void ordenaPelaDataVencimento()
        {
            var peloVencimento = myExtrato.OrderBy(p => p.dataVencimento);

            foreach (var item in peloVencimento)
            { 
                if (item.dataVencimento.ToShortDateString().Equals("01/01/0001"))
                {
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, "", item.classificacao, item.especificacao, item.comentario, item.indice);
                }
                else
                {
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
                }
            }
        }

        public void ListaFaturaCartaoCredito()
        {
            dgvExtrato.Rows.Clear();
            myExtrato.Clear();
            LerArquivoTexto();
            List<Extrato> listaFiltrada = new List<Extrato>();

            lblExtrato_descricao.Text = "Fatura do cartão de crédito para 10/" + Consultas.mes + "/" + Consultas.ano;
            decimal totalfatura = 0;

            var todoExtrato = myExtrato.OrderBy(p => p.dataCompra);
            foreach (var item in todoExtrato)
            {
                if (item.dataVencimento.ToShortDateString().Equals("10/" + Consultas.mes + "/" + Consultas.ano))
                {
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
                    totalfatura += item.valor;

                    //É preciso criar uma nova lista myExtrato para que o clique no cabeçalho Data organize somente o que foi gasto no cartão de crédito ao invés de considerar todos os registros.
                    Utilidade util = new Utilidade();
                    DateTime dCompra = util.Texto2Data(item.dataCompra.ToShortDateString());
                    DateTime dVencimento = util.Texto2Data(item.dataVencimento.ToShortDateString());
                    Extrato extrato = new Extrato(dCompra, item.local, item.valor, item.formaPag, item.parcela, dVencimento, item.classificacao, item.especificacao, item.comentario, item.indice);
                    listaFiltrada.Add(extrato);
                }
            }
            myExtrato.Clear();
            myExtrato = listaFiltrada;
            dgvExtrato.Rows.Add("Total:", "", TotalizaValores(), "", "", "", "", "", "", "");
        }

        //O método que soma todos os valores será útil para aparecer o total no fim do grid para qualquer opção selecionada pelo usuário
        private decimal TotalizaValores()
        {
            decimal total = 0;
            foreach (var item in myExtrato)
            {
                total += item.valor;
            }
            return total;
        }

        private void OrdenaPorLocal()
        {
            var ordenadoPorLocal = myExtrato.OrderBy(p => p.local);
            foreach (var item in ordenadoPorLocal)
            {
                if (item.formaPag.Equals("Crédito"))
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
                else
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, "", "", item.classificacao, item.especificacao, item.comentario, item.indice);
            }
        }

        private void OrdenaPorValor()
        {
            var ordenadoPorValor = myExtrato.OrderBy(p => p.valor);
            foreach (var item in ordenadoPorValor)
            {
                dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao,  item.comentario, item.indice);
            }
        }

        private void OrdenaPorFormapagamento()
        {
            var ordenaPorFormaPagemento = myExtrato.OrderBy(p => p.formaPag);
            foreach (var item in ordenaPorFormaPagemento)
            {
                dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
            }
        }

        private void OrdenaPorClassificacao()
        {
            var ordenadoPorClassificacao = myExtrato.OrderBy(p => p.classificacao);
            foreach (var item in ordenadoPorClassificacao)
            {
                dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
            }
        }

        private void OrdenaPorEspecificacao()
        {
            var ordenadoPorEspecificacao = myExtrato.OrderBy(p => p.especificacao);
            foreach (var item in ordenadoPorEspecificacao)
            {
                dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
            }
        }

        private void OrdenaPorComentario()
        {
            var ordenadoPorComentario = myExtrato.OrderBy(p => p.comentario);
            foreach (var item in ordenadoPorComentario)
            {
                if (item.formaPag.Equals("Crédito"))
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
                else
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, "", "", item.classificacao, item.especificacao, item.comentario, item.indice);
            }
        }

        private void dgvExtrato_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvExtrato.Rows.Clear();
            if (e.ColumnIndex == 0)
            {
                //tudo();
                ordenaPorData();
                dgvExtrato.Rows.Add("Total:", "", TotalizaValores(), "", "", "", "", "", "", "");
            }
            else if (e.ColumnIndex==1)
            {
                OrdenaPorLocal();
                dgvExtrato.Rows.Add("Total:", "", TotalizaValores(), "", "", "", "", "", "", "");
            }
            else if (e.ColumnIndex == 2)
            {
                OrdenaPorValor();
                dgvExtrato.Rows.Add("Total:", "", TotalizaValores(), "", "", "", "", "", "", "");
            }
            else if (e.ColumnIndex == 5)
            {
                ordenaPelaDataVencimento();
                dgvExtrato.Rows.Add("Total:", "", TotalizaValores(), "", "", "", "", "", "", "");
            }

            else if (e.ColumnIndex == 8)
            {
                OrdenaPorComentario();
                dgvExtrato.Rows.Add("Total:", "", TotalizaValores(), "", "", "", "", "", "", "");
            }

            //switch (e.ColumnIndex)
            //{
            //    case 0: ordenaPorData();
            //        break;
            //    case 1: ordenaPorData();
            //        break;
            //    case 2:
            //        ordenaPorData();
            //        break;
            //    case 3:
            //        ordenaPorData();
            //        break;
            //    case 4:
            //        ordenaPorData();
            //        break;
            //    case 5:
            //        ordenaPelaDataVencimento();
            //        break;
            //    case 6:
            //        ordenaPorData();
            //        break;
            //    case 7:
            //        ordenaPorData();
            //        break;
            //    case 8:
            //        ordenaPorData();
            //        break;
            //    case 9:
            //        ordenaPorData();
            //        break;
            //}
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(NumeroLinhas()) > 2)
            { 
                string qtdeLinhas = (Convert.ToInt16(NumeroLinhas()) - 1).ToString();

                foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                {
                    if (c.Tag.ToString().Equals("DataCompra" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                {
                    if (c.Tag.ToString().Equals("Local" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                {
                    if (c.Tag.ToString().Equals("Valor" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                {
                    if (c.Tag.ToString().Equals("Parcela" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                {
                    if (c.Tag.ToString().Equals("Vencimento" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<TextBox>())
                {
                    if (c.Tag.ToString().Equals("Comentario" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<ComboBox>())
                {
                    if (c.Tag.ToString().Equals("FormaPag" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<ComboBox>())
                {
                    if (c.Tag.ToString().Equals("Classificacao" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }

                foreach (Control c in panelLancamentos.Controls.OfType<ComboBox>())
                {
                    if (c.Tag.ToString().Equals("Especificacao" + qtdeLinhas))
                    {
                        panelLancamentos.Controls.Remove(c);
                    }
                }
            }
        }

        private void dgvExtrato_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvExtrato.CurrentCell.RowIndex;
            string registro = dgvExtrato.Rows[linha].Cells["cIndice"].Value.ToString();
            Utilidade util = new Utilidade();
            //Ao remover a informação das parcelas e campo torna-se vazio, o sistema entende que o valor é nulo. É preciso atribuir uma string vazia.
            if (dgvExtrato.Rows[linha].Cells["cParcela"].Value == null)
            {
                dgvExtrato.Rows[linha].Cells["cParcela"].Value = "";
            }

            if (dgvExtrato.Rows[linha].Cells["cVencimento"].Value == null)
            {
                dgvExtrato.Rows[linha].Cells["cVencimento"].Value = "";
            }

            util.AtualizaRegistroArquivoTxt(dgvExtrato.Rows[linha].Cells["cdata"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cLocal"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cValor"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cFormPag"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cParcela"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cVencimento"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cClassificacao"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cEspecificacao"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cComentario"].Value.ToString().Trim(),
                dgvExtrato.Rows[linha].Cells["cIndice"].Value.ToString().Trim());
        }

        private void dgvExtrato_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int linha = dgvExtrato.CurrentCell.RowIndex;
            //Se for a coluna data chama SomenteNumerosCampoData()
            if (dgvExtrato.CurrentCell.OwningColumn.Equals(cdata))
                e.Control.KeyPress += SomenteNumerosCampoData;
            //Se for a data do venvimento do cartão de crédito chama SomenteNumerosCampoData()
            else if (dgvExtrato.CurrentCell.OwningColumn == (cVencimento))
                e.Control.KeyPress += SomenteNumerosCampoData;
            //Se a coluna for valor chama SomenteNumerosVirgula()
            else if (dgvExtrato.CurrentCell.OwningColumn == cValor)
                e.Control.KeyPress += SomenteNumerosVirgula;
        }

        private void SomenteNumerosVirgula(object sender, KeyPressEventArgs e)
        {
            //Somente números, sinal negativo, virgula e backspace
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 44 && e.KeyChar != 45 && e.KeyChar != 8)
                e.Handled = true;
        }

        private void SomenteNumerosCampoData(object sender, KeyPressEventArgs e)
        {
            //Somente as colunas que informam datas podem teclar números, barra(/) e backspace
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 47 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            foreach (Control c in panelLancamentos.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            btnSalvar.Enabled = true;
        }

        private void balançoGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myExtrato.Clear();
            dgvExtrato.Rows.Clear();
            LerArquivoTexto();
            var geral = myExtrato.OrderBy(p => p.dataCompra);

            foreach (var item in geral)
            {
                if (item.dataVencimento.ToShortDateString().Equals("01/01/0001"))
                {
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, "", item.classificacao, item.especificacao, item.comentario, item.indice);
                }
                else
                {
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, item.formaPag, item.parcela, item.dataVencimento.ToShortDateString(), item.classificacao, item.especificacao, item.comentario, item.indice);
                }
            }
        }

        private void sm_Exibir_Geral_todasDespesas_Click(object sender, EventArgs e)
        {
            myExtrato.Clear();
            LerArquivoTexto();
            dgvExtrato.Rows.Clear();
            var todasDespesas = myExtrato.OrderBy(p => p.dataCompra);

            decimal totalDespesas = 0;

            foreach (var despesas in todasDespesas)
            {
                if (despesas.valor < 0)
                {
                    if (despesas.dataVencimento.ToShortDateString().Equals("01/01/0001"))
                    {
                        dgvExtrato.Rows.Add(despesas.dataCompra.ToShortDateString(), despesas.local, despesas.valor, despesas.formaPag, despesas.parcela, "", despesas.classificacao, despesas.especificacao, despesas.comentario, despesas.indice);
                    }
                    else
                    {
                        dgvExtrato.Rows.Add(despesas.dataCompra.ToShortDateString(), despesas.local, despesas.valor, despesas.formaPag, despesas.parcela, despesas.dataVencimento.ToShortDateString(), despesas.classificacao, despesas.especificacao, despesas.comentario, despesas.indice);
                    }
                    totalDespesas += despesas.valor;
                }
            }

            lblExtrato_descricao.Text = "Relatório das despesas";
            lblExtrato_descricao.ForeColor = Color.Red;
            dgvExtrato.Rows.Add("Total", "", totalDespesas, "", "", "", "", "", "", "");
        }

        private void sm_Exibir_Geral_todasReceitas_Click(object sender, EventArgs e)
        {
            myExtrato.Clear();
            LerArquivoTexto();
            dgvExtrato.Rows.Clear();
            lblExtrato_descricao.Text = "Relatório das receitas";
            lblExtrato_descricao.ForeColor = Color.Blue;
            decimal totalReceita = 0;

            var todasReceitas = myExtrato.OrderBy(p => p.dataCompra);
            foreach (var item in todasReceitas)
            {
                if (item.valor > 0)
                {
                    dgvExtrato.Rows.Add(item.dataCompra.ToShortDateString(), item.local, item.valor, "", "", "", item.classificacao, item.especificacao, item.comentario, item.indice);
                    totalReceita += item.valor;
                }
            }
            dgvExtrato.Rows.Add("Total", "", totalReceita, "", "", "", "", "", "", "");
        }

        private void sm_Exibir_cartaoDeCredito_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas(this);
            consultas.Show();
            consultas.DesenhaComponentes("fatura");
        }

        private void ChangesToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            Changes changes = new Changes();
            changes.ShowDialog();
        }

        private void ChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changes changes = new Changes();
            changes.ShowDialog();
        }

        private void corrigirIndicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int contador = 1;
            string[] todoTexto = File.ReadAllLines("ControleFinanceiro.txt");

            File.Delete("ControleFinanceiro.txt");

            FileStream fs = new FileStream("ControleFinanceiro.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            foreach (string linha in todoTexto)
            {
                string[] dado = linha.Split('|');
                sw.WriteLine(dado[0] + "|" + dado[1] + "|" + dado[2] + "|" + dado[3] + "|" + dado[4] + "|" + dado[5] + "|" + dado[6] + "|" + dado[7] + "|" + dado[8] + "|" + contador + "|");
                contador++;
            }
            sw.Close();
            fs.Close();
        }

        //TODO Receber parâmetro informando a data inicial e data final para exibir as movimentações financeiras.

        //TODO Criar um form com as opções de exibição de acordo com a necessidade do usuário

        //TODO As mesmas regras de restrições de edição dos campos de lançamentos devem ser aplicadas no dgvExtrato (somente números etc)

        //TODO Entre datas débitos
        //TODO Entre datas crédito
        //TODO Entre datas balanço
    }
}