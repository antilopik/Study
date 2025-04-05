namespace Animals.Models
{
    internal class Sheep : BioEntity
    {
        public override bool CanEat(BioEntity candidate)
        {
            return candidate.GetType() == typeof(Cabbage);
        }

        public override string ToString()
        {
            return "Sheep";
        }
    }
}
