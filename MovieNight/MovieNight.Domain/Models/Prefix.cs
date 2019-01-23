using MovieNight.Domain.Abstracts;

namespace MovieNight.Domain.Models
{
    public class Prefix:AThing
    {
        public string Name { get; set; }

        public override bool IsValid()
        {
            return Validator.ValidateString(this);
        }
    }
}