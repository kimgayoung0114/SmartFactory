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
using Infragistics.Win;
using System.Windows.Forms.DataVisualization.Charting;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Layout;
using System.Security.Cryptography.X509Certificates;
using static Infragistics.Win.ThemedEdit;

namespace MultiColoredModernUI.Forms
{
    public partial class FormProduct : Form, IToolBar
    {
        public const string DbPath = "Data Source=222.235.141.8,1111; Initial Catalog=GNU23_04; User ID=GNU2304; Password=1234";

        DataTable dtTemp = new DataTable(); // return DataTable 공통
        SqlConnection sCon = new SqlConnection(DbPath);

        public FormProduct()
        {
            InitializeComponent();
        }

        #region < 그리드 세팅 >
        private void FormProduct_Load(object sender, EventArgs e)
        {
            // 그리드
            dtTemp.Columns.Add("PLANTCODE", typeof(string));
            dtTemp.Columns.Add("LINECODE", typeof(string));
            dtTemp.Columns.Add("ITEMCODE", typeof(string));
            dtTemp.Columns.Add("ITEMNAME", typeof(string));
            dtTemp.Columns.Add("ORDERCLOSEFLAG", typeof(string));
            dtTemp.Columns.Add("MAKER", typeof(string));
            dtTemp.Columns.Add("MAKEDATE", typeof(string));
            dtTemp.Columns.Add("EDITOR", typeof(string));
            dtTemp.Columns.Add("EDITDATE", typeof(string));

            Grid.DataSource = dtTemp;

            Grid.Columns["PLANTCODE"].HeaderText = "공장";
            Grid.Columns["LINECODE"].HeaderText = "설비 라인";
            Grid.Columns["ITEMCODE"].HeaderText = "품목";
            Grid.Columns["ITEMNAME"].HeaderText = "품목명";
            Grid.Columns["ORDERCLOSEFLAG"].HeaderText = "작업 시간";
            Grid.Columns["MAKER"].HeaderText = "등록자";
            Grid.Columns["MAKEDATE"].HeaderText = "등록일시";
            Grid.Columns["EDITOR"].HeaderText = "수정자";
            Grid.Columns["EDITDATE"].HeaderText = "수정일시";

            Grid.Columns[0].Width = 184;
            Grid.Columns[1].Width = 184;
            Grid.Columns[2].Width = 184;
            Grid.Columns[3].Width = 184;
            Grid.Columns[4].Width = 184;
            Grid.Columns[5].Width = 184;
            Grid.Columns[6].Width = 184;
            Grid.Columns[7].Width = 184;
            Grid.Columns[8].Width = 184;

            // 컬럼의 정렬 지정 
            //Grid.Columns["USEFLAG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //컬럼의 수정 여부를 지정
            //Grid.Columns["MAKER"].ReadOnly = true;
            //Grid.Columns["MAKEDATE"].ReadOnly = true;
            //Grid.Columns["EDITDATE"].ReadOnly = true;
            //Grid.Columns["EDITOR"].ReadOnly = true;
            #endregion

            SqlConnection sCon = new SqlConnection(DbPath);
            try
            {
                #region < 공장 콤보 박스 셋팅 >
                string sSelectSql2 = " SELECT DISTINCT PLANTCODE" +
                                      " FROM facilities         ";

                // 데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter2 = new SqlDataAdapter(sSelectSql2, sCon);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2); // Use adapter2 to fill dt2

                // 콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboPlantCode.DataSource = dt2;

                // 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboPlantCode.ValueMember = "PLANTCODE";
                cboPlantCode.DisplayMember = "PLANTCODE";
                #endregion

                #region < 설비 라인 콤보 박스 셋팅 >
                string sSelectSql3 = " SELECT DISTINCT LINECODE    " +
                                     "  FROM facilities         ";

                //데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter3 = new SqlDataAdapter(sSelectSql3, sCon);
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);

                //콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboLineCode.DataSource = dt3;

                //응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboLineCode.ValueMember = "LINECODE";
                cboLineCode.DisplayMember = "LINECODE";
                #endregion

                #region < 품목 콤보 박스 셋팅 >
                string sSelectSql4 = " SELECT DISTINCT ITEMCODE  " +
                                     "   FROM facilities         ";

                // 데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter4 = new SqlDataAdapter(sSelectSql4, sCon);
                DataTable dt4 = new DataTable();
                adapter4.Fill(dt4);

                // 콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboItemCode.DataSource = dt4;

                // 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboItemCode.ValueMember = "ITEMCODE";
                cboItemCode.DisplayMember = "ITEMCODE";
                #endregion

                #region < 품목명 콤보 박스 셋팅 >
                string sSelectSql5 = " SELECT DISTINCT ITEMNAME  " +
                                     "   FROM facilities         ";

                // 데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter5 = new SqlDataAdapter(sSelectSql5, sCon);
                DataTable dt5 = new DataTable();
                adapter5.Fill(dt5);

                // 콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboItemName.DataSource = dt5;

                // 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboItemName.ValueMember = "ITEMNAME";
                cboItemName.DisplayMember = "ITEMNAME";
                #endregion

                #region < 작업시간 콤보 박스 셋팅 >
                string sSelectSql6 = " SELECT DISTINCT ORDERCLOSEFLAG  " +
                                     "   FROM facilities         ";

                // 데이터베이스를 조회하는 클래스
                SqlDataAdapter adapter6 = new SqlDataAdapter(sSelectSql6, sCon);
                DataTable dt6 = new DataTable();
                adapter6.Fill(dt6);

                // 콤보박스에 셋팅되어야 하는 데이터를 매핑
                cboOrderCloseFlag.DataSource = dt6;

                // 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                cboOrderCloseFlag.ValueMember = "ORDERCLOSEFLAG";
                cboOrderCloseFlag.DisplayMember = "ORDERCLOSEFLAG";
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

        #region < 조회 >
        public void DoInquire()
        {
            dtTemp.Clear();

            try
            {
                sCon.Open();

                //Remove filters from the comboboxes
                cboPlantCode.SelectedIndex = -1;
                cboLineCode.SelectedIndex = -1;
                cboItemCode.SelectedIndex = -1;
                cboItemName.SelectedIndex = -1;
                cboOrderCloseFlag.SelectedIndex = -1;

                // Query to select all data from the 'facilities' table
                string sSqlSelect = " SELECT * FROM facilities                  ";


                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dtTemp);

                // Update the DataGridView with the new data
                Grid.DataSource = dtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sCon.Close();
            }
        }
        #endregion

