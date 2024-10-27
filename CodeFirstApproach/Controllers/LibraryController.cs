using LibraryManagementProject.DataAccess;
using LibraryManagementProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class LibraryController : ControllerBase
{
    private readonly LibraryDbContext _context;
    private readonly LibraryService _libraryService;

    public LibraryController(LibraryDbContext context, LibraryService libraryService)
    {
        _context = context;
        _libraryService = libraryService;
    }

    [HttpPost("borrow")]   
    public async Task<IActionResult> BorrowBook(int userId, int bookId)
    {
        var success = await _libraryService.BorrowBookAsync(bookId, userId);
        if (!success) return BadRequest("Book cannot be borrowed.");
        return Ok("Book borrowed successfully.");
    }

    [HttpPost("return")] 
    public async Task<IActionResult> ReturnBook(int userId, int bookId)
    {
        var success = await _libraryService.ReturnBookAsync(bookId, userId);
        if (!success) return BadRequest("Book cannot be returned.");
        return Ok("Book returned successfully.");
    }

    [HttpGet("getAllBooks")]   
    public async Task<IActionResult> GetAllBooks()
    {
        var success = await _libraryService.GetAllBooks();

        return new OkObjectResult(success);
    }

    [HttpGet("Search")]
    public async Task<IActionResult> SearchBook(string title)
    {
        var result = await _libraryService.SearchBooksByTitle(title);
        return new OkObjectResult(result);
    }

    [HttpGet("getAllUserTransactions")]
    public async Task<IActionResult> GetAllUserTransactions(int userID)
    {
        var success = await _libraryService.GetAllTransactions(userID);

        return new OkObjectResult(success);
    }

    [HttpGet("getCurrentUser")]
    public async Task<IActionResult> GetCurrentUser(int userID)
    {
        var success = await _libraryService.GetCurrentUser(userID);

        return new OkObjectResult(success);
    }

    [HttpGet("GetBookTransactions")]
    public async Task<IActionResult> GetBookTransactions()
    {
        var success = await _libraryService.GetBookTransaction();

        return new OkObjectResult(success);
    }

    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUserAccount(UserModel userModel)
    {
        var success = await _libraryService.CreateUserAccount(userModel);
        if (!success) return BadRequest("User cannot be created.");
        return Ok("User Account Created successfully.");
    }
}