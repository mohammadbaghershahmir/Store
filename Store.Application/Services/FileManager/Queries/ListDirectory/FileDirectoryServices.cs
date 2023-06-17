using FluentFTP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Store.Common.Constant.FileTypeManager;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Queries.ListDirectory
{
    public class FileDirectoryServices : IFileDirectoryService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;
        public FileDirectoryServices(IHostingEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }
        public async Task<List<FileItem>> GetFilesAsync(string directoryPath = "")
        {

            // اتصال به سرور FTP
            using (var client = new FtpClient())
            {
                string ftpServer = _configuration.GetSection("FtpServer").Value;
                string username = _configuration.GetSection("FtpUsername").Value;
                string password = _configuration.GetSection("FtpPassword").Value;
                string ftpRoot = _configuration.GetSection("ftpRoot").Value;
                string BaseUrl = _configuration.GetSection("BaseUrl").Value;
                string url = ftpRoot + directoryPath;
                client.Host = ftpServer;
                client.Credentials = new NetworkCredential(username, password);
                List<FileItem> directoryItems = new List<FileItem>();

                try
                {
                    foreach (FtpListItem item in client.GetListing(url))
                    {
                        if (item.Type == FtpObjectType.Directory)
                        {
                            directoryItems.Add(new FileItem
                            {
                                Icon = "/AdminTemplate/images/filemanager-icon/folder.png",
                                Name = item.Name,
                                Path = $"/{url}/{item.Name}",
                                Size =item.Size/1024,
                                Type = item.Type.ToString(),
                                FileTypeEnum=FileTypeEnum.Directory,
                                BaseUrl=BaseUrl,
                                Directory=$"/{ item.Name }",

							});
                        }
                        else
                        {
                            string postfix = item.FullName.Split(".").Last().ToString().ToLower();
                            if (postfix == "png" || postfix == "jpg" || postfix == "jpeg" || postfix == "gif")
                            {
                                directoryItems.Add(new FileItem
                                {
                                    Icon = $"/{url}/{item.Name}",
                                    Name = item.Name,
                                    Path = $"/{url}/{item.Name}",
                                    Size = item.Size / 1024,
                                    Type = item.Type.ToString(),
                                    FileTypeEnum=FileTypeEnum.Image,
                                    Postfix=postfix,
                                    BaseUrl = BaseUrl
                                });
                            }
                            else if (postfix == "mp3" || postfix == "wma" || postfix == "aac" || postfix == "ac3" || postfix == "wav")
                            {
                                directoryItems.Add(new FileItem
                                {
                                    Icon = "/AdminTemplate/images/filemanager-icon/audio-icon.png",
                                    Name = item.Name,
                                    Path = $"/{url}/{item.Name}",
                                    Size=item.Size / 1024,
                                    Type=item.Type.ToString(),
                                    FileTypeEnum=FileTypeEnum.Other,
                                    Postfix= postfix,
                                    BaseUrl = BaseUrl

                                });
                            }
                            else if (postfix == "avi" || postfix == "mp4" || postfix == "mkv" || postfix == "wma" || postfix == "mpeg" || postfix == "mov")
                            {
                                directoryItems.Add(new FileItem
                                {
                                    Icon = "/AdminTemplate/images/filemanager-icon/video.png",
                                    Name = item.Name,
                                    Path = $"/{url}/{item.Name}",
                                    Size = item.Size / 1024,
                                    Type = item.Type.ToString(),
                                    FileTypeEnum=FileTypeEnum.Other,
                                    Postfix= postfix,
                                    BaseUrl = BaseUrl
                                });
                            }
                            else
                            {
                                directoryItems.Add(new FileItem
                                {

                                    Icon = "/AdminTemplate/images/filemanager-icon/file.png",
                                    Name = item.Name,
                                    Path = $"/{url}/{item.Name}",
                                    Size = item.Size / 1024,
                                    Type = item.Type.ToString(),
                                    FileTypeEnum=FileTypeEnum.Other,
                                    BaseUrl = BaseUrl,
                                    Postfix=postfix
                                });
                            }
                        }

                    }
                    client.Disconnect();
                    return directoryItems.OrderByDescending(w=>w.FileTypeEnum==FileTypeEnum.Directory).ToList();
                }
                catch (WebException ex)
                {
                    return directoryItems;
				}
            }
        }
    }
}
