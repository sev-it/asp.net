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
    public class FolderDto
    {
        // Описание свойств и их имен в сериализированном виде
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "path")]
        public string PathToDirectory { get; set; }

        [DataMember(Name = "creation_time")]
        public string CreationTime { get; set; }
        
        [DataMember(Name = "directories")]
        public SubFolderDto[] Directories { get; set; }

        [DataMember(Name = "files")]
        public FileDto[] Files { get; set; }

        // Метод полной сборки объекта FolderDto:
        // - получение массива объектов SubFolderDto (списка подкаталогов текущего каталога)
        // - получение массива объектов FileDto (списка файлов текущего каталога)
        public static FolderDto CreateFromDirectoryInfo(DirectoryInfo directoryInfo)
        {
            var folderDto = FolderDto.CreateFolderMainInfo(directoryInfo);
            folderDto.Directories = FolderDto.SubDirectories(directoryInfo.GetDirectories().Where(x =>
                    !x.Attributes.HasFlag(FileAttributes.ReparsePoint) && !x.Attributes.HasFlag(FileAttributes.System)
                    ).ToArray());
            folderDto.Files = FolderDto.FileInfoToFilesDto(directoryInfo);

            return folderDto;
        }

        // Метод заполнения основной информации о текущем каталоге
        public static FolderDto CreateFolderMainInfo(DirectoryInfo directoryInfo)
        {
            var foldersDto = new FolderDto()
            {
                Name = directoryInfo.Name,
                PathToDirectory = directoryInfo.FullName,
                CreationTime = directoryInfo.CreationTimeUtc.ToString(new CultureInfo("de-DE")),
            };

            return foldersDto;
        }

        // Метод получения подкаталогов (1-го уровня вложенности) для для текущего каталога
        public static SubFolderDto[] SubDirectories(DirectoryInfo[] dirInfoCollection)
        {
            SubFolderDto[] foldersCollection = new SubFolderDto[dirInfoCollection.Length];
            int i = 0;
            foreach (var di in dirInfoCollection)
            {
                foldersCollection[i] = SubFolderDto.CreateSubFolderMainInfo(di);
                i++;
            }

            return foldersCollection;
        }

        // Метод получения списка файлов (1-го уровня вложенности) для текущего каталога
        public static FileDto[] FileInfoToFilesDto(DirectoryInfo directoryInfo)
        {
            FileDto[] filesCollection = new FileDto[directoryInfo.GetFiles().Length];
            int i = 0;
            foreach (var fi in directoryInfo.GetFiles())
            {
                filesCollection[i]= FileDto.CreateFromFileInfo(fi);
                i++;
            }

            return filesCollection;
        }
    }
}