using System;

namespace RPF
{
    class File : FileSystemEntry
    {
        private string _name;
        private int _offset;
        private int _csize;
        private int _size;

        override public String Name { get => _name; set => _name = value; }
        public int Offset { get => _offset; set => _offset = value; }
        public int CompressedSize { get => _csize; set => _csize = value; }
        public int Size { get => _size; set => _size = value; }

        public File(String name, int offset, int csize, int size)
        {
            Name = name;
            Offset = offset;
            CompressedSize = csize;
            Size = size;
        }


    }
}
