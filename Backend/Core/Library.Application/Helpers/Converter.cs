using System.Text;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Helpers;

public class Converter : IConverter
{
    public string GetAuthorsInLine(BookEntity book)
    {
        return String.Join(", ", book.Authors.Select(a => a.FullName));
    }
}