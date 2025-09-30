public class FileItem
{
    public string Name { get; set; } = "";
    public long Size { get; set; }
}

public class Folder
{
    public string Name { get; set; } = "";
    public List<FileItem> Files { get; set; } = new();
    public List<Folder> SubFolders { get; set; } = new();
}

public class FolderDto
{
    public string Name { get; set; } = "";
    public long Size { get; set; }   // total size including children
    public List<FolderDto> Children { get; set; } = new();
}

/*
Root(folder)
 ├─ FileA.txt(10 KB)
 ├─ FileB.txt(20 KB)
 ├─ Sub1(folder)
 │    ├─ FileC.txt(5 KB)
 │    └─ Sub1_1(folder)
 │         └─ FileD.txt(15 KB)
 └─ Sub2(folder)
      └─ FileE.txt(50 KB)
*/
class Program
{
    static void Main()
    {
        var root = new Folder
        {
            Name = "Root",
            Files =
            {
                new FileItem { Name = "FileA.txt", Size = 10 },
                new FileItem { Name = "FileB.txt", Size = 20 }
            },
            SubFolders =
            {
                new Folder
                {
                    Name = "Sub1",
                    Files = { new FileItem { Name = "FileC.txt", Size = 5 } },
                    SubFolders =
                    {
                        new Folder
                        {
                            Name = "Sub1_1",
                            Files = { new FileItem { Name = "FileD.txt", Size = 15 } }
                        }
                    }
                },
                new Folder
                {
                    Name = "Sub2",
                    Files = { new FileItem { Name = "FileE.txt", Size = 50 } }
                }
            }
        };

        var dto = BuildFolder(root);
        Print(dto, 0);
    }

    static FolderDto BuildFolder(Folder folder)
    {
        long size = 0;
        var children = new List<FolderDto>();

        // Add file sizes
        foreach (var file in folder.Files)
            size += file.Size;

        // Traverse subfolders
        foreach (var sub in folder.SubFolders)
        {
            var childDto = BuildFolder(sub);   // recursion
            size += childDto.Size;             // add child’s total size
            children.Add(childDto);
        }

        return new FolderDto
        {
            Name = folder.Name,
            Size = size,
            Children = children
        };
    }

    static void Print(FolderDto dto, int level)
    {
        Console.WriteLine(new string(' ', level * 2) + $"{dto.Name} ({dto.Size})");
        foreach (var child in dto.Children)
            Print(child, level + 1);
    }
}
