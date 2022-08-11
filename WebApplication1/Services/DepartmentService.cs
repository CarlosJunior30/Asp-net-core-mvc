using WebApplication1.Models;
using WebApplication1.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class DepartmentService
    {
        private readonly WebApplication1Context _context;

        public DepartmentService(WebApplication1Context context)
        {
            _context = context;

        }
        public async Task<List<Department>> FindAllAsync()//funcao asyncrona
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
