﻿namespace HomeWork.Models
{
    internal abstract class BioEntity
    {
        public abstract bool CanEat(BioEntity candidate);

        public abstract string ImageSourceFile { get; }
    }
}
