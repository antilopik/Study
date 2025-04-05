namespace Animals.Models
{
    internal class Wolf : BioEntity
    {
        public override bool CanEat(BioEntity candidate)
        {
            return candidate is Sheep;
        }

        public override string ToString()
        {
            return "Wolf";
        }
    }
}
