using System;
using System.Runtime.Serialization;
using System.Xml;

namespace FifthTask.Serialization
{
    public class ViewSerializer<T>
    {
        public Func<T, object> View { get; init; }

        public string Path { get; init; }

        public void Execute(T data)
        {
            var view = View.Invoke(data);
            var serializer = new DataContractSerializer(view.GetType());
            using var xmlWriter = XmlWriter.Create(Path, new XmlWriterSettings { Indent = true });
            serializer.WriteObject(xmlWriter, view);
        }
    }
}
