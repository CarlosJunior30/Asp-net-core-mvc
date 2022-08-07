using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public class SellerService
    {
        private readonly WebApplication1Context _context;

        public SellerService(WebApplication1Context context)
        {
            _context = context;

        }
        public List <Seller> FindALL()//Retorna uma Lista com todos os vendedores;
        {
            return _context.Seller.ToList();
        }
    }
}
