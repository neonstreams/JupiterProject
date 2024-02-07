# JupiterProject
Steps to run:
1. Open JupiterProject.sln in VS2022
2. Build Solution in Debug Mode (will default to this)
3. Run all tests via TestExplorer in VS2022
4. Additionally, to run via command line:
   cd to C:\JupiterProject\JupiterProject (depending on where you've saved the JupiterProject folder).
   Then use the following command: dotnet test JupiterProject.csproj --environment BROWSERNAME="chrome"
   To use FirefoxDriver as the WebDriver, use BROWSERNAME="firefox" instead.
