namespace DbContextTests.Model;

public class Appointment
{
    public int Id { get; set; }

    public DateTime AppointmentTime { get; set; }

    public AppointmentUtm? Utm { get; set; }
    
    //public AppointmentType Type { get; set; }
}
