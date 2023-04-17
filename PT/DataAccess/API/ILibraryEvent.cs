namespace DataAccess.API;

public interface ILibraryEvent
{
    string Guid { get; }

    DateTime Time { get; }
}