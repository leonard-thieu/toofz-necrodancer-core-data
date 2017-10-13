using System;
using System.Data.Entity;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer
{
    public interface INecroDancerContext : IDisposable
    {
        DbSet<Item> Items { get; }
        DbSet<Enemy> Enemies { get; }
    }
}