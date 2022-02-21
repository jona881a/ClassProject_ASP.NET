using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using classProject.Models;

namespace classProject.Data;

public class ClassProjectContext : DbContext {
    
        public ClassProjectContext (DbContextOptions<ClassProjectContext> options)
            : base(options)
        {
        }
        //The databases table name is generated here
        public DbSet<classProject.Models.Post> Posts { get; set; }
    
}