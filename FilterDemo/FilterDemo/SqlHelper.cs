using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FilterDemo
{
   public static class SqlHelper
   {
      static DataTable _dtSource;

      static SqlHelper()
      {
         _dtSource = new DataTable();

         _dtSource.Columns.Add("GUID", typeof(string));
         _dtSource.Columns.Add("���", typeof(string));
         _dtSource.Columns.Add("����", typeof(string));
         _dtSource.Columns.Add("����", typeof(decimal));
         _dtSource.Columns.Add("����", typeof(DateTime));

         for (int i = 0; i < 360; i++)
         {
            DataRow row = _dtSource.NewRow();
            row["GUID"] = Guid.NewGuid().ToString();
            row["���"] = "1701" + i.ToString("000");
            row["����"] = "����" + i.ToString("000");
            row["����"] = 3500.00d + i;
            row["����"] = new DateTime(1981, 1, 1).AddDays(i);
            _dtSource.Rows.Add(row);

            row = _dtSource.NewRow();
            row["GUID"] = Guid.NewGuid().ToString();
            row["���"] = "1702" + i.ToString("000");
            row["����"] = "����" + i.ToString("000");
            row["����"] = 4000.00d + i;
            row["����"] = new DateTime(1982, 2, 2).AddDays(i);
            _dtSource.Rows.Add(row);

            row = _dtSource.NewRow();
            row["GUID"] = Guid.NewGuid().ToString();
            row["���"] = "1703" + i.ToString("000");
            row["����"] = "����" + i.ToString("000");
            row["����"] = 4500.00d + i;
            row["����"] = new DateTime(1983, 3, 3).AddDays(i);
            _dtSource.Rows.Add(row);
         }
      }

      /// <summary>
      /// ��ʽ��SQL��ѯ������ͨ��ת���ַ������ѯ�쳣
      /// </summary>
      /// <param name="strQuery">�������</param>
      /// <returns></returns>
      public static string FormatSql(string strQuery)
      {
         //strQuery = strQuery.Replace("/", "//");
         strQuery = strQuery.Replace("'", "''");
         //strQuery = strQuery.Replace("%", "/%");
         return strQuery;
      }

      /// <summary>
      /// ģ���ѯ
      /// </summary>
      /// <param name="strWhere">����</param>
      /// <returns></returns>
      public static DataTable GetData(string strWhere)
      {
         DataTable dt = _dtSource.Clone();

         foreach (DataRow row in _dtSource.Select(strWhere))
         {
            dt.ImportRow(row);
         }

         return dt;
      }
   }
}
