using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? PartnerId { get; set; }

    public int? Count { get; set; }

    public DateOnly? SaleDate { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Product? Product { get; set; }
}
