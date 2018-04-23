# How to define IConnectionStorageService filtering unnecessary connections from app.config


<p>This example demonstrates how to implement a custom <strong>IConnectionStorageService </strong>and use it instead of the default one in the data source wizard. This service implementation allows only getting connection parameters from the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardDesigner_CustomDataConnectionstopic">DashboardDesigner.CustomDataConnection</a> collection. To load the custom service instead of the default one, execute the following code:</p>


```cs
dashboardDesigner1.ServiceContainer.RemoveService(typeof(IConnectionStorageService));
dashboardDesigner1.ServiceContainer.AddService(typeof(IConnectionStorageService), new CustomConnectionStorageService(dashboardDesigner1));
```


<p>Note that starting with version 15.2 the connection from the app.config are not used by default. To enable this functionality use the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardDataSourceWizardSettings_ShowConnectionsFromAppConfigtopic">DashboardDesigner.DataSourceWizardSettings.ShowConnectionsFromAppConfig Property</a>. </p>

<br/>


