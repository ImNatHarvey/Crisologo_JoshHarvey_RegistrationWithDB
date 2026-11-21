using System.Drawing;
using System.Windows.Forms;

namespace Crisologo_JoshHarvey_RegistrationWithDB;

partial class FrmClubRegistration
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox grpDetails = null!, grpMembers = null!;
    private Label lblStudentId = null!, lblLastName = null!, lblFirstName = null!, lblMiddleName = null!, lblAge = null!, lblGender = null!, lblProgram = null!;
    private TextBox txtStudentId = null!, txtLastName = null!, txtFirstName = null!, txtMiddleName = null!, txtAge = null!;
    private ComboBox cboGender = null!, cboProgram = null!;
    private Button btnRegister = null!, btnUpdate = null!, btnRefresh = null!;
    private DataGridView dataGridView = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        grpDetails = new GroupBox(); grpMembers = new GroupBox();
        lblStudentId = new Label(); lblLastName = new Label(); lblFirstName = new Label(); lblMiddleName = new Label(); lblAge = new Label(); lblGender = new Label(); lblProgram = new Label();
        txtStudentId = new TextBox(); txtLastName = new TextBox(); txtFirstName = new TextBox(); txtMiddleName = new TextBox(); txtAge = new TextBox();
        cboGender = new ComboBox(); cboProgram = new ComboBox();
        btnRegister = new Button(); btnUpdate = new Button(); btnRefresh = new Button();
        dataGridView = new DataGridView();
        SuspendLayout();
        grpDetails.SuspendLayout(); grpMembers.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();

        // Original laboratory screenshot: upper input area and lower member list.
        ClientSize = new Size(710, 400);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Microsoft Sans Serif", 9F);
        Text = "FrmClubRegistration";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = SystemColors.Control;

        grpDetails.SetBounds(10, 10, 594, 164);
        grpDetails.TabStop = false;
        grpMembers.SetBounds(10, 179, 690, 211);
        grpMembers.Text = "List Of Club Members";

        SetupLabel(lblStudentId, "Student ID:", 10, 12, 145);
        SetupLabel(lblProgram, "Program:", 378, 12, 150);
        SetupLabel(lblLastName, "Last name:", 10, 58, 160);
        SetupLabel(lblFirstName, "First Name:", 196, 58, 160);
        SetupLabel(lblMiddleName, "Middle name:", 378, 58, 160);
        SetupLabel(lblAge, "Age:", 10, 104, 100);
        SetupLabel(lblGender, "Gender:", 196, 104, 130);
        txtStudentId.SetBounds(10, 30, 155, 23);
        cboProgram.SetBounds(378, 30, 188, 23);
        txtLastName.SetBounds(10, 76, 169, 23);
        txtFirstName.SetBounds(196, 76, 168, 23);
        txtMiddleName.SetBounds(378, 76, 168, 23);
        txtAge.SetBounds(10, 122, 109, 23);
        cboGender.SetBounds(196, 122, 135, 23);
        cboProgram.DropDownStyle = ComboBoxStyle.DropDownList;
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
        grpDetails.Controls.AddRange(new Control[] { lblStudentId, lblProgram, lblLastName, lblFirstName, lblMiddleName, lblAge, lblGender, txtStudentId, cboProgram, txtLastName, txtFirstName, txtMiddleName, txtAge, cboGender });

        btnRegister.Text = "Register"; btnRegister.SetBounds(614, 10, 86, 32);
        btnUpdate.Text = "Update"; btnUpdate.SetBounds(614, 47, 86, 32);
        btnRefresh.Text = "Refresh"; btnRefresh.SetBounds(604, 20, 86, 32);
        dataGridView.SetBounds(10, 20, 584, 180);
        dataGridView.BackgroundColor = Color.DarkGray;
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AllowUserToDeleteRows = false;
        dataGridView.ReadOnly = true;
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        dataGridView.RowHeadersWidth = 25;
        grpMembers.Controls.Add(dataGridView);
        grpMembers.Controls.Add(btnRefresh);
        Controls.AddRange(new Control[] { grpDetails, grpMembers, btnRegister, btnUpdate });
        ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit(); grpMembers.ResumeLayout(false); grpDetails.ResumeLayout(false); ResumeLayout(false);
    }

    private static void SetupLabel(Label label, string text, int x, int y, int width)
    {
        label.Text = text;
        label.SetBounds(x, y, width, 18);
    }
}
