using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models

{
    
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType ( DataType.EmailAddress)] // o framework transformou cade email em um Link de Email
        public string Email { get; set; }
        
        [Display (Name = "Birth Date")]// utilizado para custmizar o nome dos atributos da classe
        [DataType (DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")] // utilizado para formatar a ordem da data
        public DateTime Birthday { get; set; }

        [Display (Name = "Base Salary")]// utilizado para custmizar o nome dos atributos da classe
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
