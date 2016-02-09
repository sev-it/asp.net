using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBrowser.Api.Models
{
    [DataContract]
    public class FileSizeDto
    {
        // Описание свойств и их имен в сериализированном виде
        [DataMember(Name = "less_ten")]
        public int lessTen { get; set; }

        [DataMember(Name = "ten_to_fifty")]
        public int tenFifty { get; set; }

        [DataMember(Name = "over_hundred")]
        public int overHundred { get; set; }

        // Создаёт модель FileSizeDto, которая в последующем отправляется в клиентскую часть.
        // Данный объект будет хранить в себе информацию о количестве файлов в текущем и вложенных каталогах
        public static FileSizeDto CreateFromArray(int[] counters)
        {
            var fileSizeDto = new FileSizeDto()
            {
                lessTen = counters[0],
                tenFifty = counters[1],
                overHundred = counters[2]
            };

            return fileSizeDto;
        }
    }
}