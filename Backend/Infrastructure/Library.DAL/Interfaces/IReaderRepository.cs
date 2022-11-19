﻿namespace Library.DAL.Interfaces
{
    public interface IReaderRepository
    {
        Task<bool> IsStudentCard(string studentCard);

        Task<bool> IsLibraryCard(string libraryCard);
    }
}