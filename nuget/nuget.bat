nuget pack Transformalize.Transform.Jint.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Transform.Jint.Autofac.nuspec -OutputDirectory "c:\temp\modules"

nuget push "c:\temp\modules\Transformalize.Transform.Jint.0.3.6-beta.nupkg" -source https://api.nuget.org/v3/index.json
nuget push "c:\temp\modules\Transformalize.Transform.Jint.Autofac.0.3.6-beta.nupkg" -source https://api.nuget.org/v3/index.json






