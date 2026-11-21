using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Crisologo_JoshHarvey_RegistrationWithDB;

public class ClubRegistrationQuery
{




    private readonly string connectionString =
        @"Server=ANNEX-PC00;Database=ClubDB;User Id=crisologo.421492;Password=123456;Encrypt=True;TrustServerCertificate=True;";



    public DataTable dataTable = new();
    public BindingSource bindingSource = new();

    public bool DisplayList()
    {
        const string sql = "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM dbo.ClubMembers ORDER BY ID";
        using var connection = new SqlConnection(connectionString);
        using var adapter = new SqlDataAdapter(sql, connection);
        dataTable.Clear();
        adapter.Fill(dataTable);
        bindingSource.DataSource = dataTable;
        return true;
    }

    public bool RegisterStudent(long studentId, string firstName, string middleName, string lastName, int age, string gender, string program)
    {
        const string sql = "INSERT INTO dbo.ClubMembers (StudentId, FirstName, MiddleName, LastName, Age, Gender, Program) VALUES (@StudentId, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)";
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand(sql, connection);
        AddParameters(command, studentId, firstName, middleName, lastName, age, gender, program);
        connection.Open();
        return command.ExecuteNonQuery() == 1;
    }

    public DataTable GetMembers()
    {
        var table = new DataTable();
        using var connection = new SqlConnection(connectionString);
        using var adapter = new SqlDataAdapter("SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM dbo.ClubMembers ORDER BY ID", connection);
        adapter.Fill(table);
        return table;
    }

    public bool UpdateStudent(long studentId, string firstName, string middleName, string lastName, int age, string gender, string program)
    {
        const string sql = "UPDATE dbo.ClubMembers SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Age=@Age, Gender=@Gender, Program=@Program WHERE StudentId=@StudentId";
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand(sql, connection);
        AddParameters(command, studentId, firstName, middleName, lastName, age, gender, program);
        connection.Open();
        return command.ExecuteNonQuery() == 1;
    }

    private static void AddParameters(SqlCommand command, long studentId, string firstName, string middleName, string lastName, int age, string gender, string program)
    {
        command.Parameters.Add("@StudentId", SqlDbType.BigInt).Value = studentId;
        command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
        command.Parameters.Add("@MiddleName", SqlDbType.VarChar, 50).Value = middleName;
        command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
        command.Parameters.Add("@Age", SqlDbType.Int).Value = age;
        command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = gender;
        command.Parameters.Add("@Program", SqlDbType.VarChar, 50).Value = program;
    }
}
