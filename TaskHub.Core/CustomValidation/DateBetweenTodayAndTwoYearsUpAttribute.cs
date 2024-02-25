using System.ComponentModel.DataAnnotations;

namespace TaskHub.Core.CustomValidation
{
    public class DateBetweenTodayAndTwoYearsUpAttribute : RangeAttribute
    {
        public DateBetweenTodayAndTwoYearsUpAttribute() : base(typeof(DateTime), DateTime.Now.ToShortDateString(), DateTime.Now.AddYears(2).ToShortDateString()) { }
    }
}
