﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.Streams
{
    public class ImageStream : IMediaStream
    {
        public Stream Stream { get; }

        public ImageStreamOptions Options { get; }

        public ImageStream(Stream stream, ImageStreamOptions options)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<string> UploadAsync()
        {
            string fullOutputFileName = $@"{Options.OutputDirectory}\{Options.OutputFileName}";

            Directory.CreateDirectory(Options.OutputDirectory);

            await using FileStream uploadingStream = new(fullOutputFileName, FileMode.OpenOrCreate);

            await Stream.CopyToAsync(uploadingStream);

            await Stream.DisposeAsync();

            return fullOutputFileName;
        }
    }
}