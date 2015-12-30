PATH %SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319;%VS110COMNTOOLS%\..\IDE;%VS120COMNTOOLS%\..\IDE;%VS130COMNTOOLS%\..\IDE;%VS140COMNTOOLS%\..\IDE

msbuild.exe MamaMia.sln /p:Configuration=Release /p:Platform="Any CPU"
mstest.exe /testcontainer:InputUnitTests\bin\Release\InputUnitTests.dll