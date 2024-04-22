// See https://aka.ms/new-console-template for more information
using FileRenameOrderly;

Console.WriteLine("Hello, World!");
int j = 1;

string path = @"D:\Users\Admin\Desktop\胶液\毒液甘雨\";
var TheFolder = new DirectoryInfo(path);
var Files = TheFolder.GetFiles();
Array.Sort(Files, new FileNameSort());
foreach (var item in Files)
{
    if (new[] { ".jpg", ".jpeg", ".png", ".tif" }.Contains(item.Extension))
    {
        string newName = j++.ToString() + item.Extension;
        string newPath = path + newName;

        item.MoveTo(newPath);
        Console.WriteLine(item.ToString() + "  Move to -->  " + newPath);
    }
    else
        Console.WriteLine(item.ToString() + " is out of order");
}