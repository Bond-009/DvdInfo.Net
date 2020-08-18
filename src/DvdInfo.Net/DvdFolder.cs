using System;
using System.IO;

namespace DvdInfo
{
    public static class DvdFolder
    {
        public static VmgInfo GetVmgInfo(string rootDir)
        {
            var videoTsDir = rootDir;
            foreach (var dir in Directory.EnumerateDirectories(rootDir))
            {
                if (dir.Equals("VIDEO_TS", StringComparison.OrdinalIgnoreCase))
                {
                    videoTsDir = dir;
                }
            }

            var files = Directory.GetFiles(videoTsDir);
            var vmgFile = Array.Find(files, x => x.Equals("VIDEO_TS.IFO", StringComparison.OrdinalIgnoreCase))
                ?? Array.Find(files, x => x.Equals("VIDEO_TS.BUP", StringComparison.OrdinalIgnoreCase));

            if (vmgFile == null)
            {
                ThrowHelper.ThrowFileNotFoundException("Couldn't find a 'VIDEO_TS.IFO' or 'VIDEO_TS.BUP' file.");
            }

            return VmgInfo.Create(vmgFile);
        }
    }
}
