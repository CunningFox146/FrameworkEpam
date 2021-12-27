using System.IO;
using System.Linq;

namespace FrameworkEpam.Utils
{
    public static class FileUtil
    {
        public static string[] GetAllFilesInDirectory(string path) => Directory.GetFiles(path);
        public static string[] GetNewFiles(string[] oldFiles, string path)
        {
            var newFiles = GetAllFilesInDirectory(path);
            return newFiles.Except(oldFiles).ToArray();
        }
        public static void RemoveAllFilesInDirectory(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
