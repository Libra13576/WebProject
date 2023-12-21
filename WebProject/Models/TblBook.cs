using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public partial class TblBook
    {
        public TblBook()
        {
            TblBookAuthors = new HashSet<TblBookAuthor>();
            TblCarts = new HashSet<TblCart>();
        }

        [DisplayName("Book ID")]
        public string BookId { get; set; } = null!;
        [DisplayName("Book Title")]
        public string BookTitle { get; set; } = null!;
        [DisplayName("Book Price")]
        public int BookPrice { get; set; }
        [DisplayName("Book Details")]
        public string? BookDetailes { get; set; }
        [Display(Name ="Image URL")]
        public string? BookImage1 { get; set; }
        [DisplayName("Category")]
        public int CatId { get; set; }
        [DisplayName("Owner Id")]
        public string OwnerId { get; set; } = null!;
        [DisplayName("Publisher")]
        public int PublisherId { get; set; }

        public virtual TblCategory Cat { get; set; } = null!;
        public virtual TblStoreOwner Owner { get; set; } = null!;
        public virtual TblPublisher Publisher { get; set; } = null!;
        public virtual ICollection<TblBookAuthor> TblBookAuthors { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
    }
}
