

namespace DIYFilipinoDessert.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int DessertKitId { get; set; }
        public string Instruction { get; set; }
        public int StepNumber { get; set; }

        public DessertKit DessertKit { get; set; }

    }
}
