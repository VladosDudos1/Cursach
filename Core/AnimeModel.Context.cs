﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class animeEntities : DbContext
    {
        public animeEntities()
            : base("name=animeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ListType> ListType { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<TitleType> TitleType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserLists> UserLists { get; set; }
    }
}