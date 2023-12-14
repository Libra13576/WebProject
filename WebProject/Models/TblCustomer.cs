namespace WebProject.Models
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblCarts = new HashSet<TblCart>();
            TblOrders = new HashSet<TblOrder>();
        }

        public string CustomerId { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPassword { get; set; } = null!;
        public string CustomerFullname { get; set; } = null!;
        public string? CustomerAddress { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Customerphoto { get; set; }

        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
