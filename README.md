## 📢 New Version Released: [Info & Download](https://on.eslamx.com/2YcPKdt) 🔥
---
# Paste Into File

A Windows desktop application to paste clipboard contents (text and images) into files.

## Installation

### Installing via Chocolatey

You can use Chocolatey to install *Paste Into File*. If you don't have Chocolatey, you can install it from the [Chocolately Install page](https://chocolatey.org/install). With Chocolatey installed, execute the following command to install *Paste Into File*:

```powershell
choco install pasteintofile
``` 

### Download and Run

1. Make sure you have _.NET Framework 4.5+_ installed in your system. (_Included in Windows 10_)

2. Download the executable from [here](https://on.eslamx.com/2YcPKdt) and install it.

## Usage

1. Right click in the folder where you want to create the file and choose the *Paste Into File* entry from the context menu:

   ![Paste As File](PasteIntoFile/menu.png)
   <br/>

2. Choose the filename, extenstion and location, then press the *Save* button:<br/>
   ![Paste As File](PasteIntoFile/screenshot.png)

## Configuration

Run the following commands in a terminal (Command Prompt or PowerShell).

- To add the *Paste Into File* entry in the File Explorer context menu:

   ```powershell
   PasteIntoFile /reg
   ``` 

- To remove the *Paste Into File* entry from the File Explorer context menu:

   ```powershell
   PasteIntoFile /unreg
   ``` 

- To change the default filename format:

   ```powershell
   PasteIntoFile /filename yyyyMMdd_HHmmss
   ``` 
    
   For more information on the format specifiers, see [Custom date and time format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings).

