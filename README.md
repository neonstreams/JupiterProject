# JupiterProject
Steps to run:
1. Open JupiterProject.sln in VS2022
2. Build Solution in Debug Mode (will default to this)
3. Run all tests via TestExplorer
4. Additionally, to run via command line:
    4.1 cd to C:\JupiterProject\JupiterProject (depending on where you've saved the JupiterProject folder)
    4.2 Then use the following command: dotnet test JupiterProject.csproj --environment BROWSERNAME="chrome"
    4.3 To use FirefoxDriver as the WebDriver, use BROWSERNAME="firefox" instead.
