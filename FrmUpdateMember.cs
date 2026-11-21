using System;
using System.Data;
using System.Windows.Forms;

namespace Crisologo_JoshHarvey_RegistrationWithDB;

public partial class FrmUpdateMember : Form
{
    private readonly ClubRegistrationQuery query;
    private DataTable members = new();

    public FrmUpdateMember(ClubRegistrationQuery query)
    {
        InitializeComponent();
        this.query = query;
        cboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
        cboProgram.Items.AddRange(new object[] { "BS in Computer Science", "BS in Information Technology", "BS in Business Administration", "BS in Hospitality Management", "BS in Tourism Management" });
        Load += FrmUpdateMember_Load;
        cboStudentId.SelectedIndexChanged += CboStudentId_SelectedIndexChanged;
        btnConfirm.Click += BtnConfirm_Click;
    }

    private void FrmUpdateMember_Load(object? sender, EventArgs e)
    {
        try
        {
            members = query.GetMembers();
            foreach (DataRow row in members.Rows)
                cboStudentId.Items.Add(row["StudentId"].ToString()!);
            cboStudentId.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to load students: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CboStudentId_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cboStudentId.SelectedIndex < 0) return;
        foreach (DataRow row in members.Rows)
        {
            if (row["StudentId"].ToString() != cboStudentId.Text) continue;
            txtLastName.Text = row["LastName"].ToString();
            txtFirstName.Text = row["FirstName"].ToString();
            txtMiddleName.Text = row["MiddleName"].ToString();
            txtAge.Text = row["Age"].ToString();
            cboGender.Text = row["Gender"].ToString();
            cboProgram.Text = row["Program"].ToString();
            break;
        }
    }

    private void BtnConfirm_Click(object? sender, EventArgs e)
    {
        if (!long.TryParse(cboStudentId.Text, out long studentId) ||
            !int.TryParse(txtAge.Text.Trim(), out int age) || age <= 0 ||
            string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
            cboGender.SelectedIndex < 0 || cboProgram.SelectedIndex < 0)
        {
            MessageBox.Show("Select a Student ID and complete all required fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        try
        {
            if (!query.UpdateStudent(studentId, txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim(), age, cboGender.Text, cboProgram.Text))
            {
                MessageBox.Show("Student record not found.");
                return;
            }
            MessageBox.Show("Member information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Update failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
