using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {

    public class List<T> {

        public List() {
        }

        private Node first;
        private Node last;

        public void Add(T e) {
            if (first == null) {
                first = new Node {
                    Element = e
                };
                last = first;
            } 
            else {
                /*Node n = first;
                while (n.Next != null) {
                    n = n.Next;
                }
                n.Next = new Node() {
                    Element = e
                };*/
                last.Next = new Node() {
                    Element = e
                };
                last = last.Next;
            }
        }

        public T ElementAt(int index) {
            Node n = first;
            for (int i = 0; i < index; i++) {
                n = n.Next;
            }
            return n.Element;
        }

        public int IndexOf(T e) {
            int i = 0;
            Node n = first;
            while(!n.Element.Equals(e)) {
                n = n.Next;
                i++;
            }
            return i;
        }

        private class Node {
            private Node next;
            private T element;

            public T Element { get => element; set => element = value; }
            public Node Next { get => next; set => next = value; }
        }
    }
}
