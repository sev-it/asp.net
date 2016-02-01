using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using FileBrowser.Api.Models;
using FileBrowser.Api.Assist;

namespace FileBrowser.Api.Controllers
{
    [RoutePrefix("api")]
    public class FileController : ApiController
    {
        [Route("directories/{*path}")]
        public IHttpActionResult GetFolder(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            return Ok(FolderDto.CreateFromDirectoryInfo(di));
        }

        [Route("counters/{*path}")]
        public IHttpActionResult GetCounters(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            return Ok(FileSizeDto.CreateFromArray(SizeCounter.GetFileSizeCounter(di)));
        }
    }
}
