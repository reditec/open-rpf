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

            using FileStream decompressedFileStream = System.IO.File.Create(expath);
            if (size == compressedSize)
            {
                originalFileStream.CopyTo(decompressedFileStream);
            }
            else
            {
                using DeflateStream decompressionStream = new DeflateStream(originalFileStream, CompressionMode.Decompress);
                decompressionStream.CopyTo(decompressedFileStream);
            }
        }

    }
}
