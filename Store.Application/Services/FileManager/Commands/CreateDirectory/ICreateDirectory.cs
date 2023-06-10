using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Commands.CreateDirectory
{
	public interface ICreateDirectory
	{
		Task<ResultDto> Execute(string path,string name);
	}
}
