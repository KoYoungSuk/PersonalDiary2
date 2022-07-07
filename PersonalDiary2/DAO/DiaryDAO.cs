using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDiary2
{
    //Pre MVC Version 
    //Model-View-Controller
    class DiaryDAO
    {
        OracleConnection conn;
        global g = new global();
        String db_url;
        String db_port;
        String db_sid;
        String db_id;
        String db_pw;

        public DiaryDAO(string db_url, string db_port, string db_sid, string db_id, string db_pw)
        {
            this.db_url = db_url;
            this.db_port = db_port;
            this.db_sid = db_sid;
            this.db_id = db_id;
            this.db_pw = db_pw;
        }

        public void connectDB()
        {
            String connstr = g.connectionString(db_url, db_port, db_sid, db_id, db_pw);
            conn = new OracleConnection(connstr);
            conn.Open();
        }

        public void disconnectDB()
        {
            if(conn != null)
            {
                conn.Close();
                conn = null;
            }
        }
        
        
        public int insertDiary(DiaryDTO diarydto) 
        {
            connectDB();
            String sql = "insert into diary (title, context, savedate, modifydate) values (:title, :context, :savedate, :modifydate)";
            OracleCommand icmd = new OracleCommand(sql, conn);
            icmd.BindByName = true;
            icmd.Parameters.Add(new OracleParameter("title", diarydto.Title));
            icmd.Parameters.Add(new OracleParameter("context", diarydto.Content));
            icmd.Parameters.Add(new OracleParameter("savedate", DateTime.Parse(diarydto.Savedate)));  
            icmd.Parameters.Add(new OracleParameter("modifydate", diarydto.Modifydate));
            int result = icmd.ExecuteNonQuery();
            disconnectDB();
            return result;
        }

        public int UpdateDiary(DiaryDTO diarydto)
        {
            connectDB();
            String sql = "update diary set context=:context, modifydate=:modifydate where title = :title";
            OracleCommand ucmd = new OracleCommand(sql, conn);
            ucmd.BindByName = true;
            ucmd.Parameters.Add(new OracleParameter("context", diarydto.Content));
            ucmd.Parameters.Add(new OracleParameter("modifydate", DateTime.Parse(diarydto.Modifydate)));
            ucmd.Parameters.Add(new OracleParameter("title", diarydto.Title));
            int result = ucmd.ExecuteNonQuery();
            disconnectDB();
            return result;
        }

        public int DeleteDiary(String title)
        {
            connectDB();
            String sql = "delete from diary where title = :title";
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            dcmd.Parameters.Add(new OracleParameter("title", title));
            int result = dcmd.ExecuteNonQuery();
            disconnectDB();
            return result;
        }

        public SortedList<String, String> getDiaryListByTitle(String title)
        {
            connectDB();
            SortedList<String,String> diarylist = new SortedList<String, String>();
            String sql = "select * from diary where title = :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", title));
            OracleDataReader dr = scmd.ExecuteReader();
            while (dr.Read())
            {
                diarylist.Add("title", dr["title"].ToString());
                diarylist.Add("context", dr["context"].ToString());
                diarylist.Add("savedate", dr["savedate"].ToString());
                diarylist.Add("modifydate", dr["modifydate"].ToString());
            }
            dr.Close();
            disconnectDB();
            return diarylist; 
        }
        public List<MemberDTO> getMemberList()  //For Login 
        {
            List<MemberDTO> memberlist = new List<MemberDTO>();
            connectDB();
            String sql = "select * from member order by id";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            while (dr.Read())
            {
                MemberDTO memberdto = new MemberDTO();
                memberdto.Id = dr["id"].ToString();
                memberdto.Password = dr["password"].ToString();
                memberlist.Add(memberdto);
            }
            dr.Close();
            disconnectDB();
            return memberlist;
        }
        
        public DataTable getDiaryList2(Boolean desc)
        {
            DataTable dt = new DataTable();
            connectDB();
            String sql = null;
            if (desc)
            {
                sql = "select * from diary order by title desc";
            }
            else
            {
                sql = "select * from diary order by title";
            }
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = scmd;
            oda.Fill(dt);
            oda.Dispose();
            disconnectDB();
            return dt;
        }
        public List<DiaryDTO> getDiaryList(Boolean desc)
        {
            List<DiaryDTO> diarylist = new List<DiaryDTO>();
            connectDB();
            String sql = null;
            if (desc)
            {
                sql = "select * from diary order by title desc";
            }
            else
            {
                sql = "select * from diary order by title";
            }
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            while(dr.Read())
            {
                DiaryDTO diarydto = new DiaryDTO();
                diarydto.Title = dr["title"].ToString();
                diarydto.Content = dr["context"].ToString();
                diarydto.Savedate = dr["savedate"].ToString();
                diarydto.Modifydate = dr["modifydate"].ToString();
                diarylist.Add(diarydto);
            }
            dr.Close();
            disconnectDB();
            return diarylist; 
        }
       
        public int getDiaryCount()
        {
            connectDB();
            int diarynumber = 0;
            String sql = "select count(*) diarynumber from diary";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            while(dr.Read())
            {
                diarynumber = Int32.Parse(dr["diarynumber"].ToString());
            }
            dr.Close();
            disconnectDB();
            return diarynumber;
        }
    }
}
