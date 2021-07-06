using System;
using System.Collections.Generic;
using System.Text;

namespace PromocodeFactory.Core.Domain.Administration
{
	public class Role
		: BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }
	}
}
