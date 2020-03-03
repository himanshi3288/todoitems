using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoItems.Entities;

namespace TodoItems.Repository
{
    public class TodoItemsContext : DbContext
    {

        public TodoItemsContext(DbContextOptions<TodoItemsContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
