echo off

nuget sources

set /P source="source: "

IF NOT "%source%" EQU "" (

	nuget push -source %source% -apikey VSTS bin\release\Xanadu.RangePower.1.0.0.nupkg

	pause
)