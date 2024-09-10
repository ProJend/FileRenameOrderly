// See https://aka.ms/new-console-template for more information
using FileRenameOrderly;

int j = 1;
bool ascending = true;
bool descending = false;

string path = @"C:\";
string tempPath = path + @"\TEMP";

Directory.CreateDirectory(tempPath);
var TheFolder = new DirectoryInfo(path);
var Files = TheFolder.GetFiles();
Array.Sort(Files, new FileNameSortBy(ascending));
foreach (var item in Files)
{
    if (new[] { ".jpg", ".jpeg", ".png", ".tif" }.Contains(item.Extension))
    {
        string newName = j++.ToString() + item.Extension;
        string newPath = tempPath + @"\" + newName;
        Console.WriteLine(item.ToString() + "  Move to -->  " + newPath);
        item.MoveTo(newPath);
    }
    else
        Console.WriteLine(item.ToString() + " is out of order");
}

Console.WriteLine();
j = 1;

TheFolder = new DirectoryInfo(tempPath);
Files = TheFolder.GetFiles();
Array.Sort(Files, new FileNameSortBy(ascending));
foreach (var item in Files)
{
    string newName = j++.ToString() + item.Extension;
    string newPath = path + @"\" + newName;
    Console.WriteLine(newPath + "  <-- Move back  " + item.ToString());
    item.MoveTo(newPath);
}
Directory.Delete(tempPath, true);