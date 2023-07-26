using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace CS2010.ArcSys.Win
{
	public static class ClsOpenEDIFile
	{
		public static void OpenFile(string sFile, string sPartner, string sType)
		{
			// This will open an EDI file given a file name
			// and the type of file.  Requires app.config settings
			// for each filetype in order to find the path to the files
			try
			{
				string sPath = GetFilePath(sPartner, sType);
				sFile = sPath + sFile;
				if (string.IsNullOrEmpty(sPath))
				{
					Program.Show("Cannot open this kind of file");
					return;
				}
				System.Diagnostics.Process.Start("notepad.exe", sFile);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public static string GetFilePath(string sPartner, string sType)
		{
			// Find the Path to any specific EDI File type
			sType = sPartner + sType + "Path";
			string sPath = ConfigurationManager.AppSettings[sType];
			return sPath;
		}

		public static void OpenFileWithFullName(string sPath)
		{
			// For when we know the full path
			try
			{
				if (string.IsNullOrEmpty(sPath))
				{
					Program.Show("Cannot open this kind of file");
					return;
				}
				System.Diagnostics.Process.Start("notepad.exe", sPath);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}

		}

        public static bool OpenFileFromRootFolder(string sFolder, string sFile)
        {
            // Make sure the folder ends with backslashes; otherwise the "Parent.Fullname" attribute will go up one
            // two many levels.
            if (!sFolder.EndsWith("\\"))
            {
                sFolder = sFolder + "\\";
            }
            string Folder = Path.GetDirectoryName(sFolder);
            DirectoryInfo di = new DirectoryInfo(Folder);
            string FolderA = di.Parent.FullName;
            string File = Path.GetFileName(sFile);

            Program.Show("This may take a few seconds to find the file in our Archives");
            int iCount = 0;
            foreach (string file in Directory.EnumerateFiles(FolderA, File, SearchOption.AllDirectories))
            {
                iCount++;
                System.Diagnostics.Process.Start("notepad.exe", file);
                break;
            }
            if (iCount < 1)
            {
                return false;
            }
            return true;
        }

        public static int GetFileCount(string path, string searchPattern, SearchOption searchOption)
        {
            var fileCount = 0;
            var fileIter = Directory.EnumerateFiles(path, searchPattern, searchOption);
            foreach (var file in fileIter)
                fileCount++;
            return fileCount;
        }
	}
}
