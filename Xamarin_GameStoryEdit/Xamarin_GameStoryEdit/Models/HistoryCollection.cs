﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Xamarin_GameStoryEdit.Models
{
    public class HistoryCollection : List<History>
    {
        private HistoryCollection() : base() { }
        public History this[string Name]
        {
            get => base[FindIndex(match => match.Name == Name)];
            set => base[FindIndex(match => match.Name == Name)] = value;
        }
        public void Remove(string Name) => RemoveAt(FindIndex(match => match.Name == Name));
        public bool Contains(string Name) => FindIndex(match => match.Name == Name) < 0 ? false : true;

        public void Serialize()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Histories";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            XmlSerializer serializer = new XmlSerializer(typeof(HistoryCollection));
            using (XmlWriter xmlWriter = XmlWriter.Create(path + @"\OpenTime.xml"))
            {
                serializer.Serialize(xmlWriter, this);
            }
        }
        public static HistoryCollection Deserialize()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Histories\OpenTime.xml";
            if (!File.Exists(path))
            {
                HistoryCollection histories = new HistoryCollection();
                histories.Serialize();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(HistoryCollection));
            using (XmlReader Reader = XmlReader.Create(path))
            {
                return (HistoryCollection)serializer.Deserialize(Reader);
            }
        }
    }
}
