@echo off
SETLOCAL

".nuget\NuGet.exe" "Install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion"
".nuget\NuGet.exe" "Install" "xunit.runner.console" "-OutputDirectory" "packages" "-ExcludeVersion"

SET branch=%APPVEYOR_REPO_BRANCH%
SET prnumber=%APPVEYOR_PULL_REQUEST_NUMBER%
SET publish=true
SET prerelease=false
SET version=%APPVEYOR_BUILD_VERSION%
SET packageversion=%version%

IF "%branch%" NEQ "master" SET prerelease=true
IF "%prnumber%" NEQ "" SET publish=false

IF %prerelease%==true (
  SET packageversion=%packageversion%-%branch%
)

IF %publish%==true (
  SET target=Publish
) ELSE (
  SET target=RunTests
)

"packages\FAKE\tools\Fake.exe" "build.fsx" target=%target% version=%version% packageversion=%packageversion% projects=Sequin.ClaimsAuthentication;Sequin.ClaimsAuthentication.Core nugetApiKey=%NUGET_API_KEY% %*
