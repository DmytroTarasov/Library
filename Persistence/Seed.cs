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
                    new Book { Title = "Dracula", Content = "Content", Genre = "horror", Author = "Bram Stoker" },
                    new Book { Title = "Frankenstein", Content = "Content", Genre = "horror", Author = "Mary Shelley" },
                    new Book { Title = "The Shining", Content = "Content", Genre = "horror", Author = "Stephen King" },
                    new Book { Title = "Harry Potter and the Philosopher's Stone", Content = "Content", Genre = "fiction", Author = "Rowling, J.K." },
                    new Book { Title = "Harry Potter and the Deathly Hallows", Content = "Content", Genre = "fiction", Author = "Rowling, J.K." },
                    new Book { Title = "Harry Potter and the Order of the Phoenix", Content = "Content", Genre = "fiction", Author = "Rowling, J.K." },
                    new Book { Title = "The Haunting of Hill House", Content = "Content", Genre = "horror", Author = "Shirley Jackson" },
                    new Book { Title = "House of Leaves", Content = "Content", Genre = "horror", Author = "Mark Z. Danielewski" },
                    new Book { Title = "Carrie", Content = "Content", Genre = "horror", Author = "Stephen King" },
                    new Book { Title = "Ghost Story", Content = "Content", Genre = "horror", Author = "Peter Straub" }
                };

                var reviews = new List<Review>
                {
                    new Review { Message = "Message1", Reviewer = "Reviewer1", Book = books[0] },
                    new Review { Message = "Message2", Reviewer = "Reviewer2", Book = books[0] },
                    new Review { Message = "Message3", Reviewer = "Reviewer3", Book = books[0] },
                    new Review { Message = "Message4", Reviewer = "Reviewer1", Book = books[0] },
                    new Review { Message = "Message5", Reviewer = "Reviewer2", Book = books[0] },
                    new Review { Message = "Message6", Reviewer = "Reviewer3", Book = books[0] },
                    new Review { Message = "Message7", Reviewer = "Reviewer1", Book = books[0] },
                    new Review { Message = "Message8", Reviewer = "Reviewer2", Book = books[0] },
                    new Review { Message = "Message9", Reviewer = "Reviewer3", Book = books[0] },
                    new Review { Message = "Message10", Reviewer = "Reviewer2", Book = books[0] },
                    new Review { Message = "Message11", Reviewer = "Reviewer4", Book = books[0] },

                    new Review { Message = "Message12", Reviewer = "Reviewer1", Book = books[1] },
                    new Review { Message = "Message13", Reviewer = "Reviewer2", Book = books[1] },
                    new Review { Message = "Message14", Reviewer = "Reviewer3", Book = books[1] },
                    new Review { Message = "Message15", Reviewer = "Reviewer1", Book = books[1] },
                    new Review { Message = "Message16", Reviewer = "Reviewer6", Book = books[1] },
                    new Review { Message = "Message17", Reviewer = "Reviewer3", Book = books[1] },
                    new Review { Message = "Message18", Reviewer = "Reviewer8", Book = books[1] },
                    new Review { Message = "Message19", Reviewer = "Reviewer4", Book = books[1] },
                    new Review { Message = "Message20", Reviewer = "Reviewer3", Book = books[1] },
                    new Review { Message = "Message21", Reviewer = "Reviewer7", Book = books[1] },
                    new Review { Message = "Message22", Reviewer = "Reviewer6", Book = books[1] }
                };

                var ratings = new List<Rating>
                {
                    new Rating { Score = 3, Book = books[0] },
                    new Rating { Score = 3, Book = books[0] },
                    new Rating { Score = 5, Book = books[0] },

                    new Rating { Score = 4, Book = books[1] },
                    new Rating { Score = 3, Book = books[1] },
                    new Rating { Score = 4, Book = books[1] },
                    new Rating { Score = 5, Book = books[1] },
                    new Rating { Score = 5, Book = books[1] },

                    new Rating { Score = 3, Book = books[2] },
                    new Rating { Score = 3, Book = books[2] },
                    new Rating { Score = 3, Book = books[2] },

                    new Rating { Score = 2, Book = books[3] },
                    new Rating { Score = 4, Book = books[3] },
                    new Rating { Score = 5, Book = books[3] },
                    new Rating { Score = 3, Book = books[3] },

                    new Rating { Score = 4, Book = books[4] },
                    new Rating { Score = 4, Book = books[4] },
                    new Rating { Score = 3, Book = books[4] },
                    new Rating { Score = 2, Book = books[4] },

                    new Rating { Score = 5, Book = books[5] },
                    new Rating { Score = 5, Book = books[5] },
                    new Rating { Score = 3, Book = books[5] },
                    new Rating { Score = 4, Book = books[5] }
                };

                await context.Books.AddRangeAsync(books);
                await context.AddRangeAsync(reviews);
                await context.AddRangeAsync(ratings);
            }

            await context.SaveChangesAsync();
        }
    }
}