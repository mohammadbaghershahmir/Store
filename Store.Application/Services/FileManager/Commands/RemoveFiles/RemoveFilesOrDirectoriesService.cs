using FluentFTP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Commands.RemoveFiles
{
	public class RemoveFilesOrDirectoriesService : IRemoveFilesOrDirectoriesService
	{
		private readonly IHostingEnvironment _environment;
		private readonly IConfiguration _configuration;
		public RemoveFilesOrDirectoriesService(IHostingEnvironment environment, IConfiguration configuration)
		{
			_environment = environment;
			_configuration = configuration;
		}
		public async Task<ResultDto> Execute(List<string> ArryRemoveItem, string directoryPath)
		{
			try
			{
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
					client.Connect();
					foreach (var item in ArryRemoveItem)
					{
						string directory = "/"+url+ "/" + item;
						var fileInfo=client.GetObjectInfo(directory);
						if (fileInfo.Type == FtpObjectType.File)
						{
							client.DeleteFile(directory);
						}
						else if (fileInfo.Type == FtpObjectType.Directory)
						{
							client.DeleteDirectory(directory);
						}
					}
					client.Disconnect();
					return new ResultDto()
					{
						IsSuccess = true,
						Message = MessageInUser.UploadSuccess
					};
				}
			}
			catch (Exception)
			{

				return new ResultDto()
				{
					IsSuccess = true,
					Message = MessageInUser.UploadInvalid
				};
			}

		}
	}
}
