using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Crisologo_JoshHarvey_RegistrationWithDB;

public partial class FrmClubRegistration : Form
{
    private readonly ClubRegistrationQuery clubRegistrationQuery = new();

    public FrmClubRegistration()
    {
        InitializeComponent();
        cboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
        cboProgram.Items.AddRange(new object[] { "BS in Computer Science", "BS in Information Technology", "BS in Business Administration", "BS in Hospitality Management", "BS in Tourism Management" });
        Load += (_, _) => RefreshListOfClubMembers();
        btnRefresh.Click += (_, _) => RefreshListOfClubMembers();
        btnRegister.Click += BtnRegister_Click;
        btnUpdate.Click += BtnUpdate_Click;
    }

    private void RefreshListOfClubMembers()
    {
        try
        {
            clubRegistrationQuery.DisplayList();
            dataGridView.DataSource = clubRegistrationQuery.bindingSource;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to load club members: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnRegister_Click(object? sender, EventArgs e)
    {
        if (!long.TryParse(txtStudentId.Text.Trim(), out long studentId) || studentId <= 0 ||
            !int.TryParse(txtAge.Text.Trim(), out int age) || age <= 0 ||
            string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
            cboGender.SelectedIndex < 0 || cboProgram.SelectedIndex < 0)
        {
            MessageBox.Show("Enter a valid Student ID, name, age, gender, and program.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            clubRegistrationQuery.RegisterStudent(studentId, txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim(), age, cboGender.Text, cboProgram.Text);
            MessageBox.Show("Student registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtStudentId.Clear(); txtFirstName.Clear(); txtMiddleName.Clear(); txtLastName.Clear(); txtAge.Clear();
            cboGender.SelectedIndex = -1; cboProgram.SelectedIndex = -1;
            RefreshListOfClubMembers();
        }
        catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
        {
            MessageBox.Show("This Student ID is already registered.", "Duplicate Student ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Registration failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnUpdate_Click(object? sender, EventArgs e)
    {
        using var form = new FrmUpdateMember(clubRegistrationQuery);
        if (form.ShowDialog(this) == DialogResult.OK)
            RefreshListOfClubMembers();
    }
}
