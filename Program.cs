using System.IO.Compression;

namespace Football_Forever_3_Decompressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                BinaryReader br = new(File.OpenRead(args[i]));

                br.BaseStream.Position = 8;
                int size = br.ReadInt32();
                br.BaseStream.Position = 50;

                using (var ds = new DeflateStream(new MemoryStream(br.ReadBytes(size)), CompressionMode.Decompress))
                    ds.CopyTo(File.Create(Path.GetDirectoryName(args[i]) + "//" + Path.GetFileNameWithoutExtension(args[i])));
            }
        }
    }
}
