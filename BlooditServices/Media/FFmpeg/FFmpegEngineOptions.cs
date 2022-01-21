using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlooditServices.Media.FFmpeg
{
    public class FFmpegEngineOptions
    {
        public string FilePath { get; init; }

        public string FFmpegPath { get; init; }

        public bool DeleteProcessedFile { get; init; }

        public string OutputDirectory { get; init; }

        public FFmpegEngineOptions(
            string filePath,
            string outputDirectory = ".",
            string ffmpegPath = @"FFmpegLib\bin\ffmpeg",
            bool deleteProcessedFile = false)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (outputDirectory is null)
            {
                throw new ArgumentNullException(nameof(outputDirectory));
            }

            if (ffmpegPath is null)
            {
                throw new ArgumentNullException(nameof(outputDirectory));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file {filePath} was not found.", filePath);
            }

            if (!Regex.IsMatch(Path.GetFileName(ffmpegPath), @"ffmpeg(\.exe)?$"))
            {
                throw new ArgumentException($"The file {ffmpegPath} was not a valid ffmpeg file.", nameof(ffmpegPath));
            }

            OutputDirectory = Path.GetFullPath(outputDirectory);
            FilePath = Path.GetFullPath(filePath);
            FFmpegPath = Path.GetFullPath(ffmpegPath);
            DeleteProcessedFile = deleteProcessedFile;
        }
    }
}
