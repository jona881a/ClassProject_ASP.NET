using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using classProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace classProject.Data;

public class ClassProjectContext : IdentityDbContext{
    
        public ClassProjectContext (DbContextOptions<ClassProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
            this.SeedPosts(builder);  
            this.SeedComments(builder);  
        }  

        //The databases table name is generated here
        public DbSet<classProject.Models.Post> Posts { get; set; }
        //The databases table name is generated here
        public DbSet<classProject.Models.Comment> Comment { get; set; }
    
        private void SeedPosts(ModelBuilder builder) {
            builder.Entity<Post>().HasData(
            new Post() {PostId = 1,CreationDate = DateTime.Now, Title="Post no 1", Body = "Post 1 bla bla bla", Author="Jonas Kunert", Status=PostStatus.PUBLISHED},
            new Post() {PostId = 2,CreationDate = DateTime.Now, Title="Post no 2", Body = "Post 2 bla bla bla", Author="Jonas Kunert", Status=PostStatus.PUBLISHED},
            new Post() {PostId = 3,CreationDate = DateTime.Now, Title="Post no 3", Body = "Post 3 bla bla bla", Author="Jonas Kunert", Status=PostStatus.PUBLISHED});
        }

        private void SeedComments(ModelBuilder builder) {
            builder.Entity<Comment>().HasData(
            new Comment() {CommentId = 1, CommentDate = DateTime.Now, CommentBody="Amazing post", CommentAuthor="Jonas", PostId=1},
            new Comment() {CommentId = 2, CommentDate = DateTime.Now, CommentBody="Amazing post", CommentAuthor="Jonas", PostId=2},
            new Comment() {CommentId = 3, CommentDate = DateTime.Now, CommentBody="Amazing post", CommentAuthor="Jonas", PostId=3});
        }
}