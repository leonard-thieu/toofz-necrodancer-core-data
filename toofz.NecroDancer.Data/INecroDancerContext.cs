using System;
using System.Data.Entity;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer
{
    public interface INecroDancerContext : IDisposable
    {
        DbSet<Enemy> Enemies { get; set; }
        DbSet<Item> Items { get; set; }
    }
}