using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBrowser.Api.Assist
{
    public class MessageEnum
    {
        public const string Path = "There is no path parameter";
        public const string Directory = "Directory not found";
        public const string File = "There are no any files or directories on the specified path";
    }
}