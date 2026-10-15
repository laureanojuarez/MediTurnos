using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
namespace Infrastructure;

public class ApplicationDbContext
{
    public List<User> Users { get; } =
    [
    new User
 {
 Id = 1,
 Name = "Ana",
 LastName = "García",
 Email = "ana.garcia@example.com",
 Password = "demo-password-1",
 CreationDate = new DateTime(2026, 8, 1)
 },
 new User
 {
 Id = 2,
 Name = "Juan",
 LastName = "Pérez",
 Email = "juan.perez@example.com",
 Password = "demo-password-2",
 CreationDate = new DateTime(2026, 8, 15)
 }
    ];

    public List<Product> Products { get; } =
[
 new Product
 {
 Id = 1,
 Name = "Notebook Lenovo IdeaPad",
 Description = "Notebook de 15 pulgadas con 16 GB de RAM",
 Price = 950000m,
 Stock = 6,
 Category = "Informática"
 },
 new Product
 {
 Id = 2,
 Name = "Mouse Logitech M90",
 Description = "Mouse óptico cableado",
 Price = 12500m,
 Stock = 20,
 Category = "Periféricos"
 },
 new Product
 {
 Id = 3,
 Name = "Monitor Samsung 24",
 Description = "Monitor Full HD de 24 pulgadas",
 Price = 245000m,
 Stock = 8,
 Category = "Monitores"
 },
 new Product
 {
 Id = 4,
 Name = "Teclado Redragon Kumara",
 Description = "Teclado mecánico compacto",
 Price = 68000m,
 Stock = 12,
 Category = "Periféricos"
 }
];
    
    
}
