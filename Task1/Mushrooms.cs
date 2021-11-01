using System;
namespace Task1
{
    public class Mushrooms : ICompletable
    {
        public bool IsCutted { get; }

        public bool IsFried { get; }

        public Mushrooms(bool isCutted = false, bool isFried = false)
        {
            IsCutted = isCutted;
            IsFried = isFried;
        }

        public bool IsComplete()
        {
            return IsCutted && IsFried;
        }
    }
}
