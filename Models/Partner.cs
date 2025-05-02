using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string? TypePartner { get; set; }

    public string? Name { get; set; }

    public string? Director { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Adress { get; set; }

    public string? Inn { get; set; }

    public int? Rating { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
