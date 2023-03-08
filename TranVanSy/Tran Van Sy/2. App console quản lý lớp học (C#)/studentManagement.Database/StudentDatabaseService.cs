using ConsoleTables;
using studentManagement.Data;
using studentManagement.DatabaseService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Database
{
    public class StudentDatabaseService
    {
        public string connectionString = @"Data Source=DESKTOP-ML4PHGF\JAMESTRAN;Initial Catalog=StudentManagement;Integrated Security=True";
        public SqlConnection sqlConnection;
        private readonly List<Student> _students = new();
        public StudentDatabaseService()
        {
            this._students = DummyData.Students;
        }
        public List<Student> getListStudent()
        {
            return this._students;
        }
        public List<Student> GetListStudent()
        {
            List<Student> list = new List<Student>();
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string selectQuery = "select * from Student";
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
                var sqlReader = selectCommand.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Student student = new Student();
                        student.Id = (int)sqlReader["Id"];
                        student.Name = (string)sqlReader["Fullname"];
                        student.Gender = (string)sqlReader["Gender"];
                        student.DateOfBirth = (DateTime)sqlReader["DateOfBirth"];
                        student.EmailAddress = (string)sqlReader["Email"];
                        student.PhoneNumber = (string)sqlReader["PhoneNumber"];
                        student.Score = (double)sqlReader["Score"];
                        student.ClassId = (int)sqlReader["ClassId"];
                        list.Add(student);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            return list;
        }
        public void AddStudent(int Id, string Name, string Gender,DateTime DateOfBirth, string Email, string PhoneNumber, double Score, int ClassId)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "insert into Student (Id, FullName, Gender, DateOfBirth, Email, PhoneNumber, Score, ClassId) values (@Id, @FullName, @Gender,@DateOfBirth, @Email, @PhoneNumber, @Score, @ClassId);";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@Id", Id);

                insertCommand.Parameters.AddWithValue("@FullName", Name);

                insertCommand.Parameters.AddWithValue("@Gender", Gender);

                insertCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                insertCommand.Parameters.AddWithValue("@Email", Email);

                insertCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                insertCommand.Parameters.AddWithValue("@Score", Score);

                insertCommand.Parameters.AddWithValue("@ClassId", ClassId);

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //take out the largest id
        public int GenerateId()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string findMaxId = "select MAX(Id) from Student";
            using var findMaxIdCommand = new SqlCommand(findMaxId,sqlConnection);
            int max = (int)findMaxIdCommand.ExecuteScalar();
            sqlConnection.Close();
            return max;

        }
        public void UpDateStudent(Student student, int Id)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = $"update Student set FullName=' {student.Name} ', Gender= '{student.Gender}', DateOfBirth= '{student.DateOfBirth}', Email='{student.EmailAddress}',PhoneNumber = '{student.PhoneNumber}', Score = {student.Score}, ClassId = {student.ClassId} where Id=@Id";
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
        public void DeleteStudent( int Id)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "delete from student where Id =@Id ";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                insertCommand.Parameters.AddWithValue("@Id", Id);

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
                Console.WriteLine("delete successful student!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void StudentOfClass()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "select ClassId, Count(Id) 'number student' from Student group by ClassId order by ClassId asc";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                var listCommand = insertCommand.ExecuteReader();
                var table = new ConsoleTable("ClassId", "Student in class");
                while (listCommand.Read())
                {
                    table.AddRow(listCommand["ClassId"], listCommand["number student"]);
                }
                table.Write(Format.MarkDown);
                sqlConnection.Close();
                Console.WriteLine("delete successful student!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void TopHightScore(int ClassId)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "select top 10* from Student where ClassId=@ClassId order by Score desc;";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.Parameters.AddWithValue("@ClassId", ClassId);
                var listCommand = insertCommand.ExecuteReader();
                var table = new ConsoleTable("Id", "FullName","Gender","DateOfBirth","Email","PhoneNumBer","Score","ClassId");
                while (listCommand.Read())
                {
                    table.AddRow(listCommand["Id"], listCommand["FullName"], listCommand["Gender"], listCommand["DateOfBirth"], listCommand["Email"], listCommand["PhoneNumber"], listCommand["Score"], listCommand["ClassId"]);
                }
                table.Write(Format.MarkDown);
                sqlConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void MaleStudent()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "select ClassId, count(Id) 'Male Student' from Student where Gender='Male' group by ClassId order by ClassId asc";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                var listCommand = insertCommand.ExecuteReader();
                var table = new ConsoleTable("ClassId", "Male tudent in class");
                while (listCommand.Read())
                {
                    table.AddRow(listCommand["ClassId"], listCommand["Male Student"]);
                }
                table.Write(Format.MarkDown);
                sqlConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AvgScore()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "select ClassId, avg(Score) 'Avg score' from Student group by ClassId order by Classid asc";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                var listCommand = insertCommand.ExecuteReader();
                var table = new ConsoleTable("ClassId", "Avg Score");
                while (listCommand.Read())
                {
                    table.AddRow(listCommand["ClassId"], listCommand["Avg score"]);
                }
                table.Write(Format.MarkDown);
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ClassOfTeacher(int teacherid)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "select TeacherId, FullName, ClassName, StartTime, EndTime from Class c, Teacher t where c.TeacherId=t.Id and TeacherId=@TeacherId";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.Parameters.AddWithValue("@TeacherId", teacherid);
                var listCommand = insertCommand.ExecuteReader();
                var table = new ConsoleTable("TeacherId", "FullName", "ClassName", "StartTime", "EndTime");
                while (listCommand.Read())
                {
                    table.AddRow(listCommand["TeacherId"], listCommand["FullName"], listCommand["ClassName"], listCommand["StartTime"], listCommand["EndTime"]);
                }
                table.Write(Format.MarkDown);
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void TeacherWithTheMostClasses()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "select TeacherId,  count(ClassId) 'Number of class' from Class group by TeacherId having count(ClassId)>=all(select count(classId) from Class group by TeacherId)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                var listCommand = insertCommand.ExecuteReader();
                var table = new ConsoleTable("TeacherId", "Number of class");
                while (listCommand.Read())
                {
                    table.AddRow(listCommand["TeacherId"], listCommand["Number of class"]);
                }
                table.Write(Format.MarkDown);
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void TeacherAndHeightScore()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "select top 10 Teacher.Id 'TeacherId',Teacher.FullName, Teacher.DateOfBirth,Teacher.Email,Teacher.PhoneNumber,Teacher.StartYear, Class.ClassId, KQ.[Average of score] from Teacher ,Class, (select top 10 Class.ClassId, AVG(Score)'Average of score' from Class, Student, Teacher where Student.ClassId= Class.ClassId and Class.TeacherId= Teacher.Id group by Class.ClassId order by AVG(Score) desc)as KQ where  Class.TeacherId= Teacher.Id and kq.ClassId= Class.ClassId";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                var listCommand = insertCommand.ExecuteReader();
                var table = new ConsoleTable("TeacherId", "FullName", "DateOfBirth", "Email", "PhoneNumber","StartYear","ClassId","Avg score");
                while (listCommand.Read())
                {
                    table.AddRow(listCommand["TeacherId"], listCommand["FullName"], listCommand["DateOfBirth"], listCommand["Email"], listCommand["PhoneNumber"], listCommand["StartYear"], listCommand["ClassId"], listCommand["Average of score"]);
                }
                table.Write(Format.MarkDown);
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
