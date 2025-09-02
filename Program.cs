using APIRestful.DbObjects;
using APIRestful.Objetos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogPostDb>(opt => opt.UseInMemoryDatabase("BlogPostList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

#region Get
app.MapGet("/", () => "Go to SwaggerAPi at https://localhost:8888/swagger/index.html");

app.MapGet("/api/posts", async (BlogPostDb blogPostDb) => 
await blogPostDb.BlogPosts.Include(p => p.Comments).Where(x => !x.IsUnlisted).ToListAsync());

app.MapGet("/api/posts/{id}", async (int id, BlogPostDb blogPostDb) =>
await blogPostDb.BlogPosts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id) is BlogPost blogPost ? 
Results.Ok(blogPost) : Results.NotFound());

app.MapGet("/api/posts/{id}/comments", async (int id, BlogPostDb blogPostDb) =>
await blogPostDb.BlogPosts.FindAsync(id) is BlogPost blogPost ?
Results.Ok(blogPost.Comments) : Results.NotFound());
#endregion

#region Post
app.MapPost("/api/posts", async (BlogPost blogPost, BlogPostDb blogPostDb) =>
{
blogPostDb.BlogPosts.Add(blogPost);
await blogPostDb.SaveChangesAsync();

return Results.Created($"/api/posts/{blogPost.Id}", blogPost);
});
#endregion

#region Put
app.MapPut("/api/posts/{id}/comments", async (int id, Comment comment, BlogPostDb blogPostDb) =>
{
    BlogPost? blogPost = await blogPostDb.BlogPosts.FindAsync(id);
    if (blogPost is null) return Results.NotFound();

    blogPost.Comments.Add(comment);

    await blogPostDb.SaveChangesAsync();

    return Results.Ok(comment);
}); 
#endregion

app.Run();
