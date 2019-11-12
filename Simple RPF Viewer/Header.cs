using System;
using System.IO;
using System.Text;

namespace Simple_RPF_Viewer
{
    class Header
    {
        string version;
        int tocSize;
        int count;
        int unknown;
        bool isEncrypted;


        public Header(Stream header)
        {
            SetVersion(ReadByte(header, 0, 4));
            SetTocSize(ReadByte(header, 0, 4));
            SetCount(ReadByte(header, 0, 4));
            SetUnknown(ReadByte(header, 0, 4));
            SetEncryptionState(ReadByte(header, 0, 4));
            header.Dispose();
        }

        public void SetVersion(byte[] buffer)
        {
            version = Encoding.UTF8.GetString(buffer);
        }
        public string GetVersion()
        {
            return version;
        }
        public void SetTocSize(byte[] buffer)
        {
            tocSize = BitConverter.ToInt32(buffer);
        }
        public int GetTocSize()
        {
            return tocSize;
        }
        public void SetCount(byte[] buffer)
        {
            count = BitConverter.ToInt32(buffer);
        }
        public int GetCount()
        {
            return count;
        }
        public void SetUnknown(byte[] buffer)
        {
            unknown = BitConverter.ToInt32(buffer);
        }
        public int GetUnknown()
        {
            return unknown;
        }
        public void SetEncryptionState(byte[] buffer)
        {
            isEncrypted = BitConverter.ToBoolean(buffer);
        }
        public bool GetEncryptionState()
        {
            return isEncrypted;
        }

        private byte[] ReadByte(Stream stream, int offset, int length)
        {
            byte[] result = new byte[length];
            stream.Read(result, offset, length);
            return result;
        }


    }
}
