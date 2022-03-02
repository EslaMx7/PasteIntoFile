## 📢 New Version Released: [Info & Download](https://github.com/David-Maisonave/PasteIntoFile/releases/latest) 🔥
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

2. Download the executable from [here](https://github.com/David-Maisonave/PasteIntoFile/releases/latest) and install it.

## Usage

1. Right click in the folder where you want to create the file and choose the **Paste Into File** entry from the context menu:

   ![Paste As File](PasteIntoFile/menu.png)
   <br/>

2. Choose the filename, extenstion and location, then press the *Save* button:<br/>
   ![Paste As File](PasteIntoFile/screenshot.png)

### Combination Key Usage
* To create a file automatically (without a windows prompt), hold **CTRL** key while choosing **[Paste Into File]** in the context menu.
* To create the file in a default sub folder under the current directory, hold **SHIFT** key while choosing **[Paste Into File]** in the context menu.
* Holding both keys (**CTRL+SHIFT**) while choosing **[Paste Into File]** will create the text file automatically in the default sub folder associated with the file type.
  * The default sub folder for a text file is Text, and the default folder for an image file is Image.
  * The default sub folders can be changed using command line options. See Configuration section for details.

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

- To change the default **filename** format:

   ```powershell
   PasteIntoFile /filename yyyyMMdd_HHmmss
   ``` 
    

- To change the default **Text** Sub Folder:

   ```powershell
   PasteIntoFile /TextSubDir MyDefaultTextFolder
   ``` 
    

- To change the default **Image** Sub Folder:

   ```powershell
   PasteIntoFile /ImageSubDir MyImgDir
   ``` 
    
   For more information on the format specifiers, see [Custom date and time format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings).

