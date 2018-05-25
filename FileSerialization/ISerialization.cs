using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSerialization
{
    public interface ISerialization
    {
        void writeToStream(Stream stream, FileSender file);
        FileSender readStream(Stream stream);

    }
}
