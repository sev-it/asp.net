using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBrowser.Api.Assist
{
    // Данный класс-шаблон является шаблоном ответа на сторону клиента. Информация об успешности запроса
    // отдаётся в свойствах message и is_success. В случае, если запрос отработал успешно и все переданные в него параметры - верны
    // в свойстве result вернется объект класса FolderDto, с информацией о текущем каталоге, подкаталогах и вложенных файлах
    // либо объект класса FileSizeDto, содержащий информацию о количестве файлов в текущем и во всех вложенных каталогах
    [DataContract]
    public class ResponseDto<T> where T: class
    {
        // Описание свойств и их имен в сериализированном виде
        [DataMember(Name = "message")]
        public string Message {get;set;}

        [DataMember(Name = "is_success")]
        public bool Success {get;set;}

        [DataMember(Name = "result")]
        public T Result {get;set; }

        // Метод для генерации ошибок, в случае неверных входных параметров в контроллер FileController
        public static ResponseDto<T> CreateMessage(string msg, bool isSuccess = true)
        {
             return new ResponseDto<T> { Success = isSuccess, Message = msg };
        }
    }
}