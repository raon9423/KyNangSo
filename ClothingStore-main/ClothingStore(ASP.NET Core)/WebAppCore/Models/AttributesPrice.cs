using System;
using System.Collections.Generic;

namespace WebAppCore.Models;

public partial class AttributesPrice
{
    public int AttributesPricesId { get; set; }

    public int? AttributeId { get; set; }

    public int? ProductId { get; set; }

    public int? Price { get; set; }

    public bool? Active { get; set; }
}
