using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.FileManager.Commands.CreateDirectory;
using Store.Application.Services.FileManager.Commands.RemoveFiles;
using Store.Application.Services.FileManager.Commands.UploadFiles;
using Store.Application.Services.FileManager.Queries.ListDirectory;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileManagerController : Controller
    {
        private readonly IFileDirectoryService _fileDirectoryService;
        private readonly ICreateDirectory _createDirectory;
		private readonly IUploadFileService _uploadFileService;
        private readonly IRemoveFilesOrDirectoriesService _removeFilesOrDirectoriesService;
		public FileManagerController(IFileDirectoryService fileDirectoryService, ICreateDirectory createDirectory, IUploadFileService uploadFileService, IRemoveFilesOrDirectoriesService removeFilesOrDirectoriesService)
        {
            _fileDirectoryService = fileDirectoryService;
            _createDirectory = createDirectory;
            _uploadFileService = uploadFileService;
            _removeFilesOrDirectoriesService = removeFilesOrDirectoriesService;
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
		[HttpPost]
		public async Task<IActionResult> CreateDirectory(CreateDirectoryModel createDirectory)
		{
			var files = await _createDirectory.Execute(createDirectory.Directory, createDirectory.Name);
			return Json(files);
		}
		[HttpPost]
		public async Task<IActionResult> UploadFiles(IEnumerable<IFormFile> Files,string Directory)
		{
            var result =await  _uploadFileService.Execute(Files, Directory);
            return Json(result);
		}
		[HttpPost]
		public async Task<IActionResult> RemoveFiles(RemoveFilesModel removeFiles)
		{
			var result = await _removeFilesOrDirectoriesService.Execute(removeFiles.ArryRemoveItem, removeFiles.Directory);
			return Json(result);
		}
	}
    public class GetDirectoryModel
    {
        public string? Directory { get; set; }
    }
	public class CreateDirectoryModel
	{
		public string? Directory { get; set; }
        public string? Name { get; set; }
    }
	public class RemoveFilesModel
	{
        public List<string>? ArryRemoveItem { get; set; }
		public string? Directory { get; set; }
	}
}
