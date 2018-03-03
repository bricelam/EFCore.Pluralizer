Bricelam.EntityFrameworkCore.Pluralizer
=======================================
This project is a working sample that adds design-time pluralization to Entity Framework Core.

Usage
-----
To use the package, simply install it. The pluralizer will be used when reverse engineering a model from an existing
database.

### Console:
``` sh
dotnet add package Bricelam.EntityFrameworkCore.Pluralizer --version 1.0.0-rc1
dotnet ef dbcontext scaffold "Data Source=chinook.db" Microsoft.EntityFrameworkCore.Sqlite
```

### PMC:
``` psm1
Install-Package Bricelam.EntityFrameworkCore.Pluralizer -Version 1.0.0-rc1
Scaffold-DbContext 'Data Source=chinook.db' Microsoft.EntityFrameworkCore.Sqlite
```

How it works
------------
On install, the package adds an assembly-level attribute to the project:


``` cs
[assembly: DesignTimeServicesReference(
    "Bricelam.EntityFrameworkCore.Design.EFCorePluralizerServices, Bricelam.EntityFrameworkCore.Pluralizer")]
```

This attribute points to a class that registers the `IPluralizer` service.

``` cs
class EFCorePluralizerServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection services)
        => services.AddSingleton<IPluralizer, Pluralizer>();
}
```

At design time, EF Core will find the assembly-level attribute and call the `ConfigureDesignTimeServies` method to
register additional services.