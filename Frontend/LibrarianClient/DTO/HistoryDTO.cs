﻿using System.Collections.Generic;

namespace LibrarianClient.DTO
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public string IssueDate { get; set; }
        public string ReturnDate { get; set; }
        public string BookName { get; set; }
        public string BookPublisher { get; set; }
        public string BookYear { get; set; }

        public IEnumerable<AuthorDTO> BookAuthors { get; set; } = new List<AuthorDTO>();
    }
}