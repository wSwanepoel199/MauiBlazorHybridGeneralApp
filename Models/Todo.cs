using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorHybrid.Models
{
    [Table("todo-list")]
    public class Todo
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [MaxLength(250)]
        public string? Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public bool IsHidden { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}

