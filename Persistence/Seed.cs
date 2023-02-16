using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book { Title = "Treasure", Content = "Content1", Genre = "Genre1", Author = "Tom Smith", Cover = "Cover1" },
                    new Book { Title = "Criminal Story", Content = "Content2", Genre = "Genre2", Author = "Artur C.D.", Cover = "Cover2" },
                    new Book { Title = "Comics", Content = "Content3", Genre = "Genre3", Author = "Ben", Cover = "Cover3" }
                };

                var reviews = new List<Review>
                {
                    new Review { Message = "Message1", Reviewer = "Reviewer1", Book = books[0] },
                    new Review { Message = "Message2", Reviewer = "Reviewer2", Book = books[0] },
                    new Review { Message = "Message3", Reviewer = "Reviewer3", Book = books[0] },
                    new Review { Message = "Message4", Reviewer = "Reviewer2", Book = books[1] },
                    new Review { Message = "Message5", Reviewer = "Reviewer4", Book = books[1] },
                    new Review { Message = "Message6", Reviewer = "Reviewer5", Book = books[1] },
                    new Review { Message = "Message7", Reviewer = "Reviewer1", Book = books[1] },
                };

                var ratings = new List<Rating>
                {
                    new Rating { Score = 1, Book = books[0] },
                    new Rating { Score = 2, Book = books[0] },
                    new Rating { Score = 2, Book = books[0] },
                    new Rating { Score = 3, Book = books[1] },
                    new Rating { Score = 3, Book = books[1] },
                    new Rating { Score = 4, Book = books[1] },
                    new Rating { Score = 5, Book = books[1] },
                    new Rating { Score = 5, Book = books[1] },
                };

                await context.Books.AddRangeAsync(books);
                await context.AddRangeAsync(reviews);
                await context.AddRangeAsync(ratings);
            }

            await context.SaveChangesAsync();
        }
    }
}