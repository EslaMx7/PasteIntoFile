using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasteAsFile
{
    public partial class frmMain : Form
    {
		public const string DEFAULT_FILENAME_FORMAT = "yyyy-MM-dd HH.mm.ss";
		public string CurrentLocation { get; set; }
		public bool IsText { get; set; }
		public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string location)
        {
            InitializeComponent();
            this.CurrentLocation = location;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
			string filename = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\Directory\shell\Paste Into File\filename", "", null) ?? DEFAULT_FILENAME_FORMAT;
			txtFilename.Text = DateTime.Now.ToString(filename);
			txtCurrentLocation.Text = CurrentLocation ?? @"C:\";
			const string DEFAULT_TEXT_SUBFOLDER = "Text";
			const string DEFAULT_IMAGE_SUBFOLDER = "Image";
			string TextSubDir = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\Directory\shell\Paste Into File\TextSubDir", "", null) ?? DEFAULT_TEXT_SUBFOLDER;
			string ImageSubDir = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\Directory\shell\Paste Into File\ImageSubDir", "", null) ?? DEFAULT_IMAGE_SUBFOLDER;
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
			{
				string SubDir = (Clipboard.ContainsText()) ? TextSubDir : ImageSubDir;
				txtCurrentLocation.Text = (SubDir.IndexOf(":") > 0) ? SubDir : txtCurrentLocation.Text + @"\" + SubDir;
			}

			if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\Directory\Background\shell\Paste Into File\command", "", null) == null)
            {
                if (MessageBox.Show("Seems that you are running this application for the first time,\nDo you want to Register it with your system Context Menu ?", "Paste Into File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.RegisterApp();
                }
            }

            if (Clipboard.ContainsText())
            {
                lblType.Text = "Text File";
				comExt.Items.AddRange(new object[] {
					"ahk",   // - AutoHotkey
					"au3",   // - AutoIt
					"bat",   // - DOS Batch
					"cmd",   // - DOS Batch (modern)
					"cpp",   // - C++ Language
					"cs",    // - C-Sharp Langauge
					"css",   // - Cascading Style Sheets - use to style an HTML document
					"csv",   // - Comma-Separated Value
					"htm",   // - Hypertext Markup Language
					"html",  // - Hypertext Markup Language
					"ini",   // - INI - Windows Configuration File
					"java",  // - Java Language
					"js",    // - JavaScript Language
					"json",  // - JavaScript Object Notation
					"php",   // - PHP Language
					"pl",    // - Perl Language
					"ps1",   // - PowerShell
					"py",    // - Python Language
					"reg",   // - Registry File
					"swift", // - Switft  Language
					"txt",   // - Text Files
					"vb",    // - Visual Basic Language
					"vbs",   // - Visual Basic Script Language
					"xml"    // - Extensible Markup Language
				});
                comExt.SelectedItem = "txt";
                IsText = true;
				txtContent.Text = Clipboard.GetText();
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
					Save_Action(0);
				return;
            }

            if (Clipboard.ContainsImage())
            {
                lblType.Text = "Image";
				comExt.Items.AddRange(new object[] {
					"png",
					"jpg",
					"bmp",
					"gif",
					"ico"
				});
                comExt.SelectedItem = "png";
				imgContent.Image = Clipboard.GetImage();
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
					Save_Action(0);
                return;
            }

            lblType.Text = "Unknown File";
            btnSave.Enabled = false;

		}

		public void Save_Action(int millisecondsTimeout)
        {
            string location = txtCurrentLocation.Text;
			if (!Directory.Exists(location))
				Directory.CreateDirectory(location);
			location = location.EndsWith("\\") ? location : location + "\\";
            string filename = txtFilename.Text + "." + comExt.SelectedItem.ToString();
            if (IsText)
            {

                File.WriteAllText(location + filename, txtContent.Text, Encoding.UTF8);
                this.Text += " : File Saved :)";
            }
            else
            {
                switch (comExt.SelectedItem.ToString())
                {
                    case "png":
                        imgContent.Image.Save(location + filename, ImageFormat.Png);
                        break;
                    case "ico":
                        imgContent.Image.Save(location + filename, ImageFormat.Icon);
                        break;
                    case "jpg":
                        imgContent.Image.Save(location + filename, ImageFormat.Jpeg);
                        break;
                    case "bmp":
                        imgContent.Image.Save(location + filename, ImageFormat.Bmp);
                        break;
                    case "gif":
                        imgContent.Image.Save(location + filename, ImageFormat.Gif);
                        break;
                    default:
                        imgContent.Image.Save(location + filename, ImageFormat.Png);
                        break;
                }

                this.Text += " : Image Saved :)";
            }

            Task.Factory.StartNew(() =>
            {
				if (millisecondsTimeout > 0)
					Thread.Sleep(millisecondsTimeout);
                Environment.Exit(0);
            });
        }
		private void btnSave_Click(object sender, EventArgs e)
		{
			Save_Action(1000);
		}

        private void btnBrowseForFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a folder for saving this file ";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtCurrentLocation.Text = fbd.SelectedPath;
            }
        }

        private void lblWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("http://eslamx.com");
        }

        private void lblMe_Click(object sender, EventArgs e)
        {
            Process.Start("http://twitter.com/EslaMx7");
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            string msg = "Paste Into File helps you paste any text or images in your system clipboard into a file directly instead of creating new file yourself\n";
			msg += "-----------------------------------------------------------------\n";
            msg += "To Register the application to your system Context Menu run the program as Administrator with argument: /reg\n";
            msg += "To Unregister the application use argument: /unreg\n";
			msg += "To change the format of the default filename, use argument:\n/filename yyyy-MM-dd_HHmm\n";
			msg += "-----------------------------------------------------------------\n";

			msg += "To create a file automatically without a window prompt, hold shift key while selecting 'Paste Into File'\n";
			msg += "To add a default sub folder to 'Current Location', hold ctrl key while selecting 'Paste Into File'.   ";
			msg += "The default sub folder for a text file is Text, and the default sub folder for an image file is Image.\n\n";
			msg += "To change the default Text Sub Folder, use argument:\n/TextSubDir MyDefaultTextFolder\n";
			msg += "To change the default Image Sub Folder, use argument:\n/ImageSubDir MyImgDir\n";
			msg += "\n--------------------\nSend Feedback to : eslamx7@gmail.com\n\nThanks :)";
            MessageBox.Show(msg, "Paste As File Help", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void txtFilename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave_Click(sender, null);
            }
        }
    }
}
