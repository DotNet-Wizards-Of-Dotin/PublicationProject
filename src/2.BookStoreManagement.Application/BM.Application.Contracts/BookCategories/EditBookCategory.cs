using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.BookCategories
{
	public class EditBookCategory : CreateBookCategory
	{
		public byte Id { get; set; }
	}
}
