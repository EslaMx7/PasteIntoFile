using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasteAsFile
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args.Length>0)
			{
				try
				{
					if (string.Equals(args[0], "/reg", StringComparison.CurrentCultureIgnoreCase))
					{
						RegisterApp();
						return;
					}
					else if (string.Equals(args[0], "/unreg", StringComparison.CurrentCultureIgnoreCase))
					{
						UnRegisterApp();
						return;
					}
					else if (string.Equals(args[0], "/filename", StringComparison.CurrentCultureIgnoreCase) && args.Length > 1)
					{
						var key = OpenDirectoryKey().CreateSubKey("shell").CreateSubKey("Paste Into File");
						key = key.CreateSubKey("filename");
						key.SetValue("", args[1]);

						MessageBox.Show("Filename has been registered with your system", "Paste Into File", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else if (string.Equals(args[0], "/TextDefaultDir", StringComparison.CurrentCultureIgnoreCase) && args.Length > 1)
					{
						var key = OpenDirectoryKey().CreateSubKey("shell").CreateSubKey("Paste Into File");
						key = key.CreateSubKey("TextDefaultDir");
						key.SetValue("", args[1]);

						MessageBox.Show("TextDefaultDir has been registered with your system", "Paste Into File", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else if (string.Equals(args[0], "/ImageDefaultDir", StringComparison.CurrentCultureIgnoreCase) && args.Length > 1)
					{
						var key = OpenDirectoryKey().CreateSubKey("shell").CreateSubKey("Paste Into File");
						key = key.CreateSubKey("ImageDefaultDir");
						key.SetValue("", args[1]);

						MessageBox.Show("ImageDefaultDir has been registered with your system", "Paste Into File", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message + "\nPlease run the application as Administrator !", "Paste As File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				Application.Run(new frmMain(args[0]));
			}
			else
			{
				Application.Run(new frmMain());
			}
			
		}

		public static void UnRegisterApp()
		{
			var key = OpenDirectoryKey().OpenSubKey(@"Background\shell", true);
			key.DeleteSubKeyTree("Paste Into File");

			key = OpenDirectoryKey().OpenSubKey("shell", true);
			key.DeleteSubKeyTree("Paste Into File");

			MessageBox.Show("Application has been Unregistered from your system", "Paste Into File", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static void RegisterApp()
		{
			var key = OpenDirectoryKey().CreateSubKey(@"Background\shell").CreateSubKey("Paste Into File");
			key.SetValue("Icon", "\"" + Application.ExecutablePath + "\",0");
			key = key.CreateSubKey("command");
			key.SetValue("", "\"" + Application.ExecutablePath + "\" \"%V\"");

			key = OpenDirectoryKey().CreateSubKey("shell").CreateSubKey("Paste Into File");
			key.SetValue("Icon", "\"" + Application.ExecutablePath + "\",0");
			key = key.CreateSubKey("command");
			key.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");
			MessageBox.Show("Application has been registered with your system", "Paste Into File", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static void RestartApp()
		{
			ProcessStartInfo proc = new ProcessStartInfo();
			proc.UseShellExecute = true;
			proc.WorkingDirectory = Environment.CurrentDirectory;
			proc.FileName = Application.ExecutablePath;
			proc.Verb = "runas";

			try
			{
				Process.Start(proc);
			}
			catch
			{
				// The user refused the elevation.
				// Do nothing and return directly ...
				return;
			}
			Application.Exit();
		}

		static RegistryKey OpenDirectoryKey()
		{
			return Registry.CurrentUser.CreateSubKey(@"Software\Classes\Directory");
		}
	}
}
