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
    public class SubFolderDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "path")]
        public string PathToDirectory { get; set; }

        [DataMember(Name = "creation_time")]
        public string CreationTime { get; set; }
        
        [DataMember(Name = "img")]
        public string Img { get; set; }

        public static SubFolderDto CreateSubFolderMainInfo(DirectoryInfo directoryInfo)
        {
            var subFolderDto = new SubFolderDto()
            {
                Name = directoryInfo.Name,
                PathToDirectory = directoryInfo.FullName,
                CreationTime = directoryInfo.CreationTimeUtc.ToString(new CultureInfo("de-DE")),
                Img = @"img//folder.png",
            };

            return subFolderDto;
        }
    }
}