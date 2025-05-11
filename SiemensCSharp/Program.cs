using System.Configuration;
using Persistence.Repository;
using Service;

namespace SiemensCSharp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
    
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var dbFilePath = config.AppSettings.Settings["db_path"].Value;
        var connectionString = $"Data Source={dbFilePath}";
    
        var service = new ServiceImplementation(
            new BookRepository(connectionString),
            new BookLoanRepository(connectionString));
    
        var form = new Form1();
        form.Service = service;
        form.InitializeDataGrid();
    
        Application.Run(form);
    }
}