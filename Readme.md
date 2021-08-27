<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581107/15.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T281449)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WizardConnectionStorageService/Form1.cs) (VB: [Form1.vb](./VB/WizardConnectionStorageService/Form1.vb))
* [Program.cs](./CS/WizardConnectionStorageService/Program.cs) (VB: [Program.vb](./VB/WizardConnectionStorageService/Program.vb))
<!-- default file list end -->
# How to define IConnectionStorageService filtering unnecessary connections from app.config


<p>This example demonstrates how to implement a custom <strong>IConnectionStorageService </strong>and use it instead of the default one in the data source wizard. This service implementation allows only getting connection parameters from the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardDesigner_CustomDataConnectionstopic">DashboardDesigner.CustomDataConnection</a> collection. To load the custom service instead of the default one, execute the following code:</p>


```cs
dashboardDesigner1.ServiceContainer.RemoveService(typeof(IConnectionStorageService));
dashboardDesigner1.ServiceContainer.AddService(typeof(IConnectionStorageService), new CustomConnectionStorageService(dashboardDesigner1));
```


<p>Note that starting with version 15.2 the connection from the app.config are not used by default. To enable this functionality use the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardDataSourceWizardSettings_ShowConnectionsFromAppConfigtopic">DashboardDesigner.DataSourceWizardSettings.ShowConnectionsFromAppConfig Property</a>. </p>

<br/>


