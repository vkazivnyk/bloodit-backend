﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.Streams
{
    public class AudioStreamOptions : MediaStreamOptions
    {
        public AudioStreamOptions(
            string fileName,
            string outputFileName = null,
            string outputDirectory = null)
        : base(fileName, outputFileName, outputDirectory) { }
    }
}
