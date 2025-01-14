﻿using System.Threading.Tasks;
using Blog.Core.IServices;
using Blog.Core.Model;
using Blog.Core.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// 建行聚合支付类
    /// </summary>
    [Produces("application/json")]
    [Route("api/Pay")]
    public class PayController : Controller
    { 
        private readonly ILogger<PayController> _logger;
        private readonly IPayServices _payServices;
        /// <summary>
        /// 构造函数
        /// </summary> 
        /// <param name="logger"></param>
        /// <param name="payServices"></param>
        public PayController(ILogger<PayController> logger, IPayServices payServices)
        { 
            _logger = logger;
            _payServices = payServices;
        }
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="payModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [HttpPost]
        [Route("Pay")]
        public async Task<MessageModel<PayReturnResultModel>> Pay(PayNeedModel payModel)
        {
            return await _payServices.Pay(payModel);  
        }
        /// <summary>
        /// 支付结果查询-轮询
        /// </summary>
        /// <param name="payModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [HttpPost]
        [Route("PayCheck")]
        public async Task<MessageModel<PayReturnResultModel>> PayCheck(PayNeedModel payModel)
        {
            return await _payServices.PayCheck(payModel, 1);
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="payModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [HttpPost]
        [Route("PayRefund")]
        public async Task<MessageModel<PayRefundReturnResultModel>> PayRefund(PayRefundNeedModel payModel)
        {
            return await _payServices.PayRefund(payModel);
        }

        
        


    }
}