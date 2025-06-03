dotnet sonarscanner begin ^
  /k:"murgocimark_net.core" ^
  /o:"murgocimark" ^
  /d:sonar.host.url="https://sonarcloud.io" ^
  /d:sonar.login="2727a1a9c2923f91549cb82baf3c0decd5088aaa"
	/d:sonar.cs.vstest.reportsPaths="tests/Invoice.Tests/TestResults/test_results.trx" ^
  /d:sonar.cs.opencover.reportsPaths="tests/Invoice.Tests/TestResults/coverage.cobertura.xml"
  
dotnet build

dotnet test --logger:"trx;LogFileName=TestResults/test_results.trx" --collect:"XPlat Code Coverage" --results-directory tests/Invoice.Tests/TestResults

dotnet sonarscanner end ^
  /d:sonar.login="2727a1a9c2923f91549cb82baf3c0decd5088aaa"
