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

namespace FileBrowser.Api.Controllers
{
    [RoutePrefix("api")]
    public class FileController : ApiController
    {
        [Route("directories/{*path}")]
        public IHttpActionResult GetFolder(string path = null)
        {
            DirectoryInfo di;
            if (path != null)
                di = new DirectoryInfo(path);
            else
            {
                return Ok(ResponseDto<FolderDto>.CreateMessage(MessageEnum.Path, false));
            }

            if (!di.Exists)
            {
                return Ok(ResponseDto<FolderDto>.CreateMessage(MessageEnum.Directory, false));
            }

            var response = new ResponseDto<FolderDto>() { Success = true, Result = FolderDto.CreateFromDirectoryInfo(di) };
            return Ok(response);
        }

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
