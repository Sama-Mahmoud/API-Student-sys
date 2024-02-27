using System.ComponentModel.DataAnnotations;

namespace API01.Validators
{
    public class DayInPastAttribute :ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            //return base.IsValid(value);

            DateTime ? date = value as DateTime?;

            if (date == null )
            {
                return false;
            }
            if ( date < DateTime.Now )
            {
                return true;
            }
            return false;
        }
    }
}
