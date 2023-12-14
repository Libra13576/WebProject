namespace WebProject.Models
{
    public partial class Tbladmin
    {
        public string AdminId { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
        public string Adminname { get; set; } = null!;
        public string Adminpassword { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public int CatId { get; set; }
        public string? Adminphoto { get; set; }
    }
}
