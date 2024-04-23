using System.Collections;

namespace FileRenameOrderly
{
    /// <summary>
    /// Sort By Creation Time
    /// </summary>
    /// <param name="sortWay">Sort Way</param>
    class CreationTimeSortBy(bool sortWay) : IComparer
    {
        int IComparer.Compare(object param1, object param2)
        {
            var x = param1 as FileInfo;
            var y = param2 as FileInfo;
            return sortWay ? x.CreationTime.CompareTo(y.CreationTime) : y.CreationTime.CompareTo(x.CreationTime);
        }
    }
}
