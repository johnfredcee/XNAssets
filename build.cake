var target = Argument("target", "Pack");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"./bin/MonoGame/{configuration}");
});	

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetBuild("./XNAssets.csproj", new DotNetBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Pack")
	.IsDependentOn("Build")
	.Does(() =>
{
	DotNetPack("./XNAssets.csproj", new DotNetPackSettings
	{
		Configuration = configuration,
		IncludeSource = true
	});
});
/*
Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetTest("./XNAssets", new DotNetTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
    });
});
*/

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);