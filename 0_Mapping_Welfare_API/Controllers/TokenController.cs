using _02_Mapping_Welfare_Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senparc.Weixin;
using Senparc.Weixin.WxOpen.AdvancedAPIs.Sns;
using Senparc.Weixin.WxOpen.Containers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _0_Mapping_Welfare_API.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class TokenController : ControllerBase
    {

        

        public static readonly string Token = "";//与微信小程序后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = "";//与微信小程序后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string WxOpenAppId = "";//与微信小程序后台的AppId设置保持一致，区分大小写。
        public static readonly string WxOpenAppSecret = "";//与微信小程序账号后台的AppId设置保持一致，区分大小写。

        public readonly IWechatUserRepository _wechatUserRepository;

        public TokenController(IWechatUserRepository WechatUserRepository)
        {
            _wechatUserRepository = WechatUserRepository;
        }


        readonly Func<string> _getRandomFileName = () => SystemTime.Now.ToString("yyyyMMdd-HHmmss") + Guid.NewGuid().ToString("n").Substring(0, 6);

        /// <summary>
        /// 小程序登录&&token
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetToken(string code,string wechatName,string avr)
        {
            try
            {
                var jsonResult = SnsApi.JsCode2Json(WxOpenAppId,WxOpenAppSecret,code);

                if (jsonResult.errcode==ReturnCode.请求成功)
                {
                    var unionId = "";
                    var sessionBag = SessionContainer.UpdateSession(null, jsonResult.openid, jsonResult.session_key, unionId);

                    //拿到了openid
                    //写入数据库
                    //发送token 
                    if (!await _wechatUserRepository.AddOrUpdateUser(jsonResult.openid, wechatName, avr))
                    {
                        throw new ArgumentNullException();
                    }

                    List<Claim> payLoadList = new List<Claim>();

                    payLoadList.Add(new Claim("openid",jsonResult.openid));

                    Claim[] payLaod = payLoadList.ToArray();

                    string securityKey = "jwt:sss";

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken token = new JwtSecurityToken(
            claims: payLaod,                            // payload
            signingCredentials: creds,                  // 签证信息
            expires: DateTime.Now.AddMinutes(60));       // 过期时间

                    string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);


                    return Ok(new { Token = tokenStr, Expire = 60 });     //做回送
                }
                else
                {
                    return Ok(new { token = "", expex = 0 ,code=-1});
                }
            }
            catch (Exception)
            {
                return Ok(new { token ="",expex=0,code=-2 });
            }
        }
    }
}
