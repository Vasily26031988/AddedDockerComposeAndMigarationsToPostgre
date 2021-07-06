using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromocodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.WebHost.Models
{
	public class CustomerShortResponse
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public CustomerShortResponse()
		{

		}

		public CustomerShortResponse(Customer customer)
		{
			Id = customer.Id;
			Email = customer.Email;
			FirstName = customer.FirstName;
			LastName = customer.LastName;
		}
	}
}
