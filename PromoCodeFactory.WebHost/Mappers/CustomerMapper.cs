using PromocodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Mappers
{
	public static class CustomerMapper
	{
		public static Customer MapFromModel(CreateOrEditCustomerRequest request,
			IEnumerable<Preference> preferences, Customer customer = null)
		{
			if (customer == null)
			{
				customer = new Customer();
			}

			customer.Email = request.Email;
			customer.FirstName = request.FirstName;
			customer.LastName = request.LastName;

			if (preferences != null && preferences.Any())
			{
				customer.Preferences?.Clear();
				customer.Preferences = preferences.Select(x => new CustomerPreference()
				{
					Customer = customer,
					Preference = x
				}).ToList();
			}
			return customer;
		}
	}
}
