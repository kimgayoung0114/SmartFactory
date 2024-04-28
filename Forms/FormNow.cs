using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiColoredModernUI.Forms
{
    public partial class FormNow : Form
    {
        private SqlConnection sqlConnection;
        private Timer timer1, timer2, timer3, timer4, timer5, timer6, timer7, timer8;
        private Random random;
        private int counter = 0;

        public FormNow()
        {
            InitializeComponent();
            InitializeTimers();
            random = new Random();
            InitializeSqlConnection();
        }

        private void InitializeSqlConnection()
        {
            string connectionString = "Data Source=222.235.141.8,1111; Initial Catalog=GNU23_04; User ID=GNU2304; Password=1234";
            sqlConnection = new SqlConnection(connectionString);
        }

        private void InitializeTimers()
        {
            timer1 = CreateTimerWithInterval(5000, timer1_Tick);
            timer2 = CreateTimerWithInterval(7000, timer2_Tick);
            timer3 = CreateTimerWithInterval(9000, timer3_Tick);
            timer4 = CreateTimerWithInterval(11000, timer4_Tick);
            timer5 = CreateTimerWithInterval(13000, timer5_Tick);
            timer6 = CreateTimerWithInterval(15000, timer6_Tick);
            timer7 = CreateTimerWithInterval(17000, timer7_Tick);
            timer8 = CreateTimerWithInterval(19000, timer8_Tick);


        }


        private Timer CreateTimerWithInterval(int interval, EventHandler tickEventHandler)
        {
            Timer timer = new Timer();
            timer.Interval = interval;
            timer.Tick += tickEventHandler;
            return timer;
        }

       
        private void RetrieveDataFromDatabase(int fFacilityNumber, int pFacilityNumber, TextBox MLINECODETextBox, TextBox MITEMNAMETextBox)
        {
            try
            {
                sqlConnection.Open();

                // Ftype 테이블의 fFacilityNumber 번째 값을 가져오는 쿼리
                string MLINECODEQuery = $@"
            WITH MLINECODECTE AS (
                SELECT MLINECODE, ROW_NUMBER() OVER (ORDER BY MLINECODE) AS RowNum
                FROM Mfacilites
            )
            SELECT MLINECODE FROM MLINECODECTE WHERE RowNum = {fFacilityNumber}";

                // Ptype 테이블의 pFacilityNumber 번째 값을 가져오는 쿼리
                string ITEMNAMEQuery = $@"
            WITH MITEMNAMECTE AS (
                SELECT MITEMNAME, ROW_NUMBER() OVER (ORDER BY MITEMNAME) AS RowNum
                FROM Mfacilites
            )
            SELECT MITEMNAME FROM MITEMNAMECTE WHERE RowNum = {pFacilityNumber}";

                using (SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection))
                {
                    string MLINECODEValue = command.ExecuteScalar()?.ToString();
                    MLINECODETextBox.Text = MLINECODEValue;
                }

                using (SqlCommand command = new SqlCommand(ITEMNAMEQuery, sqlConnection))
                {
                    string ITEMNAMEValue = command.ExecuteScalar()?.ToString();
                    MITEMNAMETextBox.Text = ITEMNAMEValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
    }
       
        #region<설비1호기>

        private void OrInput1_Click(object sender, EventArgs e)
        {
            OrbtnRun1.Enabled = true;
            OrPanel6.BackColor = Color.Yellow;
        }

        private void OrbtnRun1_Click(object sender, EventArgs e)
        {
            RetrieveDataFromDatabase(1,1, OrtextBox11, OrtextBox12);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"); // 현재 날짜와 시간을 문자열로 변환
            OrtextBox13.Text = formattedDateTime;
            OrPanel6.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 501); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox14.Text = $"{randomNumber}V";

            if (randomNumber >= 490 && randomNumber <= 500)
            {
                sqlConnection.Open();
           
                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox11.Text}','{OrtextBox12.Text}',
                                                           '{OrtextBox13.Text}','{OrtextBox14.Text}'
                                                           )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();



                OrPanel6.BackColor = Color.Red;
                timer1.Stop();

                sqlConnection.Close();

            }
            else
            {
                OrPanel6.BackColor = Color.Lime;
                timer1.Start();
            }
        }
        private void OrPause1_Click(object sender, EventArgs e)
        {
            OrPanel6.BackColor = Color.White;
            timer1.Stop();
        }
        private void OrMaint1_Click(object sender, EventArgs e)
        {
            OrPanel6.BackColor = Color.Orange;
            timer1.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox13.Text).AddSeconds(10);
                
                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                
                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox11.Text}','{OrtextBox12.Text}',
                                                        '{OrtextBox13.Text}', '{endDate}', 
                                                        '100', '90', '10'
                                                    )" ;
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel6.BackColor = Color.DarkGray;
            OrtextBox11.Text = "";
            OrtextBox12.Text = "";
            OrtextBox13.Text = "";
            OrtextBox14.Text = "";
            OrbtnRun1.Enabled = false;

            timer1.Stop();
        }
        private void OrStop1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            counter = 0;
            OrtextBox11.Text = "";
            OrtextBox12.Text = "";
            OrtextBox13.Text = "";
            OrtextBox14.Text = "";
            OrbtnRun1.Enabled = false;
            OrPanel6.BackColor = Color.DarkGray;
        }
        #endregion

        #region<설비2호기>

        private void OrInput2_Click(object sender, EventArgs e)
        {
            OrbtnRun2.Enabled = true;
            OrPanel7.BackColor = Color.Yellow;
        }

        private void OrbtnRun2_Click(object sender, EventArgs e)
        {
            RetrieveDataFromDatabase(2,2, OrtextBox21, OrtextBox22);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");  // 현재 날짜와 시간을 문자열로 변환
            OrtextBox23.Text = formattedDateTime;
            OrPanel7.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 501); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox24.Text = $"{randomNumber}V";

            if (randomNumber >= 490 && randomNumber <= 500)
            {
                sqlConnection.Open();

                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox21.Text}','{OrtextBox22.Text}',
                                                           '{OrtextBox23.Text}','{OrtextBox24.Text}'
                                                           )";
           
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();


                OrPanel7.BackColor = Color.Red;
                timer2.Stop();
                sqlConnection.Close();
            }
            else
            {
                OrPanel7.BackColor = Color.Lime;
                timer2.Start();
            }


        }

        private void OrPause2_Click(object sender, EventArgs e)
        {
            OrPanel7.BackColor = Color.White;
            timer2.Stop();
        }

        private void OrMaint2_Click(object sender, EventArgs e)
        {
            OrPanel7.BackColor = Color.Orange;
            timer2.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void OrStop2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            counter = 0;
            OrtextBox21.Text = "";
            OrtextBox22.Text = "";
            OrtextBox23.Text = "";
            OrtextBox24.Text = "";
            OrbtnRun2.Enabled = false;
            OrPanel7.BackColor = Color.DarkGray;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox23.Text).AddSeconds(10);

                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox21.Text}','{OrtextBox22.Text}',
                                                        '{OrtextBox23.Text}', '{endDate}', 
                                                        '110', '100', '10'
                                                    )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel7.BackColor = Color.DarkGray;
            OrtextBox21.Text = "";
            OrtextBox22.Text = "";
            OrtextBox23.Text = "";
            OrtextBox24.Text = "";
            OrbtnRun2.Enabled = false;

            timer2.Stop();
        }

        #endregion

        #region<설비3호기>

        private void OrInput3_Click(object sender, EventArgs e)
        {
            OrbtnRun3.Enabled = true;
            OrPanel8.BackColor = Color.Yellow;
        }

        private void OrbtnRun3_Click(object sender, EventArgs e)
        {
            RetrieveDataFromDatabase(3,3, OrtextBox31, OrtextBox32);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");  // 현재 날짜와 시간을 문자열로 변환
            OrtextBox33.Text = formattedDateTime;
            OrPanel8.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 501); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox34.Text = $"{randomNumber}V";

            if (randomNumber >= 498 && randomNumber <= 500)
            {
                sqlConnection.Open();
                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox31.Text}','{OrtextBox32.Text}',
                                                           '{OrtextBox33.Text}','{OrtextBox34.Text}'
                                                           )";

                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

                OrPanel8.BackColor = Color.Red;
                timer3.Stop();
                sqlConnection.Close();
            }
            else
            {
                OrPanel8.BackColor = Color.Lime;
                timer3.Start();
            }
        }

        private void OrPause3_Click(object sender, EventArgs e)
        {
            OrPanel8.BackColor = Color.White;
            timer3.Stop();
        }

        private void OrMaint3_Click(object sender, EventArgs e)
        {
            OrPanel8.BackColor = Color.Orange;
            timer3.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void OrStop3_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            counter = 0;
            OrtextBox31.Text = "";
            OrtextBox32.Text = "";
            OrtextBox33.Text = "";
            OrtextBox34.Text = "";
            OrbtnRun3.Enabled = false;
            OrPanel8.BackColor = Color.DarkGray;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox33.Text).AddSeconds(10);

                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");


                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox31.Text}','{OrtextBox32.Text}',
                                                        '{OrtextBox33.Text}', '{endDate}', 
                                                        '120', '118', '2'
                                                    )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel8.BackColor = Color.DarkGray;
            OrtextBox31.Text = "";
            OrtextBox32.Text = "";
            OrtextBox33.Text = "";
            OrtextBox34.Text = "";
            OrbtnRun3.Enabled = false;
            timer3.Stop();
        }

        #endregion

        #region<설비4호기>

        private void OrInput4_Click(object sender, EventArgs e)
        {
            OrbtnRun4.Enabled = true;
            OrPanel9.BackColor = Color.Yellow;
        }

        private void OrbtnRun4_Click(object sender, EventArgs e)
        {
            RetrieveDataFromDatabase(4,4, OrtextBox41, OrtextBox42);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");  // 현재 날짜와 시간을 문자열로 변환
            OrtextBox43.Text = formattedDateTime;
            OrPanel9.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 521); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox44.Text = $"{randomNumber}V";

            if (randomNumber >= 490 && randomNumber <= 520)
            {
                sqlConnection.Open();
                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox41.Text}','{OrtextBox42.Text}',
                                                           '{OrtextBox43.Text}','{OrtextBox44.Text}'
                                                           )";
               
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

                OrPanel9.BackColor = Color.Red;
                timer4.Stop();
                sqlConnection.Close();
            }
            else
            {
                OrPanel9.BackColor = Color.Lime;
                timer4.Start();
            }
        }

        private void OrPause4_Click(object sender, EventArgs e)
        {
            OrPanel9.BackColor = Color.White;
            timer4.Stop();
        }

        private void OrMaint4_Click(object sender, EventArgs e)
        {
            OrPanel9.BackColor = Color.Orange;
            timer4.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void OrStop4_Click(object sender, EventArgs e)
        {
            timer4.Stop();
            counter = 0;
            OrtextBox41.Text = "";
            OrtextBox42.Text = "";
            OrtextBox43.Text = "";
            OrtextBox44.Text = "";
            OrbtnRun4.Enabled = false;
            OrPanel9.BackColor = Color.DarkGray;
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox43.Text).AddSeconds(10);

                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox41.Text}','{OrtextBox42.Text}',
                                                        '{OrtextBox43.Text}', '{endDate}', 
                                                        '130', '110', '20'
                                                    )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel9.BackColor = Color.DarkGray;
            OrtextBox41.Text = "";
            OrtextBox42.Text = "";
            OrtextBox43.Text = "";
            OrtextBox44.Text = "";
            OrbtnRun4.Enabled = false;
            timer4.Stop();
        }

        #endregion

        #region<설비5호기>

        private void OrInput5_Click(object sender, EventArgs e)
        {
            OrbtnRun5.Enabled = true;
            OrPanel10.BackColor = Color.Yellow;
        }

        private void OrbtnRun5_Click(object sender, EventArgs e)
        {
            RetrieveDataFromDatabase(5,5, OrtextBox51, OrtextBox52);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");  // 현재 날짜와 시간을 문자열로 변환
            OrtextBox53.Text = formattedDateTime;
            OrPanel10.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 501); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox54.Text = $"{randomNumber}V";

            if (randomNumber >= 495 && randomNumber <= 500)
            {
                sqlConnection.Open();
                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox51.Text}','{OrtextBox52.Text}',
                                                           '{OrtextBox53.Text}','{OrtextBox54.Text}'
                                                           )";
                
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

                OrPanel10.BackColor = Color.Red;
                timer5.Stop();
                sqlConnection.Close();
            }
            else
            {
                OrPanel10.BackColor = Color.Lime;
                timer5.Start();
            }
        }

        private void OrPause5_Click(object sender, EventArgs e)
        {
            OrPanel10.BackColor = Color.White;
            timer5.Stop();
        }

        private void OrMaint5_Click(object sender, EventArgs e)
        {
            OrPanel10.BackColor = Color.Orange;
            timer5.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void OrStop5_Click(object sender, EventArgs e)
        {
            timer5.Stop();
            counter = 0;
            OrtextBox51.Text = "";
            OrtextBox52.Text = "";
            OrtextBox53.Text = "";
            OrtextBox54.Text = "";
            OrbtnRun5.Enabled = false;
            OrPanel10.BackColor = Color.DarkGray;
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox53.Text).AddSeconds(10);

                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox51.Text}','{OrtextBox52.Text}',
                                                        '{OrtextBox53.Text}', '{endDate}', 
                                                        '140', '133', '7'
                                                    )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel10.BackColor = Color.DarkGray;
            OrtextBox51.Text = "";
            OrtextBox52.Text = "";
            OrtextBox53.Text = "";
            OrtextBox54.Text = "";
            OrbtnRun5.Enabled = false;
            timer5.Stop();
        }



        #endregion

        #region<설비6호기>

        private void OrInput6_Click(object sender, EventArgs e)
        {
            OrbtnRun6.Enabled = true;
            OrPanel11.BackColor = Color.Yellow;
        }

        private void OrbtnRun6_Click(object sender, EventArgs e)
        {
            RetrieveDataFromDatabase(6,6, OrtextBox61, OrtextBox62);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");  // 현재 날짜와 시간을 문자열로 변환
            OrtextBox63.Text = formattedDateTime;
            OrPanel11.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 511); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox64.Text = $"{randomNumber}V";

            if (randomNumber >= 480 && randomNumber <= 510)
            {
                sqlConnection.Open();
                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox61.Text}','{OrtextBox62.Text}',
                                                           '{OrtextBox63.Text}','{OrtextBox64.Text}'
                                                           )";
                
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

                OrPanel11.BackColor = Color.Red;
                timer6.Stop();
                sqlConnection.Close();
            }
            else
            {
                OrPanel11.BackColor = Color.Lime;
                timer6.Start();
            }
        }

        private void OrPause6_Click(object sender, EventArgs e)
        {
            OrPanel11.BackColor = Color.White;
            timer6.Stop();
        }

        private void OrMaint6_Click(object sender, EventArgs e)
        {
            OrPanel11.BackColor = Color.Orange;
            timer6.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void OrStop6_Click(object sender, EventArgs e)
        {
            timer6.Stop();
            counter = 0;
            OrtextBox61.Text = "";
            OrtextBox62.Text = "";
            OrtextBox63.Text = "";
            OrtextBox64.Text = "";
            OrbtnRun6.Enabled = false;
            OrPanel11.BackColor = Color.DarkGray;
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox63.Text).AddSeconds(10);

                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox61.Text}','{OrtextBox62.Text}',
                                                        '{OrtextBox63.Text}', '{endDate}', 
                                                        '150', '120', '30'
                                                    )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel11.BackColor = Color.DarkGray;
            OrtextBox61.Text = "";
            OrtextBox62.Text = "";
            OrtextBox63.Text = "";
            OrtextBox64.Text = "";
            OrbtnRun6.Enabled = false;
            timer6.Stop();
        }

        #endregion

        #region<설비7호기>

        private void OrInput7_Click(object sender, EventArgs e)
        {
            OrbtnRun7.Enabled = true;
            OrPanel12.BackColor = Color.Yellow;
        }

        private void OrbtnRun7_Click(object sender, EventArgs e)
        {
            RetrieveDataFromDatabase(7,7, OrtextBox71, OrtextBox72);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");  // 현재 날짜와 시간을 문자열로 변환
            OrtextBox73.Text = formattedDateTime;
            OrPanel12.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 501); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox74.Text = $"{randomNumber}V";

            if (randomNumber >= 490 && randomNumber <= 500)
            {
                sqlConnection.Open();
                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox71.Text}','{OrtextBox72.Text}',
                                                           '{OrtextBox73.Text}','{OrtextBox74.Text}'
                                                           )";
                
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

                OrPanel12.BackColor = Color.Red;
                timer7.Stop();
                sqlConnection.Close();
            }
            else
            {
                OrPanel12.BackColor = Color.Lime;
                timer7.Start();
            }
        }

        private void OrPause7_Click(object sender, EventArgs e)
        {
            OrPanel12.BackColor = Color.White;
            timer7.Stop();
        }

        private void OrMaint7_Click(object sender, EventArgs e)
        {
            OrPanel12.BackColor = Color.Orange;
            timer7.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void OrStop7_Click(object sender, EventArgs e)
        {
            // 타이머를 멈추고 변수를 초기화
            timer7.Stop();
            counter = 0;

            // TextBox 및 Panel 등을 초기 상태로 되돌리기
            OrtextBox71.Text = "";
            OrtextBox72.Text = "";
            OrtextBox73.Text = "";
            OrtextBox74.Text = "";
            OrbtnRun7.Enabled = false;
            OrPanel12.BackColor = Color.DarkGray;
        }

      

        private void timer7_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox73.Text).AddSeconds(10);

                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox71.Text}','{OrtextBox72.Text}',
                                                        '{OrtextBox73.Text}', '{endDate}', 
                                                        '160', '144', '16'
                                                    )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel12.BackColor = Color.DarkGray;
            OrtextBox71.Text = "";
            OrtextBox72.Text = "";
            OrtextBox73.Text = "";
            OrtextBox74.Text = "";
            OrbtnRun7.Enabled = false;
            timer7.Stop();
        }
        #endregion

        #region<설비8호기>

        private void OrInput8_Click(object sender, EventArgs e)
        {
            OrbtnRun8.Enabled = true;
            OrPanel13.BackColor = Color.Yellow;
        }

        private void OrbtnRun8_Click(object sender, EventArgs e)
        {

            RetrieveDataFromDatabase(8,8, OrtextBox81, OrtextBox82);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");  // 현재 날짜와 시간을 문자열로 변환
            OrtextBox83.Text = formattedDateTime;
            OrPanel13.BackColor = Color.Lime;
            int randomNumber = random.Next(400, 501); // 400 이상 500 이하의 임의의 숫자 생성
            OrtextBox84.Text = $"{randomNumber}V";

            if (randomNumber >= 490 && randomNumber <= 500)
            {
                sqlConnection.Open();
                string MLINECODEQuery = $@" INSERT INTO Alarm (
                                                           MLINECODE, MITEMNAME,
                                                           Wstartdate, AlarmVoltage
                                                    )
                                                    Values(
                                                           '{OrtextBox81.Text}','{OrtextBox82.Text}',
                                                           '{OrtextBox83.Text}','{OrtextBox84.Text}'
                                                           )";
               
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();

                OrPanel13.BackColor = Color.Red;
                timer8.Stop();
                sqlConnection.Close();
            }
            else
            {
                OrPanel13.BackColor = Color.Lime;
                timer8.Start();
            }
        }

        private void OrPause8_Click(object sender, EventArgs e)
        {
            OrPanel13.BackColor = Color.White;
            timer8.Stop();
        }

        private void OrMaint8_Click(object sender, EventArgs e)
        {
            OrPanel13.BackColor = Color.Orange;
            timer8.Stop(); // 타이머를 멈춤
            counter = 0;
        }

        private void OrStop8_Click(object sender, EventArgs e)
        {
            timer8.Stop();
            counter = 0;
            OrtextBox81.Text = "";
            OrtextBox82.Text = "";
            OrtextBox83.Text = "";
            OrtextBox84.Text = "";
            OrbtnRun8.Enabled = false;
            OrPanel13.BackColor = Color.DarkGray;
        }
        private void timer8_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                sqlConnection.Open();
                dt = DateTime.Parse(OrtextBox83.Text).AddSeconds(10);

                string endDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

                string MLINECODEQuery = $@" INSERT INTO Result (
                                                        MLINECODE, MITEMNAME, 
                                                        Wstartdate, Wenddate, 
                                                        MORDERCLOSEFLAG, Wgood, Wbad
                                                    )
                                                    Values (
                                                        '{OrtextBox81.Text}','{OrtextBox82.Text}',
                                                        '{OrtextBox83.Text}', '{endDate}', 
                                                        '170', '160', '10'
                                                    )";
                SqlCommand command = new SqlCommand(MLINECODEQuery, sqlConnection);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            OrPanel13.BackColor = Color.DarkGray;
            OrtextBox81.Text = "";
            OrtextBox82.Text = "";
            OrtextBox83.Text = "";
            OrtextBox84.Text = "";
            OrbtnRun8.Enabled = false;
            timer8.Stop();
        }

        #endregion
    }
}
