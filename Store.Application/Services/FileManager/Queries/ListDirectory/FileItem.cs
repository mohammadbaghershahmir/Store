using Store.Common.Constant.FileTypeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Queries.ListDirectory
{
    public class FileItem
    {
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Path { get; set; }
        public string? BaseUrl { get; set; }
        public long? Size { get; set; }
        public string? Type { get; set; }
        public string? Postfix { get; set; }
        public string? Directory { get; set; }
        public FileTypeEnum FileTypeEnum { get; set; }
    }
}
