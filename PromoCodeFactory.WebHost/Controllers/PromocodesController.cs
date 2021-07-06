﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromocodeFactory.Core.Abstractions.Repositories;
using PromocodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
	/// <summary>
	/// Промокоды
	/// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class PromocodesController
		: ControllerBase
	{
		private readonly IRepository<PromoCode> _promoCodesRepository;

		public PromocodesController(IRepository<PromoCode> promoCodesRepository)
		{
			_promoCodesRepository = promoCodesRepository;
		}

		/// <summary>
		/// Получить все промокоды
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
		{
			var preferences = await _promoCodesRepository.GetAllAsync();

			var response = preferences.Select(x => new PromoCodeShortResponse()
			{
				Id = x.Id,
				Code = x.Code,
				BeginDate = x.BeginDate.ToString("yyyy-MM-dd"),
				EndDate = x.EndDate.ToString("yyyy-MM-dd"),
				PartnerName = x.PartnerName,
				ServiceInfo = x.ServiceInfo
			}).ToList();

			return Ok(response);
		}
	}
}
