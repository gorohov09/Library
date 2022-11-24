using Library.DAL.Context;
using Library.DAL.Interfaces;

namespace Library.DAL.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly LibraryContext _context;
        public RecordRepository(LibraryContext context)
        {
            _context = context;
        }


    }
}
