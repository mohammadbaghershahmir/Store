using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Queries.ListDirectory
{
    public interface IFileDirectoryService
    {
        Task<List<FileItem>> GetFilesAsync(string directoryPath = "");
    }
}
