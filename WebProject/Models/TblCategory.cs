namespace WebProject.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblBooks = new HashSet<TblBook>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; } = null!;
        public string? CatDetails { get; set; }

        public virtual ICollection<TblBook> TblBooks { get; set; }
    }
}
