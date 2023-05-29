using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.POS.Models;

public partial class Item:ObservableObject
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    [ObservableProperty] public Discount _discount;
    [ObservableProperty] public decimal _discountAmount;
    public decimal Total { get;private set; }

    public void GetTotal()
    {
        var subTotal = Product.Price * Quantity;
        var discount = Discount is not null? Discount.Rate / 100 : 0;
        DiscountAmount = subTotal * discount;
        Total = subTotal - (subTotal * discount);
        OnPropertyChanged(nameof(Total));
    }
    public void ApplyDiscount(Discount discount,decimal limit)
    {
        if (discount.Code == "SC")
        {
            if (Product.Discounts.Exists(x=>x.Code == discount.Code))
            {
                var subTotal = (Product.Price * Quantity);
                var discountedTotal = subTotal -(subTotal * (discount.Rate / 100m));
                Discount = discount;
                Total = discountedTotal > limit ? (subTotal) - limit : discountedTotal;
            }
        }
        
        OnPropertyChanged(nameof(Total));
    }
}