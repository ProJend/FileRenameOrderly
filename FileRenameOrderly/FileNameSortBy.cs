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
        private static partial int StrCmpLogicalW(string? param1, string? param2);

        //前后文件名进行比较。
        public int Compare(object? x, object? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            string? strX = x.ToString();
            string? strY = y.ToString();

            return sortWay
                ? StrCmpLogicalW(strX, strY)
                : StrCmpLogicalW(strY, strX);
        }
    }
}