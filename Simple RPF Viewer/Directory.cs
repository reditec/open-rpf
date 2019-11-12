using System;

namespace RPF
{
    class Directory : FileSystemEntry
    {
        private string _name;
        private int _firstoffset;
        private int _count;
        override public String Name { get => _name; set => _name = value; }
        public int FirstOffset { get => _firstoffset; set => _firstoffset = value; }
        public int Count { get => _count; set => _count = value; }

        public Directory(String name, int firstoffset, int count)
        {
            Name = name;
            FirstOffset = firstoffset;
            Count = count;

        }
    }
}
