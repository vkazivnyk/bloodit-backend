using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media.Streams
{
    public interface IMediaStreamOptions
    {
        string FileName { get; init; }

        string OutputFileName { get; init; }

        string OutputDirectory { get; init; }
    }
}
