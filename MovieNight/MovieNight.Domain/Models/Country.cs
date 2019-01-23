using MovieNight.Domain.Abstracts;

namespace MovieNight.Domain.Models
{
    public class Country: AThing
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public override bool IsValid()
        {
            return Validator.ValidateString(this);
        }
    }
    
}