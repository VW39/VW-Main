using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pos_4._0
{
    public partial class API
    {
        SqlConnection DBConnect = new();
        SqlDataAdapter Adapter = new();
        //DB 설정


        //DB호출
        //Begin tran

        //commit
        //rollback

        public void SQL_SET(String IP, String Port, String Catalog_DBname, String ID, String PS)
        {
            DBConnect = new SqlConnection($"Data Source={IP},{Port};Initial Catalog={Catalog_DBname};User ID={ID};Password={PS}"); //DB 연결
        }
        public void SQL_SET_Auto()
        {
            DBConnect = new SqlConnection(@"Data Source=119.149.22.49,1433;Initial Catalog=cafe_control;User ID=sa;Password=tmakxmvhtm");
        }
        public void SQL_Open()
        {
            DBConnect.Open();
        }
        public void SQL_Close()
        {
            Transaction_Commit();
            DBConnect.Close();
        }
        public DataTable SQL(String Target_DB)
        {
            DataTable DT = new();
            Adapter.SelectCommand = new SqlCommand(Target_DB, DBConnect);
            Adapter.Fill(DT);
            return DT;
        }
        //public DataTable SQL(String Target_DB, Dictionary<KeyEventArgs, ValueTas> Parameter) {//프로시저 이름, 파라미터사전

        //딕셔너리로 파라미터를 받아서 조회
        //    return DT;
        //}
        public DataTable Qurey(String Qurey)
        {
            DataTable DT = new();
            var SQL = new SqlCommand(Qurey, DBConnect);
            SQL.ExecuteNonQuery();
            return DT;
        }
        public void Transaction_Begin_Tran()
        {
            Qurey("Begin Tran");
        }
        public void Transaction_RollBack()
        {
            Qurey("Begin Tran");
        }
        public void Transaction_Commit()
        {
            Qurey("Commit");
        }

    }
}





