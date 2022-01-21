using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlooditServices.Media.FFmpeg;

namespace BlooditServices.Media.Streams
{
    public class VideoStream : IMediaStream
    {
        public VideoStreamOptions Options { get; }

        public Stream Stream { get; }

        public VideoStream(Stream stream, VideoStreamOptions options)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<string> UploadAsync()
        {
            string fullOutputFileName = $@"{Options.OutputDirectory}\{Options.OutputFileName}";

            Directory.CreateDirectory(Options.OutputDirectory);

            await using (FileStream uploadingStream = new(fullOutputFileName, FileMode.OpenOrCreate))
            {
                await Stream.CopyToAsync(uploadingStream);

                await Stream.DisposeAsync();
            }

            if (Options.ChunkDuration is null)
            {
                return fullOutputFileName;
            }

            FFmpegEngineOptions options = new (
                fullOutputFileName, 
                Options.OutputDirectory,
                Options.FFmpegPath,
                true);

            FFmpegEngine engine = new (options);

            return await engine.SplitVideoAsync((int)Options.ChunkDuration);
        }
    }
}
