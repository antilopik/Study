namespace HomeWork.Models
{
    internal class Cabbage : BioEntity
    {
        public override bool CanEat(BioEntity candidate)
        {
            return false;
        }

        public override string ToString()
        {
            return "Cabbage";
        }
    }
}
