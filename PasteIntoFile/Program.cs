using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasteIntoFile.Properties;

namespace PasteAsFile
{
	static class Program
	{
		public static readonly string RegistrySubKey = "Paste Into File";

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
				if (args[0] == "/reg")
				{
					RegisterApp();
					return;
				}
				else if (args[0] == "/unreg")
				{
					UnRegisterApp();
					return;
				}
                else if (args[0] == "/filename")
                {
                    if (args.Length > 1) {
                        RegisterFilename(args[1]);
                    }
                    return;
                }
				Application.Run(new frmMain(args[0]));
			}
			else
			{
				Application.Run(new frmMain());
			}
			
		}

		public static void RegisterFilename(string filename)
		{
			try
			{
                var key = OpenDirectoryKey().CreateSubKey("shell").CreateSubKey(RegistrySubKey);
                key = key.CreateSubKey("filename");
                key.SetValue("", filename);

                MessageBox.Show(Resources.str_message_register_filename_success, Resources.window_title, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				//throw;
				MessageBox.Show(ex.Message + "\n" + Resources.str_message_run_as_admin, Resources.window_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static void UnRegisterApp()
		{
			try
			{
				var key = OpenDirectoryKey().OpenSubKey(@"Background\shell", true);
				key.DeleteSubKeyTree(RegistrySubKey);

				key = OpenDirectoryKey().OpenSubKey("shell", true);
				key.DeleteSubKeyTree(RegistrySubKey);

				MessageBox.Show(Resources.str_message_unregister_context_menu_success, Resources.window_title, MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + Resources.str_message_run_as_admin, Resources.window_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
				
			}
		}

		public static void RegisterApp()
		{
			try
			{
				var key = OpenDirectoryKey().CreateSubKey(@"Background\shell").CreateSubKey(RegistrySubKey);
				key.SetValue("", Resources.explorer_context_entry);
				key.SetValue("Icon", "\"" + Application.ExecutablePath + "\",0");
				key = key.CreateSubKey("command");
				key.SetValue("" , "\"" + Application.ExecutablePath + "\" \"%V\"");

				key = OpenDirectoryKey().CreateSubKey("shell").CreateSubKey(RegistrySubKey);
				key.SetValue("", Resources.explorer_context_entry);
				key.SetValue("Icon", "\"" + Application.ExecutablePath + "\",0");
				key = key.CreateSubKey("command");
				key.SetValue("" , "\"" + Application.ExecutablePath + "\" \"%1\"");
				MessageBox.Show(Resources.str_message_register_context_menu_success, Resources.window_title, MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				//throw;
				MessageBox.Show(ex.Message + "\n" + Resources.str_message_run_as_admin, Resources.window_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
