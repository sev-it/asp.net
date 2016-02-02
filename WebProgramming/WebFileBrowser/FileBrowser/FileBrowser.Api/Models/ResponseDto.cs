using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBrowser.Api.Assist
{
    [DataContract]
    public class ResponseDto<T> where T: class
    {
        [DataMember(Name = "message")]
        public string Message {get;set;}

        [DataMember(Name = "is_success")]
        public bool Success {get;set;}

        [DataMember(Name = "result")]
        public T Result {get;set; }

        public static ResponseDto<T> CreateMessage(string msg, bool isSuccess = true)
        {
             return new ResponseDto<T> { Success = isSuccess, Message = msg };
        }
    }
}