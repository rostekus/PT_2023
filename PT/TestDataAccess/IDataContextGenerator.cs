using DataAccess.API;
using DataAccess.SampleImplementation;

namespace TestDataAccess;

internal interface IDataContextGenerator
{
    LibraryDataContext Generate();
}