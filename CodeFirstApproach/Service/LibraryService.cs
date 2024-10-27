using LibraryManagementProject.DataAccess;
using LibraryManagementProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

public class LibraryService
{
    private readonly LibraryDbContext _context;
    private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

    public LibraryService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<bool> BorrowBookAsync(int bookId, int userId)
    {
        await _lock.WaitAsync(); // To Ensures only one user can modify the book at a time
        try
        {
            var book = await _context.Books.FindAsync(bookId);
            var user = await _context.Users.FindAsync(userId);
            var transResult = await _context.Transactions
                .Where(t => t.UserId == userId && t.BookId == bookId && t.TransactionType.ToLower() == "borrow").ToListAsync();

            if (transResult.Count > 0)
            {
                return false;
            }
            
            if (book == null || user == null || book.AvailableCopies <= 0) return false;

            if (book != null && user != null)
            {
               
                    book.AvailableCopies--;
                    var transaction = new Transaction
                    {
                        BookId = book.Id,
                        UserId = user.Id,
                        TransactionType = "Borrow",
                        CreatedBy = user.Name,
                        UpdatedBy = user.Name,
                    };
                    _context.Transactions.Add(transaction);
                    await _context.SaveChangesAsync();
                    return true;
            }
            else
            {
                return false;
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<bool> ReturnBookAsync(int bookId, int userId)
    {
        await _lock.WaitAsync(); // Ensures only one user can modify the book at a time
        try
        {
            var book = await _context.Books.FindAsync(bookId);
            var user = await _context.Users.FindAsync(userId);
            var transResult = await _context.Transactions
                .Where(t => t.UserId == userId && t.BookId == bookId && t.TransactionType.ToLower() == "borrow").FirstOrDefaultAsync();

            if (book != null && user != null)
            {
                if (transResult != null)
                {
                    book.AvailableCopies++;

                    transResult.UpdatedOn = DateTime.Now;
                    transResult.UpdatedBy = user.Name;
                    transResult.TransactionType = "Return";
                    _context.Transactions.Update(transResult);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
        finally
        {
            _lock.Release();
        }
    }
    public async Task<List<Book>> GetAllBooks()
    {
        try
        {
            return await _context.Books.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Book>> SearchBooksByTitle(string title)
    {
        try
        {
            return await _context.Books
           .Where(b => b.Title.Contains(title))
           .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<Transaction>> GetAllTransactions(int userID)
    {
        try
        {
            return await _context.Transactions.Where(x=>x.UserId==userID).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<User> GetCurrentUser(int userID)
    {
        try
        {
            return await _context.Users.Where(x => x.Id == userID).FirstAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<TransactionHistory>> GetBookTransaction()
    {
        try
        {
            var query = from u in _context.Users
                        join t in _context.Transactions on u.Id equals t.UserId
                        join b in _context.Books on t.BookId equals b.Id
                        select new TransactionHistory
                        {
                            Name = u.Name,
                            Email = u.Email,
                            Author = b.Author,
                            Title = b.Title,
                            CreatedOn = t.CreatedOn,
                            TransactionType = t.TransactionType
                        };
            return await query.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<bool> CreateUserAccount(UserModel user)
    {
        try
        {
           if (user == null) return false;
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return false;                
            }
            else
            {
                user.Password = PasswordHelper.HashPassword(user.Password);
                var userAccount = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    CreatedBy = user.Name,
                    UpdatedBy = user.Name,
                    Status = "Active",
                    UserRole = user.UserRole
                };

                _context.Users.Add(userAccount);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

}
