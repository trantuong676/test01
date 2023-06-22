using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEST02.Models;

    public class LTQLDBb : DbContext
    {
        public LTQLDBb (DbContextOptions<LTQLDBb> options)
            : base(options)
        {
        }

        public DbSet<TEST02.Models.NhaCungCap> NhaCungCap { get; set; } = default!;

        public DbSet<TEST02.Models.SanPham> SanPham { get; set; } = default!;
    }
