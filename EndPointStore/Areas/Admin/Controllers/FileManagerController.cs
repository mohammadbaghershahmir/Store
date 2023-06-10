using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.FileManager.Queries.ListDirectory;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileManagerController : Controller
    {
        private readonly IFileDirectoryService _fileDirectoryService;
        public FileManagerController(IFileDirectoryService fileDirectoryService)
        {
            _fileDirectoryService = fileDirectoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
			[HttpPost]
        public async Task<IActionResult> GetDirectoryList(GetDirectoryModel model)
        {
            var files = await _fileDirectoryService.GetFilesAsync(model.Directory);
            return Json(new ResultDto<List<FileItem>>
            { Data=files,
            IsSuccess=true
            }
            );
        }
    }
    public class GetDirectoryModel
    {
        public string? Directory { get; set; }
    }
}
