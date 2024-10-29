using Microsoft.EntityFrameworkCore;

namespace DbContextTests.Model;

[Owned]
public class AppointmentUtm
{
    public int AppointmentId { get; set; }

    public string? Source { get; set; }

    public string? Medium { get; set; }

    public string? Campaign { get; set; }
}
