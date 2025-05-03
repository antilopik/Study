namespace HomeWork.Models
{
    internal class Sheep : BioEntity
    {
        public override string ImageSourceFile => "sheep.jfif";

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
