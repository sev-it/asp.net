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
        // Описание свойств и их имен в сериализированном виде
        [DataMember(Name="name")]
        public string Name {get; set;}

        [DataMember(Name="extension")]
        public string Extension {get; set;}

        [DataMember(Name = "path")]
        public string PathToFile {get; set;}

        [DataMember(Name = "creation_time")]
        public string CreationTime { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "img")]
        public string Img { get; set; }

        // Создает упрощенную модель FileInfo. Массив объектов FileDto является частью FolderDto 
        // и служит для отображения информации о файлах в текущем каталоге (1-ый уровень вложенности).
        public static FileDto CreateFromFileInfo(FileInfo fileInfo)
        {
            var filesDto = new FileDto
            {
                Name = fileInfo.Name,
                Extension = fileInfo.Extension,
                PathToFile = fileInfo.DirectoryName + "\\" + fileInfo.Name,
                Size = System.Math.Round(fileInfo.Length * 0.001, 3),
                CreationTime = fileInfo.CreationTimeUtc.ToString(new CultureInfo("de-DE")),
                Img = @"img//file.png"
            };
            return filesDto;
        }
    }
}