using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.Streams
{
    public interface IMediaStream
    {
        Stream Stream { get; }
        Task<string> UploadAsync();
    }
}
