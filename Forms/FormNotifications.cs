using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiColoredModernUI.Forms
{
    public partial class FormNotifications : Form, IToolBar
    {
        public const string DbPath = "Data Source=222.235.141.8,1111; Initial Catalog=GNU23_04; User ID=GNU2304; Password=1234";

        DataTable dtTemp = new DataTable(); // return DataTable 공통
        SqlConnection sCon = new SqlConnection(DbPath);

        public FormNotifications()
        {
            InitializeComponent();

        }

        private void FormNotifications_Load(object sender, EventArgs e)
        {

            LoadTheme();
            dtTemp.Columns.Add("MLINECODE", typeof(string));
            dtTemp.Columns.Add("MITEMNAME", typeof(string));
            dtTemp.Columns.Add("WSTARTDATE", typeof(string));
            dtTemp.Columns.Add("ALARMVOLTAGE", typeof(string));

            dataGridView1.DataSource = dtTemp;

            dataGridView1.Columns["MLINECODE"].HeaderText = "설비 라인";
            dataGridView1.Columns["MITEMNAME"].HeaderText = "품목명";
            dataGridView1.Columns["WSTARTDATE"].HeaderText = "알람 시간";
            dataGridView1.Columns["ALARMVOLTAGE"].HeaderText = "전압";


            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;

            SqlConnection sCon = new SqlConnection(DbPath);
            try
            {
                #region < 설비 라인 콤보 박스 셋팅 >
                string sSelectSql11 = " SELECT DISTINCT MLINECODE" +
                                      " FROM Alarm         ";

                // 데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter11 = new SqlDataAdapter(sSelectSql11, sCon);
                DataTable dt11 = new DataTable();
                adapter11.Fill(dt11); // Use adapter2 to fill dt2

                // 콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboLineCode1.DataSource = dt11;

                // 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboLineCode1.ValueMember = "MLINECODE";
                cboLineCode1.DisplayMember = "MLINECODE";
                #endregion


                #region < 품목명 박스 셋팅 >
                string sSelectSql12 = " SELECT DISTINCT MITEMNAME" +
                                      " FROM Alarm  ";

                // 데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter12 = new SqlDataAdapter(sSelectSql12, sCon);
                DataTable dt12 = new DataTable();
                adapter12.Fill(dt12); // Use adapter2 to fill dt2

                // 콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboItemName1.DataSource = dt12;

                // 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboItemName1.ValueMember = "MITEMNAME";
                cboItemName1.DisplayMember = "MITEMNAME";
                #endregion

                #region < 알람 시간 박스 셋팅 >
                string sSelectSql13 = " SELECT DISTINCT WSTARTDATE" +
                                      " FROM Alarm   ";

                // 데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter13 = new SqlDataAdapter(sSelectSql13, sCon);
                DataTable dt13 = new DataTable();
                adapter13.Fill(dt13); // Use adapter2 to fill dt2

                // 콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboStartDate1.DataSource = dt13;

                // 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboStartDate1.ValueMember = "WSTARTDATE";
                cboStartDate1.DisplayMember = "WSTARTDATE";
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sCon.Close();
            }

        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

        }

        public void DoInquire()
        {
            dtTemp.Clear(); // 기존 데이터를 제거

            try
            {
                using (SqlConnection sCon = new SqlConnection(DbPath))
                {
                    sCon.Open();

                    string sSqlSelect = "SELECT * FROM Alarm";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon))
                    {
                        adapter.Fill(dtTemp);
                    }

                    dataGridView1.DataSource = dtTemp; // DataGridView에 바인딩

                    // 차트의 이전 데이터를 지웁니다.
                    chart1.Series.Clear();
                    chart1.Titles.Clear();

                    // 바 차트를 위한 새로운 Series를 생성합니다.
                    Series series = new Series("Occurrences");
                    series.ChartType = SeriesChartType.Column;

                    // LINQ를 이용하여 MLINECODE의 빈도수를 계산합니다.
                    var occurrences = dtTemp.AsEnumerable()
                                           .GroupBy(row => row.Field<string>("MLINECODE"))
                                           .Select(group => new
                                           {
                                               MLINECODE = " " + group.Key,
                                               Count = group.Count()
                                           })
                                           .OrderBy(item => item.MLINECODE); // MLINECODE 값을 정렬합니다.

                    // Series에 데이터 포인트를 추가합니다.
                    foreach (var item in occurrences)
                    {
                        series.Points.AddXY(item.MLINECODE, item.Count);
                    }

                    // Series를 차트에 추가합니다.
                    chart1.Series.Add(series);

                    // 차트의 제목을 설정합니다.
                    chart1.Titles.Add("라인별 알람 빈도수 비교");

                    // X축 라벨을 기울입니다.
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                    chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Alrambtn_Click(object sender, EventArgs e)
        {
            DoInquire();
        }

        public void DoNew()
        {

        }

        public void DoDelete()
        {

        }

        public void DoSave()
        {

        }

    }
}
