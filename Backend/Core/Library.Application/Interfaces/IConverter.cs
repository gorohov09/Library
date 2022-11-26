using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IConverter
{
    public string GetAuthorsInLine(BookEntity book);
}