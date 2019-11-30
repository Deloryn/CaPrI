namespace Capri.Services.Settings
{
    public class JwtAuthorizationDetails
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpireDays { get; set; }
    }
}
