namespace homework
{
    using System;
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public long? Size
        {
            get
            {
                long? size = 0;

                foreach (Folder folder in this.ChildFolders)
                {
                    size += folder.Size;
                }

                foreach (File file in this.Files)
                {
                    size += file.Size;
                }

                return size;
            }
        }
    }
}
