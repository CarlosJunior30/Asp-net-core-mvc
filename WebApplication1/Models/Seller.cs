using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models

{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0}Name size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)] // o framework transformou cade email em um Link de Email
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]// utilizado para custmizar o nome dos atributos da classe
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // utilizado para formatar a ordem da data
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} musst be from {1} to {2}")]
        [Display(Name = "Base Salary")]// utilizado para custmizar o nome dos atributos da classe
        [DisplayFormat(DataFormatString = "{0:f2}")]//formata o modelo de valor para 2 casas decimais apos a virgula
        public double BaseSalary { get; set; }
        
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }
        public Seller(int id, string name, string email, DateTime birthday, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthday = birthday;
            BaseSalary = baseSalary;
            Department = department;
        }
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
