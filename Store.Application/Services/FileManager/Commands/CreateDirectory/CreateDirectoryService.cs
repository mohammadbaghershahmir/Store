using FluentFTP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Commands.CreateDirectory
{
	public class CreateDirectoryService : ICreateDirectory
	{
		private readonly IHostingEnvironment _environment;
		private readonly IConfiguration _configuration;
        public CreateDirectoryService(IHostingEnvironment environment, IConfiguration configuration)
        {
			_environment = environment;
			_configuration = configuration;
		}
        public async Task<ResultDto> Execute(string path, string name)
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
					string url = ftpRoot + path+"/"+name;
					client.Host = ftpServer;
					client.Credentials = new NetworkCredential(username, password);
					if(!client.DirectoryExists(url))
					{
						client.CreateDirectory(url);
						client.Disconnect();
						return new ResultDto() { IsSuccess = true, Message = MessageInUser.MessageSuccessDirectory };
					}
					else
					{
						return new ResultDto() { IsSuccess = false, Message = MessageInUser.MessageDirectoryExist };
					}

				}
			}
			catch (Exception)
			{

				return new ResultDto() { IsSuccess = false, Message = MessageInUser.MessageInvalidOperation };
			}
			}
	}
}
