using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public class ProcessDatabase
    {
        public static string str = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=DIENTHOAI;Integrated Security=True";
        public SqlConnection sqlConnect = null;
        public ProcessDatabase() {
            
        }
        public void SetConnection(string _str)
        {
            str = _str;
        }


        public string[] Procedure(string[] value, string[] paramNameInput, string[] paramNameOutput, string proce)
        {
            KetNoiCSDL();
            using (SqlCommand cmd = sqlConnect.CreateCommand())
            {
                try
                {
                    cmd.CommandText = proce;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[paramNameInput.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        param[i] = cmd.CreateParameter();
                        param[i].ParameterName = paramNameInput[i];
                        param[i].Value = value[i];
                        cmd.Parameters.Add(param[i]);
                    }
                    SqlParameter[] output = new SqlParameter[paramNameOutput.Length];
                    for (int i = 0; i < paramNameOutput.Length; i++)
                    {
                        output[i] = cmd.CreateParameter();
                        output[i].ParameterName = paramNameOutput[i];
                        output[i].Direction = ParameterDirection.Output;
                        output[i].DbType = DbType.String;
                        output[i].Size = 10;
                        cmd.Parameters.Add(output[i]);
                    }
                    cmd.ExecuteNonQuery();
                    List<string> ans = new List<string>();
                    for (int i = 0; i < paramNameOutput.Length; i++)
                    {
                        ans.Add(output[i].Value.ToString());
                    }
                    return ans.ToArray();
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public bool CheckConnection(string _str)
        {
            sqlConnect = new SqlConnection(_str);
            try
            {
                sqlConnect.Open();
                sqlConnect.Close();
                str = _str;
            }
            catch (SqlException)
            {
                return false;
            }

            return true;
        }

        public void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(str);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }

        public void DongKetNoiCSDL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
            }
        }
        public DataTable DocBang(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                KetNoiCSDL();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnect);
                adapter.Fill(dt);
                DongKetNoiCSDL();
                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public void ThiHanhLenh(string sql)
        {
            KetNoiCSDL();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DongKetNoiCSDL();
        }

        public bool Find(string sql)
        {
            return true;
        }

        public DataTable TimKiemUser(string tk, string mk)
        {
            KetNoiCSDL();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT TenNguoiDung, VaiTro FROM dbo.NGUOIDUNG WHERE TaiKhoan = '{tk}' and MatKhau = '{mk}'", sqlConnect);
            adapter.Fill(dt);
            DongKetNoiCSDL();
            return dt;
        }

        public bool IsInTable(string sql)
        {
            var dt = DocBang(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string Function(string sql)
        {
            KetNoiCSDL();
            string ans;
            using (SqlCommand cmd = sqlConnect.CreateCommand())
            {
                cmd.CommandText = sql;
                ans = cmd.ExecuteScalar().ToString();
            }
            DongKetNoiCSDL();
            return ans;
        }
    }
}
