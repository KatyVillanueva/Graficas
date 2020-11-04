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
    public partial class frmGraficoPorSubcategoria : Form
    {
        admConexion oConexion = new admConexion();
        public frmGraficoPorSubcategoria()
        {
            InitializeComponent();
        }

        private void oGrafico_Click(object sender, EventArgs e)
        {

        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string SQL = "Select subcategoria, count(subcategoria) as total from gastos group by subcategoria";
            if (oConexion.SelectData(SQL, dsClasesVirtuales.Totalporsubcategorias) == true)
            {
                oGrafico.Series.Clear();
                oGrafico.Titles.Clear();
                oGrafico.ChartAreas.Clear();
                oGrafico.Palette = ChartColorPalette.Excel;
                ChartArea areaGrafico = new ChartArea();
                areaGrafico.Area3DStyle.Enable3D = true;
                oGrafico.ChartAreas.Add(areaGrafico);
                Title tituloGrafico = new Title();
                tituloGrafico.Text = "Total de los gastos por Subcategoría";
                tituloGrafico.Font = new Font("Tahoma", 15, FontStyle.Bold);
                oGrafico.Titles.Add(tituloGrafico);
                Series serieDatos = new Series("Subcategoría");
                serieDatos.ChartType = SeriesChartType.Line;
                serieDatos.XValueMember = "Subcategoria";
                serieDatos.YValueMembers = "Total";
                serieDatos.IsValueShownAsLabel = true;
                oGrafico.Series.Add(serieDatos);
                oGrafico.DataSource = dsClasesVirtuales.Totalporsubcategorias;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
