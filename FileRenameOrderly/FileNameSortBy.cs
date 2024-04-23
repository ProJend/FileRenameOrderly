using System.Collections;
using System.Runtime.InteropServices;

namespace FileRenameOrderly
{
    /// <summary>
    /// Sort By Counting Number
    /// </summary>
    /// <param name="sortWay">Sort Way</param>
    partial class FileNameSortBy(bool sortWay) : IComparer
    {
        //调用 Windos 的 DLL
        [LibraryImport("Shlwapi.dll", StringMarshalling = StringMarshalling.Utf16)]
        private static partial int StrCmpLogicalW(string param1, string param2);

        //前后文件名进行比较。
        public int Compare(object x, object y)
        {
            if (null == x && null == y)
            {
                return 0;
            }
            if (null == x)
            {
                return -1;
            }
            if (null == y)
            {
                return 1;
            }
            return sortWay ? StrCmpLogicalW(x.ToString(), y.ToString()) : StrCmpLogicalW(y.ToString(), x.ToString());
        }
    }
}
