using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Avalonia.POS.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.POS.ViewModels;

public partial class MainViewModel:ObservableObject
{
    public event Action OnRemoveItemButtonPressed = delegate {  };
    public event Action OnItemWasRemove = delegate {  };
    public MainViewModel()
    {
        
        Transaction = new Transaction();
        var product1 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "REB WHOLE WHEAT CRAC",
            UoM = "PC",
            Discounts = new List<Discount>()
            {
                new Discount() { Code = "SC", Rate = 12m }
            },
            VATRate = 12,
            Price = 57.20m
        };
        var product2 = new Product()
        {
            Code = "1",
            Barcode = "4800016024467",
            Description = "GREAT TASTE CREAM-O",
            UoM = "PC",
            VATRate = 12,
            Price = 15.00m
        };
        var product3 = new Product()
        {
            Code = "1",
            Barcode = "4800216121911",
            Description = "CHEEZY RED HOT 22GM",
            UoM = "PC",
            VATRate = 12,
            Price = 6.65m
        };
        var product4 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "CHAMPION BAR CITRUS",
            UoM = "PC",
            Discounts = new List<Discount>()
            {
                new Discount() { Code = "SC", Rate = 12m }
            },
            VATRate = 12,
            Price = 23m
        };
        var product5 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "HAPEE FGO SCHT 55G",
            UoM = "PC",
            VATRate = 12,
            Price = 9.95m
        };
        var product6 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "HAPEE OBC SCHT 55G",
            UoM = "PC",
            VATRate = 12,
            Price = 9.95m
        };
        var product7 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "PYLESS PC XB KAL130G",
            UoM = "PC",
            Discounts = new List<Discount>()
            {
                new Discount() { Code = "SC", Rate = 12m }
            },
            VATRate = 12,
            Price = 18.50m
        };
        var product8 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "MAGIC SARAP 21G",
            UoM = "PC",
            VATRate = 12,
            Price = 10.75m
        };
        var product9 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "PAYLESS PC XB HOT CH",
            UoM = "PC",
            VATRate = 12,
            Discounts = new List<Discount>()
            {
                new Discount() { Code = "SC", Rate = 12m }
            },
            Price = 18.50m
        };
        var product10 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "ENRGEN CHMPION 2X30G",
            UoM = "PC",
            VATRate = 12,
            Price = 13.95m
        };
        var product11 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "THOSE DAYS NAPKIN TH ",
            UoM = "PC",
            VATRate = 12,
            Price = 13.20m
        };
        var product12 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "VITAKRTN TMT BRZLN S",
            UoM = "PC",
            VATRate = 12,
            Price = 5.50m
        };
        var product13 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "CLEAR SH COOL SPORT",
            UoM = "PC",
            VATRate = 12,
            Price = 5.60m
        };
        var product14 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "OISHI PRAWN SWT&EX-H ",
            UoM = "PC",
            VATRate = 12,
            Price = 6.30m
        };
        var product15 = new Product()
        {
            Code = "1",
            Barcode = "4800092112492",
            Description = "AJI SEASONING 50GM",
            UoM = "PC",
            VATRate = 12,
            Price = 12.75m
        };
        var product16 =   new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "SURF FAB ANTBC W/MNT",
                UoM = "PC",
                VATRate = 12,
                Price = 5.70m
            };
        var product17 = new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "SURF POW PURPLE BLMS",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount() { Code = "SC", Rate = 12m }
                },
                VATRate = 12,
                Price = 6.50m
            };
        
        Transaction.AddItem(product1,2,Discount);
        Transaction.AddItem(product2,3,Discount);
        Transaction.AddItem(product3,1,Discount);
        Transaction.AddItem(product4,1,Discount);
        Transaction.AddItem(product5,1,Discount);
        Transaction.AddItem(product6,1,Discount);
        Transaction.AddItem(product7,1,Discount);
        Transaction.AddItem(product8,1,Discount);
        Transaction.AddItem(product9,1,Discount);
        Transaction.AddItem(product10,4,Discount);
        Transaction.AddItem(product11,1,Discount);
        Transaction.AddItem(product12,6,Discount);
        Transaction.AddItem(product13,6,Discount);
        Transaction.AddItem(product14,1,Discount);
        Transaction.AddItem(product15,1,Discount);
        Transaction.AddItem(product16,6,Discount);
        Transaction.AddItem(product17,6,Discount);
    }
    [ObservableProperty] private Transaction _transaction = new Transaction();

    [ObservableProperty] private Discount _discount;
    [ObservableProperty] private int _quantity = 1;
    [ObservableProperty] private string _barcode = string.Empty;
    [RelayCommand]
    private void ApplyDiscount()
    {
        Discount = new Discount() { Code = "SC", Rate = 5 };
        Transaction.ApplyDiscount(Discount);
    }

    [RelayCommand]
    private void Find(string barcode)
    {
        var products = new List<Product>()
        {
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description ="REB WHOLE WHEAT CRAC", 
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 57.20m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800016024467",
                Description = "GREAT TASTE CREAM-O",
                UoM = "PC",
                Price = 15.00m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800216121911",
                Description = "CHEEZY RED HOT 22GM",
                UoM = "PC",
                Price = 6.65m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "CHAMPION BAR CITRUS",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 23m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "HAPEE FGO SCHT 55G",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 9.95m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "HAPEE OBC SCHT 55G",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 9.95m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "PYLESS PC XB KAL130G",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 18.50m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "MAGIC SARAP 21G",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 10.75m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "PAYLESS PC XB HOT CH",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 18.50m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "ENRGEN CHMPION 2X30G",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 13.95m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "THOSE DAYS NAPKIN TH ",
                UoM = "PC",
                Price = 13.20m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "VITAKRTN TMT BRZLN S",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 5.50m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "CLEAR SH COOL SPORT",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 5.60m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "OISHI PRAWN SWT&EX-H ",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 6.30m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "AJI SEASONING 50GM",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 12.75m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "SURF FAB ANTBC W/MNT",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 5.70m
            },
            new Product()
            {
                Code = "1",
                Barcode = "4800092112492",
                Description = "SURF POW PURPLE BLMS",
                UoM = "PC",
                Discounts = new List<Discount>()
                {
                    new Discount(){ Code = "SC", Rate = 12m}
                },
                Price = 6.50m
            },
        };

        var product = products.FirstOrDefault(x => x.Barcode == barcode.Trim());

        if (product is not null)
        {
            Transaction.AddItem(product,Quantity,Discount);
        }
    }

    [RelayCommand]
    private void Remove()
    {
        OnRemoveItemButtonPressed.Invoke();
    }

    [RelayCommand]
    private void RemoveItem(string barcode)
    {
        Transaction.RemoveItem(barcode);
        OnItemWasRemove.Invoke();
    }
}