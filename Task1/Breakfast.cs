using System;
namespace Task1
{
    public class Breakfast : ICompletable
    {
        public Mushrooms mushrooms { get; }
        public BreadSlices breadSlices { get; }
        public Eggs eggs { get; }

        public Breakfast(Mushrooms mushrooms, BreadSlices breadSlices, Eggs eggs)
        {
            if (mushrooms == null || breadSlices == null || eggs == null)
                throw new ArgumentNullException();

            this.mushrooms = mushrooms;
            this.breadSlices = breadSlices;
            this.eggs = eggs;
        }

        public bool IsComplete()
        {
            return mushrooms.IsComplete() && breadSlices.IsComplete() && eggs.IsComplete();
        }
    }
}
