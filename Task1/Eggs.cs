using System;
namespace Task1
{
    public class Eggs : ICompletable
    {
        public bool IsFried { get; }

        public Eggs(bool isFried = false)
        {
            IsFried = isFried;
        }

        public bool IsComplete()
        {
            return IsFried;
        }
    }
}
