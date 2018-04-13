using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphics;
using System.Diagnostics;

namespace DataStructures {
    public class Program {
        public void Start() {

            const int measures = 20;

            Graph.Data cb = new Graph.Data("Array B");
            Graph.Data cl = new Graph.Data("List L");
            Graph.Data ctr = new Graph.Data("Tree TR");
            Graph.Data ctb = new Graph.Data("Tree TB");
            Graph.Data sb = new Graph.Data("Array B");
            Graph.Data sbb = new Graph.Data("Array B (dividing by half)");
            Graph.Data sl = new Graph.Data("List L");
            Graph.Data str = new Graph.Data("Tree TR");
            Graph.Data stb = new Graph.Data("Tree TB");
            Graph.Data htr = new Graph.Data("Tree TR");
            Graph.Data htb = new Graph.Data("Tree TB");

            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < measures; i++) {

                int n = (i + 1) * 500;

                int[] a = GenerateArray(n);

                //Array B
                stopwatch.Start();
                int[] b = new int[n];
                for (int j = 0; j < n; j++) {
                    b[j] = a[j];
                }
                (new QuickSort()).Sort(b);
                stopwatch.Stop();
                cb.AddPoint(n, stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                for (int j = 0; j < n; j++) {
                    Find(b, a[j]);
                }
                stopwatch.Stop();
                sb.AddPoint(n, stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                for (int j = 0; j < n; j++) {
                    FindByHalf(b, a[j]);
                }
                stopwatch.Stop();
                sbb.AddPoint(n, stopwatch.ElapsedMilliseconds);

                //List L
                stopwatch.Restart();
                List<int> l = new List<int>();
                for (int j = 0; j < n; j++) {
                    l.Add(a[j]);
                }
                stopwatch.Stop();
                cl.AddPoint(n, stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                for (int j = 0; j < n; j++) {
                    l.IndexOf(a[j]);
                }
                stopwatch.Stop();
                sl.AddPoint(n, stopwatch.ElapsedMilliseconds);

                //Tree TR
                stopwatch.Restart();
                BinarySearchTree<int, int> tr = new BinarySearchTree<int, int>();
                for (int j = 0; j < n; j++) {
                    tr.Add(a[j], a[j]);
                }
                stopwatch.Stop();
                ctr.AddPoint(n, stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                for (int j = 0; j < n; j++) {
                    tr.GetElement(a[j]);
                }
                stopwatch.Stop();
                str.AddPoint(n, stopwatch.ElapsedMilliseconds);
                htr.AddPoint(n, tr.GetHeight());

                //Tree TB
                stopwatch.Restart();
                BinarySearchTree<int, int> tb = new BinarySearchTree<int, int>();
                tb.FillWithSortedArray(b, b);
                stopwatch.Stop();
                ctb.AddPoint(n, stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                for (int j = 0; j < n; j++) {
                    tr.GetElement(a[j]);
                }
                stopwatch.Stop();
                stb.AddPoint(n, stopwatch.ElapsedMilliseconds);
                htb.AddPoint(n, tb.GetHeight());

                Console.WriteLine((i + 1) + "/" + measures + " completed.");
            }

            Graph creationGraph = new Graph("Creation Time", "Number of elements", "Time");
            creationGraph.AddData(cb);
            creationGraph.AddData(cl);
            creationGraph.AddData(ctr);
            creationGraph.AddData(ctb);
            creationGraph.StartWithNewThread();

            Graph searchGraph = new Graph("Search Time", "Number of elements", "Time");
            searchGraph.AddData(sb);
            searchGraph.AddData(sl);
            searchGraph.AddData(str);
            searchGraph.AddData(stb);
            searchGraph.StartWithNewThread();

            Graph heightGraph = new Graph("Height", "Number of elements", "Height");
            heightGraph.AddData(htr);
            heightGraph.AddData(htb);
            heightGraph.StartWithNewThread();
        }

        private int[] GenerateArray(int size) {
            Random r = new Random();
            int[] result = Enumerable.Range(1, size).OrderBy(x => r.Next()).Take(size).ToArray();
            return result;
        }

        private int Find(int[] array, int value) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == value)
                    return value;
            }
            throw new Exception("Value not found");
        }

        private int FindByHalf(int[] sortedArray, int value) {
            return FindByHalf(sortedArray, value, 0, sortedArray.Length - 1);
        }

        private int FindByHalf(int[] sortedArray, int value, int start, int end) {
            int middle = (start + end) / 2;
            if (sortedArray[middle] == value) {
                return middle;
            } else if (sortedArray[middle + 1] == value) {
                return middle + 1;
            } else {
                if (sortedArray[middle] < value) {
                    return FindByHalf(sortedArray, value, middle, end);
                } else {
                    return FindByHalf(sortedArray, value, start, middle);
                }
            }
        }
    }
}

