using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileSerialization
{
    public class Serialization : ISerialization
    {
        private IFormatter formatter;


        public Serialization(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public Serialization()
        {
            this.formatter = new BinaryFormatter();
        }

        public FileSender readStream(Stream stream)
        {
            return (FileSender)formatter.Deserialize(stream);
        }

        public void writeToStream(Stream stream, FileSender file)
        {
            formatter.Serialize(stream, file);
        }
    }
}
