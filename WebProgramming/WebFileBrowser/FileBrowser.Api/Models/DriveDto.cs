using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FileBrowser.Api.Models
{
    [DataContract]
    public class DriveDto
    {
        // Описание свойств и их имен в сериализированном виде
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "img")]
        public string Img { get; set; }

        public static DriveDto CreateFromDriveInfo(DriveInfo driveInfo)
        {
            var driveDto = new DriveDto()
            {
                Name = driveInfo.Name,
                Img = @"img//drive.png"
            };

            return driveDto;
        }

        // Метод возвращает массив объектов DriveDto, каждый из которых является упрощенной моделью класса DriveInfo
        public static DriveDto[] AllDrives(DriveInfo[] driveCollection)
        {
            DriveDto[] driveDtos = new DriveDto[driveCollection.Length];
            int i = 0;
            foreach (DriveInfo di in driveCollection)
            {
                if(di.DriveType == DriveType.Fixed)
                {
                    driveDtos[i] = DriveDto.CreateFromDriveInfo(di);
                    i++;
                }
            }
            return driveDtos.Where(x => x != null).ToArray();
        }
    }
}