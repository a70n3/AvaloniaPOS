using System;
using System.Collections.Generic;

namespace Avalonia.POS.Models;

public class Product
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string Barcode { get; set; }
    public string UoM { get; set; }
    public decimal VATRate { get; set; }
    public decimal Price { get; set; }
    public List<Discount> Discounts { get; set; } = new();
}

