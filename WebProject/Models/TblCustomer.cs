using System.ComponentModel.DataAnnotations;

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

        [Display (Name="Email ")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; } = null!;
        [Display(Name = "Password ")]
        [DataType (DataType.Password)]
        public string CustomerPassword { get; set; } = null!;
        [Display(Name = "Name ")]
        public string CustomerFullname { get; set; } = null!;
        [Display(Name = "Address ")]
        public string? CustomerAddress { get; set; }
        [Display(Name = "Phone ")]
        public string? CustomerPhone { get; set; }
        
        public string? Customerphoto { get; set; }

        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
