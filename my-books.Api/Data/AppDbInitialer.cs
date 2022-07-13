namespace my_books.Api.Data
{
    public class AppDbInitialer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var seviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = seviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book
                    {
                        Title = "1st Book",
                        Description = "1st Book",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "1st Author",
                        CoverUrl = "http..",
                        DateAdded = DateTime.Now,
                    },
                    new Models.Book
                    {
                        Title = "2nd Book",
                        Description = "2nd Book",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "1st Author",
                        CoverUrl = "http..",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
