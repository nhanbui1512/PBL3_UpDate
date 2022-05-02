namespace webpbl3.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int Quyen { get; set; } = 3;

    }
}