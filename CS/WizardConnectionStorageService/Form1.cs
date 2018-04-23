using DevExpress.DashboardWin;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Wizard.Model;
using DevExpress.DataAccess.Wizard.Services;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardCustomizationExample1
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();

            dashboardDesigner1.ServiceContainer.RemoveService(typeof(IConnectionStorageService));
            dashboardDesigner1.ServiceContainer.AddService(typeof(IConnectionStorageService), new CustomConnectionStorageService(dashboardDesigner1));

            MsSqlConnectionParameters cpNorthwind = new MsSqlConnectionParameters()
            {
                ServerName = "localhost",
                AuthorizationType = MsSqlAuthorizationType.Windows,
                DatabaseName = "Northwind"
            };
            MsSqlConnectionParameters cpAdventureWorks = new MsSqlConnectionParameters()
            {
                ServerName = "localhost",
                AuthorizationType = MsSqlAuthorizationType.Windows,
                DatabaseName = "AdventureWorksDW2012"
            };
            MsSqlConnectionParameters cpContosoRetail = new MsSqlConnectionParameters()
            {
                ServerName = "localhost",
                AuthorizationType = MsSqlAuthorizationType.Windows,
                DatabaseName = "ContosoRetailDW"
            };
            dashboardDesigner1.CustomDataConnections.Add(new DataConnection("Local Northwind Connection", cpNorthwind));
            dashboardDesigner1.CustomDataConnections.Add(new DataConnection("Local AdventureWorks Connection", cpAdventureWorks));
            dashboardDesigner1.CustomDataConnections.Add(new DataConnection("Local ContosoRetail Connection", cpContosoRetail));
        }
    }
    public class CustomConnectionStorageService : IConnectionStorageService
    {
        readonly DashboardDesigner designer;

        public CustomConnectionStorageService(DashboardDesigner designer)
        {
            this.designer = designer;
        }
        public bool CanSaveConnection
        {
            get { return false; }
        }
        public bool Contains(string connectionName)
        {
            return designer.CustomDataConnections.Any(connection => connection.Name == connectionName);
        }

        public IEnumerable<SqlDataConnection> GetConnections()
        {
            return designer.CustomDataConnections;
        }

        public void SaveConnection(string connectionName, IDataConnection connection, bool saveCredentials)
        {
            throw new NotSupportedException();
        }
    }
}
