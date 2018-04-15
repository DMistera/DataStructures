using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    public class BinarySearchTree<TValue, TKey>
        where TKey : System.IComparable<TKey> {

        private Node root;

        public BinarySearchTree() {
        }

        public void Add(TValue value, TKey key) {
            if (root == null) {
                root = new Node {
                    Value = value,
                    Key = key
                };
            } else {
                Add(root, value, key);
                int g;
            }
        }

        private void Add(Node n, TValue value, TKey key) {
            if (n.Key.CompareTo(key) < 0) {
                if (n.Rigth == null) {
                    n.Rigth = new Node {
                        Value = value,
                        Key = key
                    };
                } else {
                    Add(n.Rigth, value, key);
                }
            } else {
                if (n.Left == null) {
                    n.Left = new Node {
                        Value = value,
                        Key = key
                    };
                } else {
                    Add(n.Left, value, key);
                }
            }
        }

        public TValue GetElement(TKey key) {
            return GetElement(root, key);
        }

        private TValue GetElement(Node n, TKey key) {
            if (n.Key.Equals(key)) {
                return n.Value;
            } else {
                Node next = n.Key.CompareTo(key) < 0 ? n.Rigth : n.Left;
                return GetElement(next, key);
            }
        }

        public int GetHeight() {
            if (root == null) {
                return 0;
            } else {
                int a;
                int b;
                return (a = GetHeight(root.Left) + 1) > (b = GetHeight(root.Rigth) + 1) ? a : b;
            }
        }

        private int GetHeight(Node n) {
            if(n == null) {
                return 0;
            }
            else {
                int a;
                int b;
                return (a = GetHeight(n.Left) + 1) > (b = GetHeight(n.Rigth) + 1) ? a : b;
            }
        }

        private class Node {
            private Node left;
            private Node rigth;
            private TValue value;
            private TKey key;
            public TValue Value { get => value; set => this.value = value; }
            public Node Left { get => left; set => left = value; }
            public Node Rigth { get => rigth; set => rigth = value; }
            public TKey Key { get => key; set => key = value; }
        }
    }
}
