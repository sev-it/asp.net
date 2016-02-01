using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FileBrowser.Api.Models
{
    [DataContract]
    public class FoldersDto
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "path")]
        public string PathToDirectory { get; set; }

        [DataMember(Name = "creation_time")]
        public string CreationTime { get; set; }
        
        [DataMember(Name = "directories")]
        public FoldersDto[] Directories { get; set; }

        [DataMember(Name = "files")]
        public FilesDto[] Files { get; set; }

        [DataMember(Name = "less_10")]
        public int lessTen { get; set; }

        [DataMember(Name = "10_50")]
        public int tenFivty { get; set; }

        [DataMember(Name = "over_100")]
        public int overHundred { get; set; }

        public static FoldersDto CreateFromDirectoryInfo(DirectoryInfo directoryInfo)
        {
            var folderDto = FoldersDto.CreateFolderMainInfo(directoryInfo);
            folderDto.Directories = FoldersDto.SubDirectories(directoryInfo.GetDirectories());
            folderDto.Files = FoldersDto.FileInfoToFilesDto(directoryInfo);
            int[] counters = FoldersDto.SizeCounter(directoryInfo);
            folderDto.lessTen = counters[0];
            folderDto.tenFivty = counters[1];
            folderDto.overHundred = counters[2];
        }

        public static FoldersDto CreateFolderMainInfo(DirectoryInfo directoryInfo)
        {
            var foldersDto = new FoldersDto()
            {
                Name = directoryInfo.Name,
                Path = directoryInfo.FullName,
                CreationTime = directoryInfo.CreationTimeUtc,
            };

            return foldersDto;
        }

        public static FoldersDto[] SubDirectoris(DirectoryInfo[] dirInfoCollection)
        {
            FoldersDto[] foldersCollection;
            foreach (var di in dirInfoCollection)
            {
                folderCollection.Add(FoldersDto.CreateFolderMainInfo(di));
            }

            return folderCollection;
        }

        public static FilesDto[] FileInfoToFilesDto(DirectoryInfo directoryInfo)
        {
            FilesDto[] filesCollection;
            foreach (var fi in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                filesCollection.Add(FilesDto.CreateFromFileInfo(fi));
            }

            return filesCollection;
        }

        public static int[] SizeCounter(DirectoryInfo directoryInfo)
        {
            int[] counters = new int[] {0, 0, 0};
            foreach (var fi in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                if ((fi.Length * 0.000001) <= 10)
                    counters[0] += 1;
                else if ((fi.Length * 0.000001) > 10 && (fi.Length * 0.000001) <= 50)
                    counters[1] += 1;
                else if ((fi.Length * 0.000001) >= 100)
                    counters[2] += 2;
            }

            return counters;
        }

    }
}