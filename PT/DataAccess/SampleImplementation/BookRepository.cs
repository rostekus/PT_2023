using DataAccess.API;

namespace DataAccess.SampleImplementation;

internal class BookRepository : IBookRepository
{
    private readonly LibraryDataContext _context;
    public BookRepository(LibraryDataContext context)
    {
        _context = context;
    }

    public IEnumerable<IBook> GetAll() => _context.Books.Values;
    
    public IBook GetById(string guid)
    {
        var book = this._context.Books[guid]
        return book;
    }

    public void Add(IBook entity)
    {
        this._context.Books.Add(entity.Guid, entity);
    }

    public void Update(IBook entity)
    {
      this._context.Books[entity.Guid] = entity;
    }


    public void Create(IBook book)
    {
       this._context.Books.Add(entity.Guid, entity); 
    }

    public void Delete(IBook book)
    {
        foreach (var s in this._context.Books)
            if (s.Key == book.Guid)
                this._context.Books.Remove(s.Key);
    }


}