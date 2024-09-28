using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Users
{
	public class LogoutGVM
	{

	}

	public class LogoutResponseGVM
	{
		public int Code { get; set; } = 500;
		public bool IsSuccess { get; set; } = false;
		public string Message { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Token { get; set; } = string.Empty;
	}
}
