namespace WebProject.Models
{
    public partial class TblCart
    {
        public string BookId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string OrderId { get; set; } = null!;

        public virtual TblBook Book { get; set; } = null!;
        public virtual TblCustomer Customer { get; set; } = null!;
        public virtual TblOrder Order { get; set; } = null!;
    }
}
