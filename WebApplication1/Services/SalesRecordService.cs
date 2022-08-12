using WebApplication1.Data;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
	public class SalesRecordService
	{
        private readonly WebApplication1Context _context;
        public SalesRecordService(WebApplication1Context context)
        {
            _context = context;
        }
        public async Task <List<SalesRecord>> FindByDateAsync (DateTime? minDate, DateTime? maxDate)//operacao assincrona que busca as vendas por data
		{
            var result = from obj in _context.SalesRecord select obj;//utilização na pratica do LINQ
            if( minDate.HasValue)
			{
                result = result.Where(x => x.Date >= minDate.Value);
			}
            if(maxDate.HasValue)
			{
                result = result.Where(x => x.Date <= maxDate.Value);
			}
            return await result
                .Include( x=> x.Seller)
                .Include(x=> x.Seller.Department)
                .OrderByDescending(x=> x.Date)
                .ToListAsync();
        }
    }
}
