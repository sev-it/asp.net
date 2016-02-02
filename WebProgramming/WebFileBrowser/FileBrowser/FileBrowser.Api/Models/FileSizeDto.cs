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
        [DataMember(Name = "less_ten")]
        public int lessTen { get; set; }

        [DataMember(Name = "ten_to_fifty")]
        public int tenFifty { get; set; }

        [DataMember(Name = "over_hundred")]
        public int overHundred { get; set; }

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