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
    public partial class Changes : Form
    {
        public Changes()
        {
            InitializeComponent();
        }

        private void Changes_Load(object sender, EventArgs e)
        {
            txtChanges.Text = "Versão 1.1|06/09/2019|Acréscimo do menu Changes para visualizar as modificações\r\n" +
                "Gravação dos dados no arquivo em ordem crescente\r\n";
            txtChanges.Text += "25/12/2020|Recurso que torna os índices distintos evitando que o registro que tem a mesma identicação seja alterado\r\n;"


        }
    }
}
