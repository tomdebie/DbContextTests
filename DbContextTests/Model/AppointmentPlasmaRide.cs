namespace DbContextTests.Model;

public class AppointmentPlasmaRide : Appointment
{
    public TimeOnly DepartureTime { get; set; }
}