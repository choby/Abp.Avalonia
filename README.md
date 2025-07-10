# Abp.Avalonia

## About this solution

This project fully demonstrates the integration of Abp vNext in Avalonia UI framework, supports the invocation of Application Service in the Model layer, and fully supports DDD. Where Abp.Avalonia.Desktop is the Avalonia project.

The UI layer, in addition to using Avalonia, also references Suki UI.

### Pre-requirements

* [Avalonia 11.3.2](https://avaloniaui.net/)
* [SukiUI 6.0.2](https://github.com/kikipoulet/SukiUI)
* [.NET9.0+ SDK](https://dotnet.microsoft.com/download/dotnet)
* [Node v18 or 20](https://nodejs.org/en)

### Configurations

The solution comes with a default configuration that works out of the box. However, you may consider to change the following configuration before running your solution:

* Check the `ConnectionStrings` in `appsettings.json` files under the `Abp.Avalonia.Desktop`、 `Abp.Avalonia.Web` and `Abp.Avalonia.DbMigrator` projects and change it if you need.

### Before running the application

* Run `abp install-libs` command on your solution folder to install client-side package dependencies. This step is automatically done when you create a new solution, if you didn't especially disabled it. However, you should run it yourself if you have first cloned this solution from your source control, or added a new client-side package dependency to your solution.
* Run `Abp.Avalonia.DbMigrator` to create the initial database. This step is also automatically done when you create a new solution, if you didn't especially disabled it. This should be done in the first run. It is also needed if a new database migration is added to the solution later.

#### Generating a Signing Certificate

In the production environment, you need to use a production signing certificate. ABP Framework sets up signing and encryption certificates in your application and expects an `openiddict.pfx` file in your application.

To generate a signing certificate, you can use the following command:

```bash
dotnet dev-certs https -v -ep openiddict.pfx -p f7d8280a-2e38-49d4-ae90-57a247e29cd2
```

> `f7d8280a-2e38-49d4-ae90-57a247e29cd2` is the password of the certificate, you can change it to any password you want.

It is recommended to use **two** RSA certificates, distinct from the certificate(s) used for HTTPS: one for encryption, one for signing.

For more information, please refer to: [OpenIddict Certificate Configuration](https://documentation.openiddict.com/configuration/encryption-and-signing-credentials.html#registering-a-certificate-recommended-for-production-ready-scenarios)

> Also, see the [Configuring OpenIddict](https://abp.io/docs/latest/Deployment/Configuring-OpenIddict#production-environment) documentation for more information.

### Solution structure

This is a layered monolith application that consists of the following applications:

* `Abp.Avalonia.Desktop`: Avalonia application that is the Desktop client application of the solution.
* `Abp.Avalonia.DbMigrator`: A console application which applies the migrations and also seeds the initial data. It is useful on development as well as on production environment.
* `Abp.Avalonia.Web`: ASP.NET Core MVC / Razor Pages application that is the essential web application of the solution.


## Deploying the application

Deploying an ABP application follows the same process as deploying any .NET or ASP.NET Core application. However, there are important considerations to keep in mind. For detailed guidance, refer to ABP's [deployment documentation](https://abp.io/docs/latest/Deployment/Index).

### Additional resources

You can see the following resources to learn more about your solution and the ABP Framework:

* [Avalonia Turoaial](https://docs.avaloniaui.net/docs/welcome)
* [Web Application Development Tutorial](https://abp.io/docs/latest/tutorials/book-store/part-1)
* [Application Startup Template](https://abp.io/docs/latest/startup-templates/application/index)
