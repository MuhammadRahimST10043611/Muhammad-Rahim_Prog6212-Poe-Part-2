// Model representing a claim
public class Claim
{
    public int Id { get; set; } // Unique identifier for the claim
    public string LecturerName { get; set; } // Name of the lecturer submitting the claim
    public decimal HoursWorked { get; set; } // Number of hours worked by the lecturer
    public decimal HourlyRate { get; set; } // The hourly rate for the lecturer
    public string Notes { get; set; } // Any additional notes or comments about the claim
    public string Status { get; set; } = "Pending"; // Status of the claim, defaults to "Pending"
    public string SupportingDocumentName { get; set; } // Name of the supporting document file
    public DateTime SubmissionDate { get; set; } = DateTime.Now; // Date and time when the claim was submitted, defaults to current date/time
}
