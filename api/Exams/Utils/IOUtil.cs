using System.IO;
using System.Reflection;

namespace Exams.Utils
{
    public static class IOUtil
    {
        /// <summary>
        /// Pobiera ścieżkę do folderu bin aktualnie używanej dllki
        /// </summary>
        /// <returns>ścieżka do folderu bin aktualnie używanej dllki</returns>
        public static string GetCurrentAssemblyFolder()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", string.Empty));
        }
    }
}