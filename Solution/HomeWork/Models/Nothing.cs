﻿namespace HomeWork.Models
{
    internal class Nothing : BioEntity
    {
        public override string ImageSourceFile => string.Empty;

        public override bool CanEat(BioEntity candidate)
        {
            throw new NotImplementedException();
        }
    }
}
