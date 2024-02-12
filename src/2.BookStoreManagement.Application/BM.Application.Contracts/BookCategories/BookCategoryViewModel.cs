using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Contracts.BookCategories
{
	public class BookCategoryViewModel
	{
		public byte Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
		public string CreationDate { get; set; }
		public long BookCount { get; set; }
		public bool IsDeleted { get; set; }
	}
}
