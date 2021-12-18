using LinkConverter.Domain.DBEntity;
using LinkConverter.Repository.Postgresql.Mapping;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LinkConverter.Repository.Postgresql.Context
{
    public class LinkConverterContext : DbContext
    {
        #region Ctor
        public LinkConverterContext(DbContextOptions<LinkConverterContext> options) : base(options)
        {
        }
        #endregion

        #region Tables
        public DbSet<TestEntity> Tests { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestEntityMapping());

        }
        #endregion
    }



}
