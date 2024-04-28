using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
//using DC00_Component;

namespace MultiColoredModernUI.Forms
{
    public partial class FormDashboard : Form
    {
        string connectionString = "Data Source=222.235.141.8,1111; Initial Catalog=GNU23_04; User ID=GNU2304; Password=1234";

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            DataTable dt220 = GetDataFromDatabase();
            double totalWGood = CalculateTotalWGood(dt220);
            
            double result = (totalWGood) * 5;

            DB_label3.Text = totalWGood.ToString();
            DB_label5.Text = result.ToString();

            DrawChart(dt220);
        }

        private double CalculateTotalWGood(DataTable dataTable)
        {
            double totalWGood = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                totalWGood += Convert.ToDouble(dataTable.Rows[i]["TotalWGOOD"]);
            }
            return totalWGood;
        }

        private double CalculateTotalWBad(DataTable dataTable)
        {
            double totalWBad = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                totalWBad += Convert.ToDouble(dataTable.Rows[i]["TotalWBAD"]);
            }
            return totalWBad;
        }
        private int myPrivateVariable;
        //private string connectionString;


        public DataTable GetDataFromDatabase()
        {
            DataTable dt220 = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //string connectionString = "Data Source=222.235.141.8,1111; Initial Catalog=GNU23_04; User ID=GNU2304; Password=1234";
                //connection.Open();
                string query22 = "SELECT MLINECODE, SUM(WGOOD) TotalWGOOD, SUM(WBAD) TotalWBAD FROM Result GROUP BY MLINECODE;";
                using (SqlCommand command = new SqlCommand(query22, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt220);
                    }
                }
            }
            return dt220;
        }

        private void DrawChart(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0) return;
            dataTable.Columns.Add("DefectRate", typeof(string));

            double dTotalBad = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dTotalBad = Convert.ToDouble(dataTable.Rows[i]["TotalWBAD"]);
                dataTable.Rows[i]["DefectRate"] = Math.Round(dTotalBad / (Convert.ToDouble(dataTable.Rows[i]["TotalWGOOD"]) + dTotalBad) * 100, 2);
            }

            // Calculate and set the average DefectRate
            double averageDefectRate = dataTable.AsEnumerable()
                                              .Average(row => Convert.ToDouble(row["DefectRate"]));
            DB_label9.Text = averageDefectRate.ToString("0.##") + "%";

            chart2.DataSource = dataTable;

            chart2.Series[0].XValueMember = "MLINECODE";
            chart2.Series[0].YValueMembers = "DefectRate";
            chart2.Series[0].Name = "불량률";
            chart2.Series[0].Color = Color.FromArgb(35, 99, 220);
            chart2.Series[0].IsValueShownAsLabel = true;
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "0.##'%'";
        }
    }
}

    
