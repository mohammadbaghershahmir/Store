using Store.Application.Services.FileManager.Queries.ListDirectory;

namespace EndPointStore.Areas.Admin.Models.ViewModelFileManager
{
    public class FileManagerViewModel
    {
        public string CurrentDirectory { get; set; }
        public List<FileItem> Files { get; set; }
    }
}
