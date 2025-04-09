namespace Animals.Models
{
    internal class Nothing : BioEntity
    {
        public override bool CanEat(BioEntity candidate)
        {
            throw new NotImplementedException();
        }
    }
}
