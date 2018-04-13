using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Algorithms {
    class QuickSort : SortingAlgorithm
    {

        public override string GetName() {
            return "Quick Sort [Middle]";
        }

        public override bool IsInPlace() {
            return true;
        }

        void QS(int[] elements, int s, int e) {
            int p, l, r;
            l = s - 1;
            r = e + 1;
            p = elements[(l + r) / 2];
            while (true) {
                while (elements[++l] < p) IterationTick();
                while ((--r >= l) && (elements[r] > p)) IterationTick();
                if (l <= r) SwapElements(elements, l, r);
                else break;
            }

            if (l < e) QS(elements, l, e);
            if (s < r) QS(elements, s, r);
        }


        protected override void SortElements(int[] elements) {
            int start = 0;
            int end = elements.Length - 1;
            QS(elements, start, end);
        }
    }
 }

