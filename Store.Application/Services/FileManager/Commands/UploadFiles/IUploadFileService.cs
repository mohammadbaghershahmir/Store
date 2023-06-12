using Microsoft.AspNetCore.Http;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Commands.UploadFiles
{
	public interface IUploadFileService
	{
		Task<ResultDto> Execute(IEnumerable<IFormFile>? files, string? directoryPath);
	}
}
