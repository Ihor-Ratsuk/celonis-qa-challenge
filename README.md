# How to run tests
1. Install dependencies:
    - Install Chrome browser: https://www.google.com/chrome/
    - Install dotnet core SDK: https://dotnet.microsoft.com/download
2. Unzip source code
3. Set user email and password in `Celonis.Cloud.Tests\configuration.json` file
4. Restore solution dependencies, run in command line: `dotnet restore`
5. Build solution, run in command line: `dotnet build`
6. Run tests:
    - Web API tests, run: `dotnet test --logger "trx;LogFileName=api.trx" -v=n --filter TestCategory=Api&TestCategor=Smoke`
    - UI tests: `dotnet test --logger "trx;LogFileName=ui.trx" -v=n --filter TestCategory=UI&TestCategory=Smoke&TestCategory!=NotAutomated`
7. Results will appear in console and log in trx format will appear in .\output
