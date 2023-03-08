using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentManagement.Data;

namespace studentManagement.Database
{
    public class ClassDatabaseService

    {
        public string connectionString = @"Data Source=DESKTOP-ML4PHGF\JAMESTRAN;Initial Catalog=StudentManagement;Integrated Security=True";
        public SqlConnection sqlConnection;
        private readonly List<Class> _classes = new();
        public ClassDatabaseService()
        {
            this._classes = DummyData.Classes;
        }
        public List<Class> getListClass()
        {
            return this._classes;
        }
        public List<Class> GetListClass()
        {
            List<Class> list = new List<Class>();
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string selectQuery = "select * from Class";
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
                var sqlReader = selectCommand.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Class aclass = new Class();
                        aclass.Id = (int)sqlReader["ClassId"];
                        aclass.Name = (string)sqlReader["ClassName"];
                        aclass.TeacherId = (int)sqlReader["TeacherId"];
                        aclass.StartTime =DateTime.Parse(Convert.ToString( sqlReader["StartTime"]));
                        aclass.EndTime = DateTime.Parse(Convert.ToString(sqlReader["EndTime"]));
                        list.Add(aclass);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            return list;
        }
        //take out the largest id
        public int GenerateId()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string findMaxId = "select MAX(ClassId) from Class";
            using var findMaxIdCommand = new SqlCommand(findMaxId, sqlConnection);
            int max = (int)findMaxIdCommand.ExecuteScalar();
            sqlConnection.Close();
            return max;

        }
        public void UpDateClass(Class aclass, int Id)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = $"update Class set ClassName=' {aclass.Name} ', TeacherId= '{aclass.TeacherId}', StartTime= '{aclass.StartTime}', EndTime='{aclass.EndTime}' where ClassId=@ClassId";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@ClassId", Id);

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddClass(int Id, string Name, int TeacherId, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "insert into Class (ClassId, ClassName, TeacherId,StartTime, EndTime) values (@ClassId, @ClassName,@TeacherId,@StartTime, @EndTime);";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@ClassId", Id);

                insertCommand.Parameters.AddWithValue("@ClassName", Name);

                insertCommand.Parameters.AddWithValue("@TeacherId", TeacherId);

                insertCommand.Parameters.AddWithValue("@StartTime", StartTime);

                insertCommand.Parameters.AddWithValue("@EndTime", EndTime);

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteClass(int Id)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "delete from Class where ClassId =@ClassId ";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@ClassId", Id);

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
                Console.WriteLine("delete successful class!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Class cannot be deleted");
            }
        }
    }
 }
