using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Senparc.CO2NET.Extensions;
using WeChatCloudFunction.Web.Models;

namespace WeChatCloudFunction.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Api()
        {
            var wxOpenSetting = Senparc.Weixin.Config.SenparcWeixinSetting.WxOpenSetting;
            var envId = "senparc-robot-5f5128";//换成您自己的“环境ID”，获取方法：小程序开发工具 > 云开发 > 设置 > 复制右上角“环境ID”参数
            var result = Senparc.Weixin.WxOpen.AdvancedAPIs.Tcb
                            .TcbApi.DatabaseCollectionGet(wxOpenSetting.WxOpenAppId, envId);
            return Content(result.ToJson(true));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
