using System;
using System.Collections.Generic;

namespace E_Shop.Entitites;

public partial class Kategoriler
{
    public int KategoriId { get; set; }

    public string KategoriAdi { get; set; } = null!;

    public virtual ICollection<BeyazEsya> BeyazEsyas { get; set; } = new List<BeyazEsya>();

    public virtual ICollection<Elektronik> Elektroniks { get; set; } = new List<Elektronik>();

    public virtual ICollection<Iphone> Iphones { get; set; } = new List<Iphone>();
}
