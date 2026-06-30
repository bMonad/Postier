using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence;

public class PostierDbContext(DbContextOptions options) :DbContext(options)
{
    public required DbSet<Activity> Activities { get; set; }
}
