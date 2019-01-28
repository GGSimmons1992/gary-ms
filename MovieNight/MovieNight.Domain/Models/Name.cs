using MovieNight.Domain.Abstracts;

namespace MovieNight.Domain.Models
{
    public class Name: AThing
    {
        public Prefix Prefix { get; set; }
        public string Last { get; set; }
        public string First { get; set; }

        public override bool IsValid()
        {
            return Validator.ValidateString(this) && Prefix.IsValid();
        }
    }
}