using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignInUser
{
	public interface ISignInUserService
	{
		Task<ResultDto<ResultUserLoginDto>> Execute(string username, string password);
	}
}
