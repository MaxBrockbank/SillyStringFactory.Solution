<h1 align="center">~Dr.Sillystringz's Factory~</h1>
<div align="center">
<img src="https://github.com/MaxBrockbank.png" width="200px" height="auto" >
</div>
<p align="center">Authored by Max Brockabnk</p>
<p align="center">Updated on Friday, January 8th, 2021</p>

# Description
This project is a practice in using C# ASP.NET Core along with Entity Framework Core and MySQL to create an application to keep track of engineers that work in the Dr.Sillystringz factor, the machines in the factory, and the relationship between them.


## Required Technologies
* C# .NET Core Ver 2.2.0
* MySQL Ver 8.0.15 and MySQL Workbench
* Text editor
* Modern web browser 

### Set-up Instructions

#### Cloning this repo
1. Begin by clicking on this green button on the right side of the screen that says 'Code'.
2. To clone the repo you'll want to click on the clipboard icon next to where you see a URL in a text input. This will copy this url for the repo to your clipboard
3. Open your computer termianl and navigate to whichever directory you'd like this project to live in.
4. Then run the command `git clone (Paste URL here)`. Additionally if you'd like to give this project's root directory a specific name you can run `git clone (Paste URL here) (New directory name)`. (Do not include the parens in these commands)
5. Run `cd SillyStringFactory.Solution` or `cd (Whatever you changed the directory name to)` to then navigate to the project root directory.

#### Generate MySQL Database Using Entity Framework Core
1. In your terminal navigate to the SillyStringFactory.Solution/Factory directory. `cd Factory`.
2. Run the command `dotnet ef database update`. Entity Framework Core will then generate the database structure using the included migration files. 
3. __OPTIONALLY__, should you need to make changes to the code that adjust the structure of the databse, you can apply those updates with the following two commands. 
* `dotnet ef mirgrations add (Migration name here)`
* `dotnet ef database update`

#### Import Database using MySQL Workbench
1. Open your MySQL workbench and enter the password you set on installation.
2. Go to the nav bar at the top, click on Server > Data Import.
3. Use the the option Import from Self-Contained File. Use the `max_brockbank.sql` file in the root directory of this project.
4. Set the Default Target Schema or create a new one.
5. Select all Schema Objects you wish to import.
6. Select Dump Structure and Data.
7. Start Import.



### Setting up `appsettings.json`
1. Open the appsettings.json file
2. Change the `uid`, `port`, and `pwd` to your machine's configurations.

## Technologies Used
* C# .NET Core
* ASP.NET Core
* ASP.NET Core Razor Pages
* Entity Framework Core
* MySQL

## Known Bugs
* No currently known bugs, please contact me if any found 


## Contact 
* [maxbrockbank1999@gmail.com](mailto:maxbrockbank1999@gmail.com)


## Legal
* Copyright © 2020 Max Brockbank
* This software is licensed under the MIT license