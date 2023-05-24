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

        public DiaryDAO(OracleConnection conn)
        {
            this.conn = conn; 
        }

        
        public int insertDiary(DiaryDTO diarydto) 
        {
            ///connectDB();
            String sql = "insert into diary (title, context, savedate, modifydate) values (:title, :context, :savedate, :modifydate)";
            OracleCommand icmd = new OracleCommand(sql, conn);
            icmd.BindByName = true;
            icmd.Parameters.Add(new OracleParameter("title", diarydto.Title));
            icmd.Parameters.Add(new OracleParameter("context", diarydto.Content));
            icmd.Parameters.Add(new OracleParameter("savedate", DateTime.Parse(diarydto.Savedate)));  
            icmd.Parameters.Add(new OracleParameter("modifydate", diarydto.Modifydate));
            int result = icmd.ExecuteNonQuery();
            //disconnectDB();
            return result;
        }

        public int UpdateDiary(DiaryDTO diarydto)
        {
            //connectDB();
            String sql = "update diary set context=:context, modifydate=:modifydate where title = :title";
            OracleCommand ucmd = new OracleCommand(sql, conn);
            ucmd.BindByName = true;
            ucmd.Parameters.Add(new OracleParameter("context", diarydto.Content));
            ucmd.Parameters.Add(new OracleParameter("modifydate", DateTime.Parse(diarydto.Modifydate)));
            ucmd.Parameters.Add(new OracleParameter("title", diarydto.Title));
            int result = ucmd.ExecuteNonQuery();
            //disconnectDB();
            return result;
        }

        public int DeleteDiary(String title)
        {
            //connectDB();
            String sql = "delete from diary where title = :title";
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            dcmd.Parameters.Add(new OracleParameter("title", title));
            int result = dcmd.ExecuteNonQuery();
            //disconnectDB();
            return result;
        }

        public SortedList<String, String> getDiaryListByTitle(String title)
        {
            //connectDB();
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
            //disconnectDB();
            return diarylist; 
        }

        public DataTable getDiaryList2(Boolean desc)
        {
            DataTable dt = new DataTable();
            //connectDB();
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
            //disconnectDB();
            return dt;
        }

        public int createTable()
        {
            String sql = "create table DIARY (title varchar2(100) not null primary key, context clob not null, savedate timestamp, modifydate timestamp)";
            OracleCommand ocmd = new OracleCommand(sql, conn);
            int result = ocmd.ExecuteNonQuery();
            ocmd.Dispose();
            return result;
        }

        public Boolean Tableexists()
        {
            String sql = "select TNAME from tab where TNAME = 'DIARY'";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            String name = null;
            Boolean existstatus = false;
            if (dr.Read())
            {
                name = dr["TNAME"].ToString();
            }
            if(name != null)
            {
                existstatus = true;
            }
            return existstatus; 
        }
        public int getDiaryCount()
        {
            //connectDB();
            int diarynumber = 0;
            String sql = "select count(*) diarynumber from diary";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            while(dr.Read())
            {
                diarynumber = Int32.Parse(dr["diarynumber"].ToString());
            }
            dr.Close();
            //disconnectDB();
            return diarynumber;
        }
    }
}
