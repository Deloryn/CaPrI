namespace Capri.Services.Settings
{
    public class SieveSettings
    {
        public bool CaseSensitive { get; set; }
        public int DefaultPageSize { get; set; }
        public int MaxPageSize { get; set; }
        public bool ThrowExceptions { get; set; }
    }
}