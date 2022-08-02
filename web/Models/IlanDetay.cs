using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using web.Identity;

#nullable enable

namespace web.Models
{
    public class IlanDetay
    {
        public Ilanlar Ilan { get; set; }
        public User? IlanVeren { get; set; }
    }
}