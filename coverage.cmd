md coverage

packages\OpenCover.4.5.3723\OpenCover.Console.exe -register:user -target:packages\NUnit.Runners.2.6.4\tools\nunit-console-x86.exe -targetargs:"SwedishCoordinates.Tests\bin\Debug\SwedishCoordinates.Tests.dll /noshadow /xml=coverage\TestResult.xml" -filter:"+[SwedishCoordinates*]* -[SwedishCoordinates.Tests*]*" -output:coverage\opencovertests.xml

packages\ReportGenerator.2.1.4.0\ReportGenerator.exe -reports:"coverage\opencovertests.xml" -targetdir:"coverage"

pause