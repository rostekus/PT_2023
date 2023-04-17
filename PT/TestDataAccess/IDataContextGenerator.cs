using DataAccess.API;
using DataAccess.SampleImplementation;

namespace TestDataAccess;

public interface IDataContextGenerator
{
    LibraryDataContext Generate();
}