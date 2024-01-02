﻿using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Models;

namespace UserManagement.Data
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; } = null!;
    }
}
