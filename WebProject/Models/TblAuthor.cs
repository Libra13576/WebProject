namespace WebProject.Models
{
    public partial class TblAuthor
    {
        public TblAuthor()
        {
            TblBookAuthors = new HashSet<TblBookAuthor>();
        }

        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public string? AuthorAdress { get; set; }
        public string? AuthorEmail { get; set; }

        public virtual ICollection<TblBookAuthor> TblBookAuthors { get; set; }
    }
}
