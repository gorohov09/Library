﻿namespace Library.Application.Vm
{
    public class OrderDetailsForReaderVm
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public string Status { get; set; }
    }
}
