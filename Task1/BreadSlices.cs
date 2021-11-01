using System;
namespace Task1
{
    public class BreadSlices : ICompletable
    {
        public bool IsFried { get; }

        public BreadSlices (bool isFried = false)
        {
            IsFried = isFried;
        }

        public bool IsComplete()
        {
            return IsFried;
        }
    }
}
