using System.ComponentModel.DataAnnotations;

namespace Rooms_Booking.Validation
{
    public class CheckInDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date >= DateTime.Now.Date;
            }
            return false;
        }
    }
}
