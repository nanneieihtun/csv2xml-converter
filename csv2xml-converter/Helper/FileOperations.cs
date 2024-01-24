using System;
using System.IO;
using System.Xml;

namespace csv2xml_converter.Helper
{
    public class FileOperations
    {
        public static XmlDocument LoadXML(string path)
        {
            XmlDocument xdoc = new XmlDocument();

            if (!File.Exists(path))
            {
                throw new System.ArgumentException(path);
            }
            try
            {
                xdoc.Load(path);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

            return xdoc;
        }

    }
}
