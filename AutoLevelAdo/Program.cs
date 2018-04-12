using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLevelAdo
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataSet bookStoreDataSet = new DataSet();
            bookStoreDataSet.ExtendedProperties.Add("developerName", "JeLion");

            DataTable booksTable = new DataTable("Books");

            DataColumn idColumn = new DataColumn();
            idColumn.ColumnName = "id";
            idColumn.DataType = typeof(int);
            idColumn.AllowDBNull = false;
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 0;
            idColumn.AutoIncrementStep = 1;
            idColumn.Unique = true;

            booksTable.Columns.Add(idColumn);

            DataRow firstRow = booksTable.NewRow();
            firstRow["id"] = 1;

            

            booksTable.Rows.Add(firstRow);

            bookStoreDataSet.Tables.Add(booksTable);

            bookStoreDataSet.AcceptChanges();


            firstRow.BeginEdit();
            //редактируем, если получили
            firstRow["id"] = 8;
            firstRow.EndEdit();
            //firstRow.AcceptChanges();

            var reader = bookStoreDataSet.CreateDataReader(booksTable);

            while (reader.Read())
            {
                var idData = reader["id"];
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.Fill(bookStoreDataSet);
        }
    }
}
