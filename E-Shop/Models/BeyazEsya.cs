using System;
using System.Collections.Generic;

namespace E_Shop.Entitites;

public partial class BeyazEsya
{
    public int Id { get; set; }

    public string Marka { get; set; } = null!;

    public string Model { get; set; } = null!;

    public decimal Fiyat { get; set; }

    public string Image { get; set; }

    public int? KategoriId { get; set; }

    public virtual Kategoriler? Kategori { get; set; }
}
