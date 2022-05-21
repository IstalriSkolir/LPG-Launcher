      # LPG-Launcher

A launcher containing all the game jam games from the LowPoly Games team. This solution contains two projects, the first is a C# WPF application which is the launcher
itself and the second is a C# WindForms application to generate GameData files. The GameData files are for the launcher to store what games the launcher has along
with details about the game.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

      REQUIREMENTS

1. Visual Studio 2019
2. Inno Setup 6
3. Notepad++ (Optional)

      Visual Studio 2019

The main solution is a Visual Studio 2019 solution. When building on the release profile, a installer is built and output to LPG-Launcher/Output. If more than five
installers are present in the folder then the oldest installer/s are deleted as part of the build process.


      Inno Setup 6
      
Inno Setup is required both to edit 'Installer Script.iss' which is used to compile an installer. Inno Setup 6 needs to installed for this or a installer won't be
compiled and Visual Studio will report errors in the 'Output' window when building the solution.

      Notepad++
      
Notepad++ isn't required for anything in this repo but it is suggested for quick editting of some file types.
