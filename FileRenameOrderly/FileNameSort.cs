using System.Collections;
using System.Runtime.InteropServices;

namespace FileRenameOrderly
{
    /// <summary>
    /// Sort by counting number
    /// </summary>
    public partial class FileNameSort : IComparer
    {
        //调用 Windos 的 DLL
        [LibraryImport("Shlwapi.dll", StringMarshalling = StringMarshalling.Utf16)]
        private static partial int StrCmpLogicalW(string param1, string param2);

        //前后文件名进行比较。
        public int Compare(object name1, object name2)
        {
            if (null == name1 && null == name2)
            {
                return 0;
            }
            if (null == name1)
            {
                return -1;
            }
            if (null == name2)
            {
                return 1;
            }
            return StrCmpLogicalW(name1.ToString(), name2.ToString());
        }
    }
}
