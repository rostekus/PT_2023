using DataAccess.API;

namespace DataAccess.SampleImplementation;

public class BookRepository : IBookRepository
{
    private readonly LibraryDataContext _context;
    public BookRepository(LibraryDataContext context)
    {
        _context = context;
    }

    public List<IBook> GetAll() => _context._Books;
    
    public IBook GetById(string guid)
    {
        // check if user exists with the same guid in repository
        var book = this._context._Books.Find(checkBook => checkBook.Guid == guid);
        if (book== null)
        {
            throw new Exception("No Book with specified GUID");
        }

        return book;
    }

    public void Add(IBook entity)
    {
        this._context._Books.Add(entity);
    }

    public void Update(IBook entity)
    {
        for (var index = 0; index < _context._Books.Count; index++)
        {
            var user = _context._Books[index];
            if (user.Guid != entity.Guid)
                continue;

            _context._Books.Remove(user);
            _context._Books.Add(entity);
            return;
        }
    }


    public void Create(IBook book)
    {
        // check if book exists with the same guid in repository
        var bookDuplicate = this._context._Books.Find(checkBook => checkBook.Guid == book.Guid);
        if (bookDuplicate == null)
        {
            throw new Exception("Book with that GUID exists in repository");
        }
        _context._Books.Add(book);
    }

    public void Delete(IBook book)
    {
        var foundBook = this._context._Books.Find(checkBook => checkBook.Guid == book.Guid);
        if (book== null)
        {
            throw new Exception("No Book with specified GUID");
        }

        this._context._Books.RemoveAll(checkBook => checkBook.Guid == book.Guid);

    }
}