using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using RPG;
using Microsoft.Xna.Framework;

namespace MapBuilder
{
    public class XmlParser
    {
        XmlDocument mMapDoc;
 
        public XmlParser()
        {
            writeObjectToXML();
            readObjectFromXML();
        }

        void writeObjectToXML()
        {
            using (XmlWriter mWriter = XmlWriter.Create("map.xml"))
            {
                mWriter.WriteStartDocument();
                mWriter.WriteStartElement("Player");
                mWriter.WriteStartElement("position");

                mWriter.WriteStartElement("x", "250.0");
                mWriter.WriteEndElement();
                mWriter.WriteStartElement("y", "300.0");
                mWriter.WriteEndElement();

                mWriter.WriteEndElement();
                mWriter.WriteEndElement();

                mWriter.WriteEndDocument();
            }
        }

        void createPlayer(XmlReader reader)
        {
            Vector2 pos = Vector2.Zero;
            TextureMap t = new TextureMap();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "position":
                            {
                                reader.ReadToDescendant("x");
                                float x = (float)float.Parse((reader.GetAttribute(0)));
                                reader.ReadToNextSibling("y");
                                float y = (float)float.Parse((reader.GetAttribute(0)));
                                pos = new Vector2(x, y);
                            }
                            break;
                        default:
                            int o = 0;//fer teh deboog
                            break;
                    }
                }
            }
            Player p = new Player(pos, t);
        }

        void readObjectFromXML()
        {
            using (XmlTextReader reader = new XmlTextReader("map.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "Player":
                                {
                                    createPlayer(reader.ReadSubtree());
                                } 
                                break;
                        }
                    }
                }
            }
        }
    }
}
