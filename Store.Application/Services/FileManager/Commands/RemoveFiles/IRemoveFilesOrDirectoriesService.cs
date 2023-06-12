using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Commands.RemoveFiles
{
	public interface IRemoveFilesOrDirectoriesService
	{
		Task<ResultDto> Execute(List<string> ArryRemoveItem, string directoryPath);
	}
}
