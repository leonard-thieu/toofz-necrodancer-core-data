using System;
using Microsoft.EntityFrameworkCore;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface INecroDancerContext : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        DbSet<Item> Items { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Enemy> Enemies { get; }
    }
}