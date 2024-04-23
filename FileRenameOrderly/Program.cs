// See https://aka.ms/new-console-template for more information
using FileRenameOrderly;

int j = 1;
bool ascending = true;
bool descending = false;

string path = @"\";
var TheFolder = new DirectoryInfo(path);
var Files = TheFolder.GetFiles();
Array.Sort(Files, new FileNameSortBy(ascending));
foreach (var item in Files)
{
    if (new[] { ".jpg", ".jpeg", ".png", ".tif" }.Contains(item.Extension))
    {
        string newName = j++.ToString() + item.Extension;
        string newPath = path + newName;

        Console.WriteLine(item.ToString() + "  Move to -->  " + newPath);
        item.MoveTo(newPath);
    }
    else
        Console.WriteLine(item.ToString() + " is out of order");
}