using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Collections.Pooled;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.POS.Models;

public partial class Transaction:ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Item> _items = new();
    public string TransactionNumber { get; set; } = string.Empty;
    public string Receipt { get; set; } = string.Empty;
    public Discount Discount { get; set; }

    public void AddItem(Product product,int quantity,Discount discount)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero");
        
        var item = new Item()
        {
            Product = product,
            Quantity = quantity,
            Discount = discount,
        };
        item.GetTotal();
        Items.Add(item);
        OnPropertyChanged(nameof(Total));
    }

    public void RemoveItem(string barcode)
    {
        var product = Items.Where(x => x.Product.Barcode == barcode).FirstOrDefault();

        if (product is not null)
        {
            Items.Remove(product);
        }
    }
    public void ApplyDiscount(Discount discount)
    {
        if (discount.Code == "SC")
        {
            var limit = 34500m;
            foreach (var item in Items)
            {
                item.ApplyDiscount(discount,limit);
                limit -= item.DiscountAmount;
            }
        }
        OnPropertyChanged(nameof(Items));
        OnPropertyChanged(nameof(Total));
        
    }
    
    public decimal Total => Items.Sum(x => x.Total);
}