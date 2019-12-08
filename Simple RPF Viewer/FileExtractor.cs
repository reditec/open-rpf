using System;
using System.IO;
using System.IO.Compression;

namespace RPF
{
    abstract class FileExtractor
    {

        public static void ExtractFile(String rpfpath, String expath, int offset, int size, int compressedSize)
        {
            FileInfo fileInfo = new FileInfo(rpfpath);

            using FileStream originalFileStream = fileInfo.OpenRead();
            originalFileStream.Seek(offset, SeekOrigin.Begin);
            byte[] compressedFile = new byte[compressedSize];
            originalFileStream.Read(compressedFile, 0, compressedSize);
            MemoryStream ms = new MemoryStream(compressedFile);

            using FileStream decompressedFileStream = System.IO.File.Create(expath);
            if (size == compressedSize)
            {
                ms.CopyTo(decompressedFileStream);
            }
            else
            {
                using DeflateStream decompressionStream = new DeflateStream(ms, CompressionMode.Decompress);
                decompressionStream.CopyTo(decompressedFileStream);
            }
        }

    }
}
