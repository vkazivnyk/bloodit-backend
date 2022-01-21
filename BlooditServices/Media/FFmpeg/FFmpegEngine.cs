using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.FFmpeg
{
    public class FFmpegEngine
    {
        public FFmpegEngineOptions Options { get; }

        public FFmpegEngine(FFmpegEngineOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<string> SplitVideoAsync(int seconds)
        {
            string fileExtension = Path.GetExtension(Options.FilePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Options.FilePath);

            string outputChunksDirectory = $@"{Options.OutputDirectory}\{fileNameWithoutExtension}";

            Directory.CreateDirectory(outputChunksDirectory);

            string chunkPath = $@"{outputChunksDirectory}\{fileNameWithoutExtension}.%04d{fileExtension}";

            string ffmpegCommand = 
                $@"-i {Options.FilePath} -c copy -map 0 -segment_time 00:00:{seconds} -f segment -reset_timestamps 1 {chunkPath}";

            ProcessStartInfo info = new ()
            {
                FileName = Options.FFmpegPath,
                Arguments = ffmpegCommand
            };

            using Process mpegProcess = Process.Start(info) ?? throw new InvalidOperationException();

            mpegProcess.OutputDataReceived += (_, args) =>
            {
                Console.WriteLine(args.Data);
            };

            mpegProcess.ErrorDataReceived += (_, args) =>
            {
                Console.WriteLine(args.Data);
            };

            await mpegProcess.WaitForExitAsync();

            if (Options.DeleteProcessedFile)
            {
                File.Delete(Options.FilePath);
            }

            return outputChunksDirectory;
        }
    }
}
