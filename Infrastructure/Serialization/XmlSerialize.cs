using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Serialization
{
    public class XmlSerializeCustom<T> where T : class
    {

        public string XmlSerialize(T entity)
        {


            XmlSerializer serialize = new XmlSerializer(typeof(T));
            StringWriter stringWriter = new StringWriter();
            TextWriter textWriter = stringWriter;
            serialize.Serialize(textWriter, entity);

            string serializeObject = textWriter.ToString();
            return serializeObject;
        }


        /// <summary>
        /// Xml Deserialize eder.
        /// </summary>
        /// <param name="xmlObject"></param>
        /// <returns></returns>
        public T XmlDeserialize(string xmlObject)
        {
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
            TextReader stringWriter = new StringReader(xmlObject);
            XmlReader writer = new XmlTextReader(stringWriter);
            T entity = Activator.CreateInstance<T>();
            if (xmlSerialize.CanDeserialize(writer))
            {
                entity = (T)xmlSerialize.Deserialize(writer);
            }
            return entity;
        }



    }
}