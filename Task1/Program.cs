using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        private static int _mushroomsCount;
        private static int _eggCount;
        private static int _breadSlicesCount;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Init();
            var mushrooms = new Mushrooms();
            var breadSlices = new BreadSlices();
            var eggs = new Eggs();

            Task<Mushrooms> cutMushroomsTask = new Task<Mushrooms>(() => CutMushrooms(mushrooms));
            cutMushroomsTask.Start();
            Task<Mushrooms> fryMushroomsTaskResult = cutMushroomsTask
                .ContinueWith((Task<Mushrooms> cutMushroomsTaskResult) => FryMushrooms(cutMushroomsTaskResult.Result));

            Task<BreadSlices> fryBreadSlicesTask = new Task<BreadSlices>(() => FryBreadSlices(breadSlices));
            fryBreadSlicesTask.Start();
            Task<Eggs> fryEggsTaskResult = fryBreadSlicesTask
                .ContinueWith((Task<BreadSlices> fryBreadSlicesTaskResult) => FryEggs(eggs));


            Task.WaitAll(cutMushroomsTask, fryMushroomsTaskResult, fryBreadSlicesTask, fryEggsTaskResult);

            var breakfast = new Breakfast(fryMushroomsTaskResult.Result, fryBreadSlicesTask.Result, fryEggsTaskResult.Result);
            var isCompleteBreakfast = breakfast.IsComplete();

            Console.WriteLine($"Breakfast is DONE: {isCompleteBreakfast}");
            Console.ReadLine();
        }
        
        static void Init()
        {
            _mushroomsCount = 5;
            _eggCount = 2;
            _breadSlicesCount = 2;
        }

        static Mushrooms CutMushrooms(Mushrooms mushrooms)
        {
            int time = _mushroomsCount * 100000;

            Task.Delay(time);

            
            Console.WriteLine("Finished slicing mushrooms.");

            return new Mushrooms(isCutted: true, isFried: mushrooms.IsFried);
        }
        static Mushrooms FryMushrooms(Mushrooms mushrooms)
        {
            Task.Delay(1000);

            Console.WriteLine($"Finished frying mushrooms.");

            return new Mushrooms(isCutted: mushrooms.IsCutted, isFried: true);
        }

        static BreadSlices FryBreadSlices(BreadSlices breadSlices)
        {
            int time = _breadSlicesCount * 1000;
            Task.Delay(time);

            Console.WriteLine("Finished frying bread.");

            return new BreadSlices(isFried: true);
        }
        static Eggs FryEggs(Eggs eggs)
        {
            int time = _eggCount * 1000;
            Task.Delay(time);

            Console.WriteLine("Finished frying eggs.");

            return new Eggs(isFried: true);
        }
    }
    
}
