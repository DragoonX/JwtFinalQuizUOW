﻿using JwtSon.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtSon
{
    public class XContext : DbContext
    {
        public XContext(DbContextOptions<XContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
