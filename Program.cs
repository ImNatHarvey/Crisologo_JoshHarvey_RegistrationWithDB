using System;
using System.Windows.Forms;

namespace Crisologo_JoshHarvey_RegistrationWithDB;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmClubRegistration());
    }
}
