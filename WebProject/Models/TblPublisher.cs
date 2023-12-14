namespace WebProject.Models
{
    public partial class TblPublisher
    {
        public TblPublisher()
        {
            TblBooks = new HashSet<TblBook>();
        }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;
        public string? PublisherAddress { get; set; }
        public string? PublisherDetails { get; set; }
        public string? Publogo { get; set; }

        public virtual ICollection<TblBook> TblBooks { get; set; }
    }
}
