using System.Drawing;
using System.Windows.Forms;

namespace Crisologo_JoshHarvey_RegistrationWithDB;

partial class FrmUpdateMember
{
    private System.ComponentModel.IContainer? components = null;
    private ComboBox cboStudentId = null!, cboGender = null!, cboProgram = null!;
    private TextBox txtLastName = null!, txtFirstName = null!, txtMiddleName = null!, txtAge = null!;
    private Button btnConfirm = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        cboStudentId = new ComboBox(); cboGender = new ComboBox(); cboProgram = new ComboBox();
        txtLastName = new TextBox(); txtFirstName = new TextBox(); txtMiddleName = new TextBox(); txtAge = new TextBox(); btnConfirm = new Button();
        SuspendLayout();
        ClientSize = new Size(180, 390);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Microsoft Sans Serif", 9F);
        Text = "FrmUpdateMember";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        AddLabel("Student ID:", 10, 12);
        cboStudentId.SetBounds(10, 31, 157, 23);
        AddLabel("Last name:", 10, 60);
        txtLastName.SetBounds(10, 79, 142, 23);
        AddLabel("First Name:", 10, 108);
        txtFirstName.SetBounds(10, 127, 142, 23);
        AddLabel("Middle name:", 10, 156);
        txtMiddleName.SetBounds(10, 175, 142, 23);
        AddLabel("Age:", 10, 204);
        txtAge.SetBounds(10, 223, 92, 23);
        AddLabel("Gender:", 10, 252);
        cboGender.SetBounds(10, 271, 112, 23);
        AddLabel("Program:", 10, 300);
        cboProgram.SetBounds(10, 319, 157, 23);
        cboStudentId.DropDownStyle = ComboBoxStyle.DropDownList;
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProgram.DropDownStyle = ComboBoxStyle.DropDownList;
        btnConfirm.Text = "Confirm";
        btnConfirm.SetBounds(50, 351, 80, 28);
        Controls.AddRange(new Control[] { cboStudentId, txtLastName, txtFirstName, txtMiddleName, txtAge, cboGender, cboProgram, btnConfirm });
        ResumeLayout(false);
        PerformLayout();
    }

    private void AddLabel(string text, int x, int y)
    {
        var label = new Label { Text = text, Location = new Point(x, y), Size = new Size(155, 18) };
        Controls.Add(label);
    }
}
