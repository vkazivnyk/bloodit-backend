using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlooditServices.Media.Streams;

namespace BlooditServices.Media
{
    public class MediaStreamUploader
    {
        public Stream Stream { get; }
        
        public MediaStreamUploaderOptions Options { get; }

        private readonly List<string> _videoExtensions = new()
        {
            ".mp4"
        };

        private readonly List<string> _audioExtensions = new()
        {
            ".mp3", ".wav"
        };

        public MediaStreamUploader(Stream stream, MediaStreamUploaderOptions options)
        {
            Stream = stream;
            Options = options;
        }

        public async Task<string> UploadAsync()
        {
            string fileExtension = Path.GetExtension(Options.FileName);

            if (_videoExtensions.Contains(fileExtension))
            {
                VideoStreamOptions options = new(
                    Options.FileName,
                    Options.OutputFileName,
                    Options.OutputDirectory,
                    10,
                    @"D:\FFmpegLib\bin\ffmpeg");

                VideoStream stream = new(Stream, options);

                return await stream.UploadAsync();
            }

            if (_audioExtensions.Contains(fileExtension))
            {
                AudioStreamOptions options = new(
                    Options.FileName,
                    Options.OutputFileName,
                    Options.OutputDirectory);

                AudioStream stream = new(Stream, options);

                return await stream.UploadAsync();
            }

            return null;
        }
    }
}
