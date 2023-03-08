using ConsoleTables;
using studentManagement.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace studentManagement.DatabaseService
{
    public class ConnectDatabase
    {
        public  SqlConnection sqlConnection;
        public string connectionString = @"Data Source=DESKTOP-ML4PHGF\JAMESTRAN;Initial Catalog=StudentManagement;Integrated Security=True";
        string LocationQueryString = "select Id, FullName, Gender, DateOfBirth, Email, PhoneNumber,Score, ClassId " + $"from [Student] ;";
        public void Connect()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }    
        public void PrintListStudent()
        {
            Connect();
            String displayQuery = "select * from Student";
            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlConnection);
            SqlDataReader dataReader = viewCommand.ExecuteReader();
            var table = new ConsoleTable("Id", "Name", "Gender","DateOfBirth", "EmailAddress", "PhoneNumber", "Score", "ClassId");
            int count = 0;
            while (dataReader.Read())
            {
                count++;
                table.AddRow(dataReader["Id"], dataReader["FullName"], dataReader["Gender"], dataReader["DateOfBirth"], dataReader["Email"], dataReader["PhoneNumber"], dataReader["Score"], dataReader["ClassId"]);
            }
            sqlConnection.Close();
            Console.WriteLine("count =", count);
            table.Write(Format.MarkDown);
        }
        public void PrintListClass()
        {
            Connect();
            String displayQuery = "select * from Class";
            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlConnection);
            SqlDataReader dataReader = viewCommand.ExecuteReader();
            var table = new ConsoleTable("ClassId", "ClassName", "TeacherId", "StartTime", "EndTime");
            int count = 0;
            while (dataReader.Read())
            {
                count++;
                table.AddRow(dataReader["ClassId"], dataReader["ClassName"], dataReader["TeacherId"], dataReader["StartTime"], dataReader["Endtime"]);
            }
            sqlConnection.Close();
            Console.WriteLine("count =", count);
            table.Write(Format.MarkDown);
        }
        public void PrintListTeacher()
        {
            Connect();
            String displayQuery = "select * from Teacher";
            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlConnection);
            SqlDataReader dataReader = viewCommand.ExecuteReader();
            var table = new ConsoleTable("TeacherId", "FullName", "DateOfBirth", "StartYear", "PhoneNumber", "Email");
            int count = 0;
            while (dataReader.Read())
            {
                count++;
                table.AddRow(dataReader["Id"], dataReader["FullName"], dataReader["DateOfBirth"], dataReader["StartYear"], dataReader["PhoneNumber"], dataReader["Email"]);
            }
            sqlConnection.Close();
            Console.WriteLine("count =", count);
            table.Write(Format.MarkDown);
        }

    }
}
