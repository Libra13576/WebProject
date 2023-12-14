namespace WebProject.Models
{
    public partial class TblStoreOwner
    {
        public TblStoreOwner()
        {
            TblBooks = new HashSet<TblBook>();
        }

        public string OwnerId { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public string OwnerAddress { get; set; } = null!;
        public string? OwnerPhone { get; set; }
        public string? OwnerTaxCode { get; set; }
        public string? OwnerDetails { get; set; }
        public string? Ownerphoto { get; set; }
        public string? OwnerPassword { get; set; }

        public virtual ICollection<TblBook> TblBooks { get; set; }
    }
}
