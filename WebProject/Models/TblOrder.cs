namespace WebProject.Models
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblCarts = new HashSet<TblCart>();
        }

        public string OrderId { get; set; } = null!;
        public string BookId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string CartId { get; set; } = null!;
        public int Price { get; set; }

        public virtual TblCustomer Customer { get; set; } = null!;
        public virtual ICollection<TblCart> TblCarts { get; set; }
    }
}
