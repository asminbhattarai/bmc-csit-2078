# Day 19 - 23rd Feb, 2025

## Write about:

### CDN

### jQuery

### Single Page Application and it's Importance

### Hosting and Deploying ASP .NET Core Application

### Hosting Model
> #### In-process Hosting (with IIS and ASP .NET Core)
> #### Out-of-process Hosting (with IIS, Kestrel Server and ASP .NET Core)

### DLL

```

[Nitesh]

CDN => content delivery network


jQuery => form validate



$("").onSubmit garda hernu hai sajilo kura



single page application importance
react, angular
-less load
-less round trip 
first template navigation and footer 
and remaining data are fetched dynamically


hosting and deploying asp.net core application:
application run in visual studio
exe file windows 

hosting model => in-process hosting, out-of-process hosting


in-process=> software for hosting application
we store our application
1.wenbserver->iis, internet infrastructure system
iis => window op vako web server cannot be used in Linux
Linux => apache engine 

out-of-process => Linux, mac, windows running asp.net core

kestrel server -> lightweight server to run asp.net core application in cross platform

https - in run windows
this is out-of-process

iis express


dotnot --info
dotnet --list-sdk =>software development kit

development kit run garna ko lagi
dotnet--list-runtimes

running from cmd
cd path
build to check for error
dotnet build
dotnet run


microsoft .dll =>dynamic link library


cd publish


kestrel or iis

running through kestrel 

enable iis which is by default deactivated

```

---

## Code:

`No need for separate code. Work with any MVC application.`

In this repo, MVC applications are in [this folder](../applications/).

---

## Steps to publish web application using IIS

1. Open your ASP .NET Core Web application in Visual Studio.

2. Right click on Solution Explorer window and click Publish option.

3. Click on Folder -> Next.

4. Change or note your publish location.

5. Click on finish and then, close the window.

6. Click on `Show all settings`.

7. Change Deployment Mode to Self-contained and Save.

8. Click on `Publish` button located on top right.

9. Install the [.NET Core Hosting Bundle](https://dotnet.microsoft.com/permalink/dotnetcore-current-windows-runtime-bundle-installer)

10. Open Control Panel -> Programs -> Turn Windows Features on or off.

11. Check mark Internet Information Services and Internet Information Services Hostable Web Core.

12. Optionally, check mark all of subcategories.

13. Copy your `publish` folder in `C:\inetpub\wwwroot\`. (Rename if you want to)

14. Search `inetmgr` and open IIS Manager.

15. On left side (`Connection's panel`), expand your device (or localhost).

16. Right click on Sites -> Add Website.

17. Assign a Site Name and set physical path as `C:\inetpub\wwwroot\your-publish-folder-name` (See step 10).

18. Note your Application Pool

19. Change Port to any: 81, 82, 83, .... (since 90 may already be in use).

20. Do not change or assign Host name.

21. On left side, click Application Pools.

22. In Application Pools, right click your application pool -> click Advanced Settings.

23. Change `Enable 32-Bit Applications` (second option from top) to True.

24. Click OK.

25. Optionally, right click your device (or localhost) on left side and refresh.

26. Expand your device (or localhost) on left side, click on Sites -> right clock your Site -> Manage Website -> Browse.

27. Your site should run on your defult browser at address: `http://localhost:your_port_number/`.
