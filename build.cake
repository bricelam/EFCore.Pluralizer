#tool nuget:?package=xunit.runner.console

var target = Argument<string>("target");
var configuration = Argument<string>("configuration");
var signOutput = HasArgument("signOutput");

Task("Restore")
    .Does(
        () =>
            NuGetRestore("EFCore.Pluralizer.sln"));

Task("Build")
    .IsDependentOn("Restore")
    .Does(
        () =>
            MSBuild(
                "EFCore.Pluralizer.sln",
                new MSBuildSettings
                {
                    ArgumentCustomization = args => args.Append("/nologo")
                }
                    .SetConfiguration(configuration)
                    .SetMaxCpuCount(0)
                    .SetVerbosity(Verbosity.Minimal)
                    .WithProperty("SignOutput", signOutput.ToString())));

Task("Clean")
    .Does(
        () =>
            MSBuild(
                "EFCore.Pluralizer.sln",
                new MSBuildSettings()
                    .SetConfiguration(configuration)
                    .WithTarget("Clean")));

Task("Test")
    .IsDependentOn("Build")
    .Does(
        () =>
            DotNetCoreTest(
                "./EFCore.Pluralizer.Test/EFCore.Pluralizer.Test.csproj",
                new DotNetCoreTestSettings
                {
                    Configuration = configuration,
                    NoBuild = true
                }));

RunTarget(target);
