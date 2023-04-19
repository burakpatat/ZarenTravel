//Requires: TPDev.DatabaseFactory => https://github.com/oldfox94/TPDev.DatabaseFactory
 
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace TelTray.SharedLibrary.Xml
{
    public class XmlHelper
    {
        private string m_Path { get; set; }
        public XmlHelper(string xmlPath)
        {
            if (!Directory.Exists(xmlPath))
                Directory.CreateDirectory(xmlPath);

            m_Path = xmlPath;
        }

        public void Write<T>(T data, string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                TextWriter WriteFileStream = new StreamWriter(Path.Combine(m_Path, fileName));
                serializer.Serialize(WriteFileStream, data);

                // Cleanup
                WriteFileStream.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        public static string WriteToString<T>(T data)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
                settings.Indent = false;
                settings.OmitXmlDeclaration = false;

                using (StringWriter textWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, data);
                    }
                    return textWriter.ToString();
                }
            }
            catch (Exception ex)
            {
               
                return string.Empty;
            }
        }


        public T Read<T>(string fileName)
        {
            try
            {
                if (!File.Exists(Path.Combine(m_Path, fileName))) return default(T);
                var serializer = new XmlSerializer(typeof(T));

                TextReader ReadFileStream = new StreamReader(Path.Combine(m_Path, fileName));
                var result = serializer.Deserialize(ReadFileStream);

                ReadFileStream.Close();
                return (T)result;
            }
            catch (Exception ex)
            {
                
            }

            return default(T);
        }

        public static T ReadFromString<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return default(T);

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlReaderSettings settings = new XmlReaderSettings();
                // No settings need modifying here

                using (StringReader textReader = new StringReader(xml))
                {
                    using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                    {
                        return (T)serializer.Deserialize(xmlReader);
                    }
                }
            }
            catch (Exception ex)
            {
               
                return default(T);
            }
        }

        public static bool XslConverter(string xslFile, string xmlSourceFile, string resultFile)
        {
            if (!File.Exists(xslFile)) return false;
            if (!File.Exists(xmlSourceFile)) return false;

            try
            {
                var myXslTrans = new XslCompiledTransform();
                myXslTrans.Load(xslFile);
                myXslTrans.Transform(xmlSourceFile, resultFile);
            }
            catch (Exception ex)
            {
              
                return false;
            }
            return true;
        }
    }
}