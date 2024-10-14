namespace ProgPoe2.Models
{
    // Static repository class to store claims in-memory
    public static class ClaimRepository
    {
        // List of claims in the system
        public static List<Claim> Claims { get; set; } = new List<Claim>(); // Initializes an empty list of claims
    }
}
