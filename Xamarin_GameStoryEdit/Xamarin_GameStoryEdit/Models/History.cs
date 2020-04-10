using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_GameStoryEdit.Models
{
    [Serializable]
    [DebuggerDisplay("Name={Name},OpenTime={OpenTime}")]
    public class History : ISerializable
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public string FileName => Name + Extension;
        public string FullName => Path + @"\" + Name + Extension;
        public DateTime OpenTime { get; set; }
        public DateTime SaveTime { get; set; }

        public History()
        {
        }

        protected History(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            Name = serializationInfo.GetString(nameof(Name));
            Path = serializationInfo.GetString(nameof(Path));
            Extension = serializationInfo.GetString(nameof(Extension));
            OpenTime = serializationInfo.GetDateTime(nameof(OpenTime));
            SaveTime = serializationInfo.GetDateTime(nameof(SaveTime));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(Path), Path);
            info.AddValue(nameof(Extension), Extension);
            ((ISerializable)OpenTime).GetObjectData(info, context);
            ((ISerializable)SaveTime).GetObjectData(info, context);
        }
    }
}
