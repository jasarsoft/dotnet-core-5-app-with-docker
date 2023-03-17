﻿using CarvedRock.Api.ApiModels;
using CarvedRock.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace CarvedRock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuickOrderController : ControllerBase
    {
        private readonly IQuickOrderLogic _orderLogic;

        public QuickOrderController(IQuickOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        [HttpPost]
        public Guid SubmitQuickOrder(QuickOrder orderInfo)
        {
            Log.Information($"Submitting order for {orderInfo.Quantity} of {orderInfo.ProductId}.");
            return _orderLogic.PlaceQuickOrder(orderInfo, 1234); // would get customer id from authN system/User claims
        }
    }
}
