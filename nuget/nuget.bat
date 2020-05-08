REM nuget pack Transformalize.Transform.Jint.nuspec -OutputDirectory "c:\temp\modules"
REM nuget pack Transformalize.Transform.Jint.Autofac.nuspec -OutputDirectory "c:\temp\modules"
REM nuget pack Transformalize.Validate.Jint.nuspec -OutputDirectory "c:\temp\modules"
REM nuget pack Transformalize.Validate.Jint.Autofac.nuspec -OutputDirectory "c:\temp\modules"
REM Jint v3+ Ones right-click and pack

REM nuget push "c:\temp\modules\Transformalize.Transform.Jint.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Transform.Jint.Autofac.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json
REM 
REM nuget push "c:\temp\modules\Transformalize.Validate.Jint.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json
REM nuget push "c:\temp\modules\Transformalize.Validate.Jint.Autofac.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json

nuget push "c:\temp\modules\Transformalize.Transform.Jint.3.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json
nuget push "c:\temp\modules\Transformalize.Transform.Jint.3.Autofac.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json

nuget push "c:\temp\modules\Transformalize.Validate.Jint.3.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json
nuget push "c:\temp\modules\Transformalize.Validate.Jint.3.Autofac.0.7.6-beta.nupkg" -source https://api.nuget.org/v3/index.json




