using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms {
    abstract class SortingAlgorithm {

        private long deltaTime = 0;
        protected int iterationCount = 0;

        public void Sort(int[] ints) {
            iterationCount = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SortElements(ints);
            stopwatch.Stop();
            if(!IsSorted(ints)) {
                Console.WriteLine("Error! The algorithm failed to sort all the ints!");
            }
            deltaTime = stopwatch.ElapsedMilliseconds;
        }

        private bool IsSorted(int[] ints) {
            for(int i = 0; i < ints.Length - 1 ; i++) {
                if (ints[i] > ints[i + 1])
                    return false;
            }
            return true;
        }

        //in ms
        public long GetElapsedTime() {
            return deltaTime;
        }

        public int GetIterationCount() {
            return iterationCount;
        }

        protected abstract void SortElements(int[] ints);
        //Czy algorytm wykonuje sie w miejscu
        public abstract bool IsInPlace();
        public abstract string GetName();

        protected void IterationTick() {
            iterationCount++;
        }

        protected void SwapElements(int[] ints, int index1, int index2) {
            int temp = ints[index2];
            ints[index2] = ints[index1];
            ints[index1] = temp;
        }
    }
}
