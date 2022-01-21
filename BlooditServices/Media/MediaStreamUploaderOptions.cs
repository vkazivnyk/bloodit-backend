using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlooditServices.Media
{
    public record MediaStreamUploaderOptions(
        string FileName,
        string OutputFileName = null,
        string OutputDirectory = null);
}
