﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianClient.DTO
{
    internal class ResponseLoginDTO
    {
        public bool IsSuccess { get; set; }

        public string Error { get; set; }

        public int Id { get; set; }
    }
}
