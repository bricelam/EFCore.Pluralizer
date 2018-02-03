var target = Argument<string>("target");
var configuration = Argument<string>("configuration");
var signOutput = HasArgument("signOutput");

Task("Build")
    .Does(
        () =>
            DotNetCoreBuild(
                "EFCore.Pluralizer.sln",
                new DotNetCoreBuildSettings
                {
                    Configuration = configuration,
                    MSBuildSettings = new DotNetCoreMSBuildSettings
                    {
                        MaxCpuCount = 0,
                        NoLogo = true,
                        Properties =
                        {
                            { "SignOutput", new[] { signOutput.ToString() } }
                        }
                    }
                }));

Task("Test")
    .IsDependentOn("Build")
    .Does(
        () =>
            DotNetCoreTest(
                "EFCore.Pluralizer.Test/EFCore.Pluralizer.Test.csproj",
                new DotNetCoreTestSettings
                {
                    Configuration = configuration,
                    NoBuild = true,
                    NoRestore = true
                }));

RunTarget(target);
