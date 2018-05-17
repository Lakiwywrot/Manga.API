using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Manga.DATA.Entities
{
    public class Page
    {
        [Key]
        public Guid Id { get; set; }
        public string Photo { get; set; }
        public Chapter Chapter { get; set; }

        [ForeignKey("Chapter")]
        public Guid ChapterId { get; set; }
    }
}
