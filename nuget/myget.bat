nuget pack Transformalize.Transform.Jint.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Transform.Jint.Autofac.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Validate.Jint.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Validate.Jint.Autofac.nuspec -OutputDirectory "c:\temp\modules"

nuget push "c:\temp\modules\Transformalize.Transform.Jint.0.11.2-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
nuget push "c:\temp\modules\Transformalize.Transform.Jint.Autofac.0.11.2-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json

nuget push "c:\temp\modules\Transformalize.Validate.Jint.0.11.2-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
nuget push "c:\temp\modules\Transformalize.Validate.Jint.Autofac.0.11.2-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
