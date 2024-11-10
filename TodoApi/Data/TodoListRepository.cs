using AutoBogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoListContext context;

        public TodoListRepository(TodoListContext context)
        {
            if(!context.TodoItems.Any())
            {
                var todoItemFaker = new AutoFaker<TodoItem>()
                    .RuleFor(fake => fake.Body, fake => fake.Name.JobDescriptor())
                    .RuleFor(fake => fake.Title, fake => fake.Name.JobTitle())
                    .RuleFor(fake => fake.Id, fake => fake.IndexFaker + 1)
                    .RuleFor(fake => fake.CompletedAt, () => null)
                    .RuleFor(fake => fake.IsComplete, () => false);

                List<TodoItem> entities = todoItemFaker.GenerateBetween(3, 5);

                context.TodoItems.AddRange(entities);
                context.SaveChanges();
            }

            this.context = context;
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            return await context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetTodoItem(long id)
        {
            return await context.TodoItems.FindAsync(id);
        }

        public async Task UpdateTodoItem(long id, TodoItem todoItem)
        {
            context.Entry(todoItem).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();
            return todoItem;
        }

        public async void DeleteTodoItem(TodoItem todoItem)
        {
            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();
        }

        public bool TodoItemExists(long id)
        {
            return context.TodoItems.Any(e => e.Id == id);
        }
    }
}
