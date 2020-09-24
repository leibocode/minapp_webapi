using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0_Mapping_Welfare_API.Helpers
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
		public bool CheckPermission()
		{
			bool ret = true;
			// 检查用户权限
			// Coding...
			return ret;
		}
	}
}
