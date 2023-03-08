using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentManagement.Data;

namespace studentManagement.Database
{
    public class TeacherDatabaseService
    {
        public string connectionString = @"Data Source=DESKTOP-ML4PHGF\JAMESTRAN;Initial Catalog=StudentManagement;Integrated Security=True";
        public SqlConnection sqlConnection;
        private readonly List<Teacher> _teachers = new();
        public TeacherDatabaseService()
        {
            this._teachers = DummyData.Teachers;
        }
        public List<Teacher> getListTeacher()
        {
            return this._teachers;
        }
        public List<Teacher> GetListTeacher()
        {
            List<Teacher> list = new List<Teacher>();
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string selectQuery = "select * from Teacher";
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
                var sqlReader = selectCommand.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Teacher ateacher = new Teacher();
                        ateacher.Id = (int)sqlReader["Id"];
                        ateacher.Name = (string)sqlReader["FullName"];
                        ateacher.DateOfBirth = (DateTime)sqlReader["DateOfBirth"];
                        ateacher.StartYear = (int)sqlReader["StartYear"];
                        ateacher.PhoneNumber = (string)sqlReader["PhoneNumber"];
                        ateacher.EmailAddress = (string)sqlReader["Email"];
                        list.Add(ateacher);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            return list;
        }
        public void AddTeacher(int Id, string Name, DateTime DateOfBirth,int StartYear, string PhoneNumber,string Email)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "insert into Teacher (Id, FullName, DateOfBirth,StartYear, PhoneNumber, Email) values (@Id, @FullName,@DateOfBirth,@StartYear, @PhoneNumber, @Email);";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@Id", Id);

                insertCommand.Parameters.AddWithValue("@FullName", Name);

                insertCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                insertCommand.Parameters.AddWithValue("@Email", Email);

                insertCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                insertCommand.Parameters.AddWithValue("@StartYear", StartYear);


                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //take out the largest id
          
        }
        public int GenerateId()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string findMaxId = "select MAX(Id) from Teacher";
            using var findMaxIdCommand = new SqlCommand(findMaxId, sqlConnection);
            int max = (int)findMaxIdCommand.ExecuteScalar();
            sqlConnection.Close();
            return max;

        }
        public void UpDateTeacher(Teacher teacher, int Id)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = $"update Teacher set FullName=' {teacher.Name} ', DateOfBirth= '{teacher.DateOfBirth}', StartYear='{teacher.StartYear}',PhoneNumber = '{teacher.PhoneNumber}', Email = {teacher.EmailAddress} where Id=@Id";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@Id", Id);

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteTeacher(int Id)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "delete from Teacher where Id =@Id ";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@Id", Id);

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
                Console.WriteLine("delete successful teacher!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Teacher cannot be deleted");
            }
        }
    }
}
