using FluentFTP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using System.Xml.Linq;

namespace Store.Application.Services.FileManager.Commands.UploadFiles
{
	public class UploadFileService : IUploadFileService
	{
		private readonly IHostingEnvironment _environment;
		private readonly IConfiguration _configuration;
		public UploadFileService(IHostingEnvironment environment, IConfiguration configuration)
		{
			_configuration = configuration;
			_environment = environment;
		}
		public async Task<ResultDto> Execute(IEnumerable<IFormFile>? files, string? directoryPath)
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
					foreach (var file in files)
					{
						string remoteFilePath = url + "/" + file.FileName;
						using (Stream stream = file.OpenReadStream())
						{
							client.UploadStream(stream, remoteFilePath);
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
