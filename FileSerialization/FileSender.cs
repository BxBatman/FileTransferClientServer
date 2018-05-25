using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSerialization
{
    [Serializable]
    public class FileSender
    {
        private String name;
        private byte[] serializedFile;


        public FileSender(string name,byte[] file)
        {
            this.name = name;
            this.serializedFile = file;
        }

        public string Name { get => name; set => name = value; }
        public byte[] SerializedFile { get => serializedFile; set => serializedFile = value; }

    }
}
