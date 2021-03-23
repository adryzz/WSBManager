using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace WSBManager.WSB
{
    public class Sandbox
    {
        /// <summary>
        /// The wsb file
        /// </summary>
        public string WSBFile = "";

        /// <summary>
        /// The sandbox configuration
        /// </summary>
        public Configuration WSBConfig;

        public Process SandboxProcess;

        public void Run()
        {
            SandboxProcess = Process.Start(WSBFile);
        }
        /// <summary>
        /// Saves the wsb file
        /// </summary>
        public void Save()
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(WSBConfig.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            XmlSerializer xml_serializer = new XmlSerializer(typeof(Configuration));

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, WSBConfig, emptyNamespaces);

                File.WriteAllText(WSBFile, stream.ToString());
            }
        }

        /// <summary>
        /// Opens a wsb file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Configuration FromFile(string fileName)
        {
            string serialized = File.ReadAllText(fileName);
            XmlSerializer xml_serializer = new XmlSerializer(typeof(Configuration));
            using (StringReader string_reader = new StringReader(serialized))
            {
                Configuration sb = (Configuration)(xml_serializer.Deserialize(string_reader));
                return sb;
            }
        }
    }
}
