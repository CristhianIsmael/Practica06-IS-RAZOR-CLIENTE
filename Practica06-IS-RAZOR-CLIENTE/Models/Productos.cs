using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica06_IS_RAZOR_CLIENTE.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Iva { get; set; }

        public Productos() { }

        public Productos(int id, string name, decimal price, bool iva)
        {
            Id = id;
            Name = name;
            Price = price;
            Iva = iva;
        }
    }
}