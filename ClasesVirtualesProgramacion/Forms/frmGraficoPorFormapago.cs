using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClasesVirtualesProgramacion.Forms
{
    public partial class frmGraficoPorFormapago : Form
    {
        admConexion oConexion = new admConexion();
        public frmGraficoPorFormapago()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
             string SQL= "Select formapago, count(formapago) as total from gastos group by formapago";
            if(oConexion.SelectData(SQL, dsClasesVirtuales.Totalporformadepago)== true)
            {
                oGrafico.Series.Clear();
                oGrafico.Titles.Clear();
                oGrafico.ChartAreas.Clear();
                oGrafico.Palette = ChartColorPalette.Excel;
                ChartArea areaGrafico = new ChartArea();
                areaGrafico.Area3DStyle.Enable3D = true;
                oGrafico.ChartAreas.Add(areaGrafico);
                Title tituloGrafico = new Title();
                tituloGrafico.Text = "Total de gastos por forma de pago";
                tituloGrafico.Font = new Font("Tahoma", 15, FontStyle.Bold);
                oGrafico.Titles.Add(tituloGrafico);
                Series serieDatos = new Series("Formapago");
                serieDatos.ChartType = SeriesChartType.Doughnut;
                serieDatos.XValueMember = "Formapago";
                serieDatos.YValueMembers = "Total";
                serieDatos.IsValueShownAsLabel = true;
                oGrafico.Series.Add(serieDatos);
                oGrafico.DataSource = dsClasesVirtuales.Totalporformadepago;
            }
        }
    }
} 

