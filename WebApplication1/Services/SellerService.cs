using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services.Exceptions;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class SellerService
    {
        private readonly WebApplication1Context _context;

        public SellerService(WebApplication1Context context)
        {
            _context = context;

        }
        public async Task< List <Seller>> FindALLAsync()//Retorna uma Lista com todos os vendedores,
        {
            return await _context.Seller.ToListAsync();
        }
        public async Task InsertAsync(Seller obj)//Inserir novo vendedor no Banco de Dados,
        {            
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);

        }
        public async Task RemoveAsync (int id) 
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
           await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seller obj)//atualizar objeto tipo Seller
		{
            bool hasAny  = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
			{
                throw new NotFoundException("Id not found");
			}
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
			catch(DbConcurrencyException e)
			{
                throw new DbConcurrencyException(e.Message);
			}

		}

    }
}
