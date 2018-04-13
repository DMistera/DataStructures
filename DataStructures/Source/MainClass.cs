using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DataStructures {
    class MainClass {
        public static void Main(string[] args) {
            Program p = new Program();
            Thread t = new Thread(p.Start, 100000);
            t.Start();
        }
    }
}
