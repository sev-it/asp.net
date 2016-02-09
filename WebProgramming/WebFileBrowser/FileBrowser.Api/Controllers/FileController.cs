using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using FileBrowser.Api.Models;
using FileBrowser.Api.Assist;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace FileBrowser.Api.Controllers
{
    [RoutePrefix("api")]
    public class FileController : ApiController
    {
        // Метод получения информации о текущем каталоге, его вложенных каталогах и файлах. Если параметр path пуст
        // метод вернёт список разделов жёсткого диска
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("directories/{*path}")]
        public IHttpActionResult GetFolder(string path = null)
        {
            DirectoryInfo di;
            if (path != null)
                di = new DirectoryInfo(path);
            else
            {
                var drives = new ResponseDto<DriveDto[]>() { Success = true, Result = DriveDto.AllDrives(DriveInfo.GetDrives()) };
                return Ok(drives);
            }

            if (!di.Exists)
            {
                return Ok(ResponseDto<FolderDto>.CreateMessage(MessageEnum.Directory, false));
            }

            var response = new ResponseDto<FolderDto>() { Success = true, Result = FolderDto.CreateFromDirectoryInfo(di) };
            return Ok(response);
        }
        
        // Метод подсчета количества файлов по диапазонам размеров:
        // <= 10mb
        // > 10mb AND <= 50mb
        // >= 100mb
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("counters/{*path}")]
        public IHttpActionResult GetCounters(string path = null)
        {
            DirectoryInfo di;
            if (path != null)
                di = new DirectoryInfo(path);
            else
            {
                return Ok(ResponseDto<FileDto>.CreateMessage(MessageEnum.Path, false));
            }

            if (!di.Exists)
            {
                return Ok(ResponseDto<FileDto>.CreateMessage(MessageEnum.File, false));
            }

            var response = new ResponseDto<FileSizeDto>() { Success = true, Result = FileSizeDto.CreateFromArray(SizeCounter.GetFileSizeCounter(di)) };
            return Ok(response);
        }
    }
}
