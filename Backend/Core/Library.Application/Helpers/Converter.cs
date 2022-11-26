using System.Text;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Helpers;

public class Converter : IConverter
{
    public string GetAuthorsInLine(BookEntity book)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var author in book.Authors)
        {
            stringBuilder.AppendFormat("{0}, ",author.FullName);
        }

        stringBuilder.Length -= 2;

        return stringBuilder.ToString();
    }
}