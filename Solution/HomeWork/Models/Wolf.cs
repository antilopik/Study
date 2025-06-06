﻿namespace HomeWork.Models
{
    internal class Wolf : BioEntity
    {
        public override bool CanEat(BioEntity candidate)
        {
            return candidate is Sheep;
        }

        public override string ImageSourceFile { get; } = "wolf.jfif";

        public override string ToString()
        {
            return "Wolf";
        }
    }
}
