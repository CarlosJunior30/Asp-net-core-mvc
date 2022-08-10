using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services.Exceptions;

namespace WebApplication1.Services
{
    public class SellerService
    {
        private readonly WebApplication1Context _context;

        public SellerService(WebApplication1Context context)
        {
            _context = context;

        }
        public List <Seller> FindALL()//Retorna uma Lista com todos os vendedores,
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)//Inserir novo vendedor no Banco de Dados,
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);

        }
        public void Remove (int id) 
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)//atualizar objeto tipo Seller
		{
            if(!_context.Seller.Any(x=> x.Id == obj.Id))
			{
                throw new NotFoundException("Id not found");

			}
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
			catch(DbConcurrencyException e)
			{
                throw new DbConcurrencyException(e.Message);
			}

		}

    }
}
