using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.Streams
{
    public class MediaStreamOptions : IMediaStreamOptions
    {
        public string FileName { get; init; }

        public string OutputFileName { get; init; }

        public string OutputDirectory { get; init; }

        public MediaStreamOptions(
            string fileName,
            string outputFileName = null,
            string outputDirectory = null)
        {
            string fileExtension = Path.GetExtension(fileName);

            outputFileName ??= Guid.NewGuid() + fileExtension;
            outputDirectory ??= ".";

            FileName = fileName;
            OutputFileName = Path.GetFileName(outputFileName);
            OutputDirectory = outputDirectory;
        }
    }
}
