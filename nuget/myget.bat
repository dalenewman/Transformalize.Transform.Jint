nuget pack Transformalize.Transform.Jint.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Transform.Jint.Autofac.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Validate.Jint.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Validate.Jint.Autofac.nuspec -OutputDirectory "c:\temp\modules"

nuget pack Transformalize.Transform.Jint.3.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Transform.Jint.3.Autofac.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Validate.Jint.3.nuspec -OutputDirectory "c:\temp\modules"
nuget pack Transformalize.Validate.Jint.3.Autofac.nuspec -OutputDirectory "c:\temp\modules"

REM nuget push "c:\temp\modules\Transformalize.Transform.Jint.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Transform.Jint.Autofac.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
REM 
REM nuget push "c:\temp\modules\Transformalize.Validate.Jint.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Validate.Jint.Autofac.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
REM 
REM nuget push "c:\temp\modules\Transformalize.Transform.Jint.3.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Transform.Jint.3.Autofac.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
REM 
REM nuget push "c:\temp\modules\Transformalize.Validate.Jint.3.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Validate.Jint.3.Autofac.0.8.16-beta.nupkg" -source https://www.myget.org/F/transformalize/api/v3/index.json




