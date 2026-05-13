Taskbar Groups – Unofficial Build (hummbugg)
Version: v1.1.0-unofficial

Overview
--------
Taskbar Groups lets you create custom groups of shortcuts and pin them to the Windows taskbar
for quick access.

This is an unofficial build maintained by hummbugg, based on the original project by tjackenpacken.

Original Project:
https://github.com/tjackenpacken/taskbar-groups

Maintained Fork (this build):
https://github.com/hummbugg/taskbar-groups


What’s New in This Version
-------------------------
- Fixed .ico image loading issues
- Fixed multiple-instance behavior (single instance enforced)
- Fixed New Group dialog (now modal; no hidden duplicates)
- Improved Release build stability (x64 fix)
- Added version check against GitHub
- Added “update available” link when a newer version exists
- Added “Original Author” attribution in UI
- Improved dialogs to remember last used folder:
  - Select Group Icon dialog
  - Create New Shortcut dialog
- Improved usability:
  - ESC closes dialog
  - “Exit” renamed to “Cancel”
- Locked window sizes to prevent layout issues


Installation
------------
1. Extract all files from the ZIP to a folder of your choice.
2. Run TaskbarGroups.exe

Runtime Requirement
-------------------
Taskbar Groups targets Microsoft .NET Framework 4.7.2.

Windows 11 normally already includes a newer compatible .NET Framework 4.x runtime, so no separate runtime installation should be needed.

If you are using an older or unsupported version of Windows and the app does not start, install the Microsoft .NET Framework 4.7.2 Runtime:

https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer


IMPORTANT – Windows Security Warning
-----------------------------------
If Windows blocks the app because it was downloaded from the internet:

OPTION 1 (Recommended):
1. Right-click the downloaded ZIP file
2. Click Properties
3. Check "Unblock"
4. Click Apply
5. Extract the ZIP
6. Run TaskbarGroups.exe

OPTION 2 (If already extracted):
Run PowerShell and execute:
If you accidently extract the zip file before unblocking the zip, you will have to delete the extracted folder, unblock the zip and extract the zip again.
Alternately if you are familiar with PowerShell you can run the command below to unblock the files, just change the path "C:\Path\To\TaskbarGroups" to match the folder you extracted TaskbarGroups into.

Get-ChildItem -Path "C:\Path\To\TaskbarGroups" -Recurse -File | Unblock-File

Then run TaskbarGroups.exe again.

Demo Video
-----------
A demonstration video for Taskbar Groups v1.1.0-unofficial is available on YouTube:
https://youtu.be/TzaTYnm7Ua8

Usage Tips
----------
- Create a new group using "Add Taskbar Group"
- Add shortcuts and choose an icon
- Pin the generated shortcut to your taskbar
- The app remembers the last folders used for selecting icons and shortcuts


Version Information
-------------------
- Current Version: version of the EXE you are running
- Latest Version: latest release available on GitHub

If a newer version is available, the Latest Version will appear as a clickable link.


Credits
-------
Original Author:
tjackenpacken
https://github.com/tjackenpacken/taskbar-groups

Maintained and enhanced by:
hummbugg
https://github.com/hummbugg/taskbar-groups


Disclaimer
----------
This is an unofficial build. It is not affiliated with or endorsed by the original author.

Use at your own risk.


Support / Issues
----------------
Please report issues or suggestions here:
https://github.com/hummbugg/taskbar-groups/issues

Developer Information
---------------------

Supported Operating Systems
---------------------------
Taskbar Groups v1.1.0-unofficial targets Microsoft .NET Framework 4.7.2.

Windows 11 already includes a newer compatible .NET Framework 4.x runtime,
so no additional runtime installation is normally required for end users.

The project has been tested primarily on:
- Windows 11
- Windows 10

Older unsupported versions of Windows may require manual installation of the
.NET Framework 4.7.2 runtime.

Supported Visual Studio Versions
--------------------------------
Because this project remains based on the classic .NET Framework WinForms
project system, it can still be opened and edited using multiple generations
of Microsoft Visual Studio, including:

- Visual Studio 2017
- Visual Studio 2019
- Visual Studio 2022
- Visual Studio 2026

This was intentionally preserved to maximize compatibility for developers
who wish to maintain, enhance, or fork the project without requiring
migration to newer SDK-style .NET project formats.

Project Dependencies
--------------------
The current release uses the following external libraries:

- ChinhDo.Transactions.FileManager.dll
- Microsoft.WindowsAPICodePack.dll
- Microsoft.WindowsAPICodePack.Shell.dll

These dependencies are included in the binary release ZIP.

Future releases may reduce or eliminate some external dependencies in favor
of native .NET implementations while preserving compatibility with classic
Visual Studio versions and Windows-native deployment.
