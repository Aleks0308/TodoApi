using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoListContext : DbContext
    {
        public TodoListContext (DbContextOptions<TodoListContext> options)
            : base(options)
        {
        }

        public DbSet<TodoApi.Models.TodoItem> TodoItems { get; set; } = default!;
    }
}
