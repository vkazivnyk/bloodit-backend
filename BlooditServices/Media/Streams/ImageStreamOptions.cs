using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.Streams
{
    public class ImageStreamOptions : MediaStreamOptions
    {
        public ImageStreamOptions(
            string fileName,
            string outputFileName = null,
            string outputDirectory = null)
        : base(fileName, outputFileName, outputDirectory) { }
    }
}
