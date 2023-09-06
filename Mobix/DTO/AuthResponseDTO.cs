namespace Mobix.DTO
{
    public class AuthResponseDTO
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string Role {  get; set; }
        public string KorisnikId { get; set; }
    }
}
