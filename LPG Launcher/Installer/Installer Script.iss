#define AppName "LowPoly Games Launcher"
#define AppPublisher "LowPoly Games"
#define AppVersion GetFileVersion("..\bin\Release\net5.0-windows\LPG Launcher.exe")
#define AppEXEName "LPG Launcher.exe"
#define AppURL "https://lowpolygames.itch.io/"
#define AppSetupIcon "Resources\LogoSetup.ico"
#define AppUninstallIcon "Resources\LogoUninstall.ico"

[Setup]
AppId={{1c2dga42-g5s6-10d3-af3g-9bv3nf9ewj34}
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64
AppName={#AppName}
AppVerName={#AppName} {#AppVersion}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
DefaultDirName={pf}\LowPoly Games\{#AppName}
DefaultGroupName={#AppPublisher}
Compression=lzma2
SolidCompression=yes
OutputBaseFilename=LPG Launcher Installer {#AppVersion}
SetupIconFile={#AppSetupIcon}
UninstallDisplayIcon={#AppUninstallIcon}
OutputDir=..\Output

[Files]
Source: "..\bin\Release\net5.0-windows\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs;
Source: "Resources\windowsdesktop-runtime-5.0.17-win-x64.exe"; DestDir: "{app}"; Flags: ignoreversion deleteafterinstall
Source: "Resources\READ-ME.txt"; DestDir: "{app}"; Flags: isreadme;
Source: "Resources\Logo.ico"; DestDir: "{app}\Resources";

[Icons]
Name: "{commondesktop}\LPG Launcher"; Filename: "{app}\LPG Launcher.exe"; IconFilename: "{app}\Resources\Logo.ico"; Tasks: desktopicon;

[Tasks]
Name: desktopicon; Description: "Create a Desktop Shortcut";

[Run]
Filename: "{app}\{#AppEXEName}"; Description: "{cm:LaunchProgram, {#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall
Filename: "{app}\windowsdesktop-runtime-5.0.17-win-x64.exe"; Parameters: "/q/passive"; Flags: waituntilterminated; Check: CheckIsDotNetDetected() ; StatusMsg: Microsoft .NET Framework 5.0 is being installed. Please wait...

[Code]
function DotNetInstalled(DotNetName: string): Boolean;
var
  Cmd, Args: string;
  FileName: string;
  Output: AnsiString;
  Command: string;
  ResultCode: Integer;
begin
  FileName := ExpandConstant('{tmp}\dotnet.txt');
  Cmd := ExpandConstant('{cmd}');
  Command := 'dotnet --list-runtimes';
  Args := '/C ' + Command + ' > "' + FileName + '" 2>&1';
  if Exec(Cmd, Args, '', SW_HIDE, ewWaitUntilTerminated, ResultCode) and
     (ResultCode = 0) then
  begin
    if LoadStringFromFile(FileName, Output) then
    begin
      if Pos(DotNetName, Output) > 0 then
      begin
        Log('"' + DotNetName + '" found in output of "' + Command + '"');
        Result := True;
      end
        else
      begin
        Log('"' + DotNetName + '" not found in output of "' + Command + '"');
        Result := True;
      end;
    end
      else
    begin
      Log('Failed to read output of "' + Command + '"');
    end;
  end
    else
  begin
    Log('Failed to execute "' + Command + '"');
    Result := False;
  end;
  DeleteFile(FileName);
end;

function CheckIsDotNetDetected(): boolean;
begin
  result := DotNetInstalled('Microsoft.NETCore.App 5.0.');
end;