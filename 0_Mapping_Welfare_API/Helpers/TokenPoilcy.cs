using _02_Mapping_Welfare_Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0_Mapping_Welfare_API.Helpers
{
    /// <summary>
    /// 授权验证策略
    /// </summary>
    public class TokenPoilcy : AuthorizationHandler<PermissionRequirement>
    {

		private readonly IWechatUserRepository _wechatUserRepository;

		public TokenPoilcy(IWechatUserRepository wechatUserRepository)
		{
			_wechatUserRepository = wechatUserRepository;
		}

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
			var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext).HttpContext;
			string openid = "";
			if (httpContext.User.Identity.IsAuthenticated)
			{
				var auth = httpContext.AuthenticateAsync().Result.Principal.Claims;
				var guidClaim = auth.FirstOrDefault(s => s.Type == "opeid");

				if (guidClaim != null)
				{
					openid = guidClaim.Value;
					// 根据Guid获取用户信息（该方法是自己编写的）
					if (await _wechatUserRepository.WechatExits(openid))
					{
						context.Succeed(requirement);
						// 验证成功且拥有权限
						//if (requirement.CheckPermission(user))
						//{
						//	context.Succeed(requirement);
						//}
						//else
						//{
						//	// 验证成功但权限不足
						//	httpContext.Response.Redirect($"api/identify/forbidden");
						//}
					}
					else
					{
						// 验证成功，但Guid非法
						httpContext.Response.Redirect($"api/identify/forbidden");
					}
				}
				else
				{
					// 验证成功，但没有包含Guid
					httpContext.Response.Redirect($"api/identify/forbidden");
				}
			}
			else
			{
				// 验证失败，没有包含验证信息
				httpContext.Response.Redirect($"api/identify/forbidden");
			}

			return Task.CompletedTask;
		}
    }
}
