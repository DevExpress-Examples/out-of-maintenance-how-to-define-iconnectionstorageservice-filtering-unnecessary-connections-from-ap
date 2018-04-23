Imports DevExpress.DashboardWin
Imports DevExpress.DataAccess
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.DataAccess.Wizard.Model
Imports DevExpress.DataAccess.Wizard.Services
Imports DevExpress.XtraBars.Ribbon
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace WizardCustomizationExample1
    Partial Public Class Form1
        Inherits RibbonForm

        Public Sub New()
            InitializeComponent()

            dashboardDesigner1.ServiceContainer.RemoveService(GetType(IConnectionStorageService))
            dashboardDesigner1.ServiceContainer.AddService(GetType(IConnectionStorageService), New CustomConnectionStorageService(dashboardDesigner1))

            Dim cpNorthwind As New MsSqlConnectionParameters() With {.ServerName = "localhost", .AuthorizationType = MsSqlAuthorizationType.Windows, .DatabaseName = "Northwind"}
            Dim cpAdventureWorks As New MsSqlConnectionParameters() With {.ServerName = "localhost", .AuthorizationType = MsSqlAuthorizationType.Windows, .DatabaseName = "AdventureWorksDW2012"}
            Dim cpContosoRetail As New MsSqlConnectionParameters() With {.ServerName = "localhost", .AuthorizationType = MsSqlAuthorizationType.Windows, .DatabaseName = "ContosoRetailDW"}
            dashboardDesigner1.CustomDataConnections.Add(New DataConnection("Local Northwind Connection", cpNorthwind))
            dashboardDesigner1.CustomDataConnections.Add(New DataConnection("Local AdventureWorks Connection", cpAdventureWorks))
            dashboardDesigner1.CustomDataConnections.Add(New DataConnection("Local ContosoRetail Connection", cpContosoRetail))
        End Sub
    End Class
    Public Class CustomConnectionStorageService
        Implements IConnectionStorageService

        Private ReadOnly designer As DashboardDesigner

        Public Sub New(ByVal designer As DashboardDesigner)
            Me.designer = designer
        End Sub
        Public ReadOnly Property CanSaveConnection() As Boolean Implements IConnectionStorageService.CanSaveConnection
            Get
                Return False
            End Get
        End Property
        Public Function Contains(ByVal connectionName As String) As Boolean Implements IConnectionStorageService.Contains
            Return designer.CustomDataConnections.Any(Function(connection) connection.Name = connectionName)
        End Function

        Public Function GetConnections() As IEnumerable(Of SqlDataConnection) Implements IConnectionStorageService.GetConnections
            Return designer.CustomDataConnections
        End Function

        Public Sub SaveConnection(ByVal connectionName As String, ByVal connection As IDataConnection, ByVal saveCredentials As Boolean) Implements IConnectionStorageService.SaveConnection
            Throw New NotSupportedException()
        End Sub
    End Class
End Namespace