        #region < 저장 >
        public void DoSave()
        {
            // 일괄 저장
            DataTable dtChange = new DataTable();

            // 품목의 정보가 갱신된 데이터를 추출
            dtChange = dtTemp.GetChanges();

            // 수정한 행이 없을 경우

            if (dtChange.Rows.Count == 0) return;

            if (MessageBox.Show("변경된 내역을 등록하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            // 1. 데이터베이스 오픈
            sCon.Open();

            // 데이터베이스에 접속하여 SQL 구문 실행
            // 2. SQL Command 객체 생성 (U/D/I)
            SqlCommand cmd = new SqlCommand();

            // 3. 데이터베이스에 접속 정보 전달
            cmd.Connection = sCon;

            // 4. 트랜잭션 설정 (일괄 승인, 일괄 복원)
            cmd.Transaction = sCon.BeginTransaction();
            // 트랜잭션 (Transaction)
            //  -데이터 갱신 내역을 승인 또는 복구 가능
            //  -데이터의 일관성 (하나의 데이터라도 오류가 발생할 경우 전체 데이터를 복원하여 일부 데이터만 격차가 발생되는 현상을 막기 위함)


            // DataRow : 데이터테이블의 행을 단위별로 담는 클래스

            string sPlantCode = string.Empty;
            string sLineCode = string.Empty;
            string sItemCode = string.Empty;
            string sItemName = string.Empty;
            string sOrdercloseFlag = string.Empty;
            string sMaker = string.Empty;
            string sMakeDate = string.Empty;
            string sEditor = string.Empty;
            string sEditdate = string.Empty;

            try
            {
                string Sql = string.Empty;
                string sMessage = string.Empty; //필수 입력값 누락 여부
                foreach (DataRow dr in dtChange.Rows)
                {
                    // 변경된 행을 하나씩 추출하여 행의 상태에 따라서 데이터베이스에 처리
                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges();
                            Sql = $" DELETE facilities WHERE LINECODE = '{dr["LINECODE"]}'";
                            break;

                        case DataRowState.Added:
                            sPlantCode = dr["PLANTCODE"].ToString();
                            sLineCode = dr["LINECODE"].ToString();
                            sItemCode = dr["ITEMCODE"].ToString();
                            sItemName = dr["ITEMNAME"].ToString();
                            sOrdercloseFlag = dr["ORDERCLOSEFLAG"].ToString();
                            sMaker = dr["MAKER"].ToString();
                            sMakeDate = dr["MAKEDATE"].ToString();

                            // 데이터가 없는경우 INSERT
                            Sql = "INSERT INTO facilities( PLANTCODE    ,LINECODE,       ITEMCODE,      ITEMNAME,     ORDERCLOSEFLAG,      MAKER,       MAKEDATE ) " +
                                 $"               VALUES('{sPlantCode}', '{sLineCode}','{sItemCode}', '{sItemName}','{sOrdercloseFlag}','{sMaker}', '{sMakeDate}')";
                            break;

                        case DataRowState.Modified:
                            sPlantCode = dr["PLANTCODE"].ToString();
                            sLineCode = dr["LINECODE"].ToString();
                            sItemCode = dr["ITEMCODE"].ToString();
                            sItemName = dr["ITEMNAME"].ToString();
                            sOrdercloseFlag = dr["ORDERCLOSEFLAG"].ToString();
                            sMaker = dr["MAKER"].ToString();
                            sMakeDate = dr["MAKEDATE"].ToString();

                            Sql = "UPDATE facilities                                    " +
                                      $"    SET  PLANTCODE      = '{sPlantCode}'        " +
                                      $"        ,LINECODE       = '{sLineCode}'         " +
                                      $"        ,ITEMCODE       = '{sItemCode}'         " +
                                      $"        ,ITEMNAME       = '{sItemName}'         " +
                                      $"        ,ORDERCLOSEFLAG = '{sOrdercloseFlag}'   " +
                                      $"        ,MAKER          = '{sMaker}'            " +
                                      $" WHERE   MAKEDATE       = '{sMakeDate}'         " ; 
                            break;
                    }
                    cmd.CommandText = Sql;   //커맨드에 실행할 SQL 명령 등록
                    cmd.ExecuteNonQuery();  //커맨드를 실행
                }

                //정상 등록 완료
                cmd.Transaction.Commit();
                MessageBox.Show("정상 처리 되었습니다.");
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();     //예외상황 발생 시 복구, 반드시 메세지 출력 이전에!!
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
        }
        #endregion

        #region < 새로운 행 >
        public void DoNew()
        {
            dtTemp.Rows.Add();
        }
        #endregion

        #region < 삭제 >
        public void DoDelete()
        {
            // 그리드에 데이터 행을 삭제 처리 (데이터베이스에서 처리 전)
            #region <Validation Check 그리드에 삭제 할 내역이 존재하지 않을경우>
            if (Grid.Rows.Count == 0) return;
            if (Grid.CurrentRow == null)
            {
                MessageBox.Show("삭제 할 대상을 선택하세요.");
                return; // 삭제할 대상을 전택하지 않았을 때 
            }
            #endregion
            // 삭제할 품목데이터의 품목 코드 정보.
            string sItemCode = Grid.CurrentRow.Cells["LINECODE"].Value.ToString();

            // 데이터 테이블에서 해당 품목 코드를 가지고 있는 행을 삭제.
            // i : 데이터 테이블 행의 Index 주소
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                // 데이터 테이블에서 삭제할 대상 품목 코드를 찾았다면.
                // dtTemp.Rows[i].RowState != DataRowState.Deleted 중간에 삭제되어 만들어진 null 값
                // 
                if (dtTemp.Rows[i].RowState != DataRowState.Deleted && dtTemp.Rows[i]["LINECODE"].ToString() == sItemCode)
                {
                    // 해당 데치터 테이블의 행을 삭제
                    dtTemp.Rows[i].Delete();
                    break;
                }

                // 이 작업 이후 그리드 상의 row index와 DB상의 row index가 차이가 남.
                // 그래서 삭제의 기준을 DB로 놓고 작업해야 오류가 안생긴다.
                // 그리드는 이후에 저장을 통한 일괄 처리기능 구현 때문에 남겨놓음.
            }
        }
        #endregion
    }
}

