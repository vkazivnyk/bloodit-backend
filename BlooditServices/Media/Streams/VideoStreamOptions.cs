using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.Streams
{
    public class VideoStreamOptions : MediaStreamOptions
    {
        public int? ChunkDuration { get; init; }
        
        public string FFmpegPath { get; init; }

        public VideoStreamOptions(
            string fileName,
            string outputFileName = null,
            string outputDirectory = null,
            int? chunkDuration = 10,
            string ffMpegPath = @"FFmpegLib\bin\ffmpeg")
            : base(fileName, outputFileName, outputDirectory)
        {
            if (chunkDuration is <= 0)
            {
                throw new ArgumentException("The duration of a chunk should be at least 1s.", nameof(chunkDuration));
            }

            ChunkDuration = chunkDuration;
            FFmpegPath = ffMpegPath;
        }
    }
}
