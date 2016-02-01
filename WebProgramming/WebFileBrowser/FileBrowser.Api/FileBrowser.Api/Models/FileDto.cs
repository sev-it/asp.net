using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace FileBrowser.Api.Models
{
    [DataContract]
    public class FileDto
    {
        [DataMember(Name="name")]
        public string Name {get; set;}

        [DataMember(Name="extension")]
        public string Extension {get; set;}

        [DataMember(Name = "path")]
        public string PathToDirectory {get; set;}

        [DataMember(Name = "creation_time")]
        public string CreationTime { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }
       
        public static FileDto CreateFromFileInfo(FileInfo fileInfo)
        {
            var filesDto = new FileDto
            {
                Name = fileInfo.Name,
                Extension = fileInfo.Extension,
                PathToDirectory = fileInfo.DirectoryName,
                Size = fileInfo.Length * 0.000001,
                CreationTime = fileInfo.CreationTimeUtc.ToString(new CultureInfo("de-DE"))
            };
            return filesDto;
        }
    }
}