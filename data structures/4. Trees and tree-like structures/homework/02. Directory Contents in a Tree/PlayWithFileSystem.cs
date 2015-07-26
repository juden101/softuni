namespace homework
{
    using System;
    using System.IO;

    public class PlayWithFileSystem
    {
        public static void Main()
        {
            // change this file path
            // nothe that is throws exception in C:\Windows because of unauthorized access
            Folder root = new Folder("...");

            Traverse(root);

            Console.WriteLine(root.Size);
        }
        
        private static void Traverse(Folder folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder.Name);

            DirectoryInfo[] currentFolders = directoryInfo.GetDirectories();
            FileInfo[] currentFiles = directoryInfo.GetFiles();

            foreach (DirectoryInfo currentFolder in currentFolders)
            {
                Folder newFolder = new Folder(currentFolder.FullName);
                
                folder.ChildFolders.Add(newFolder);
                Traverse(newFolder);
            }
            
            foreach (FileInfo currentFile in currentFiles)
            {
                File newFile = new File(currentFile.FullName, currentFile.Length);

                folder.Files.Add(newFile);
            }
        }
    }
}