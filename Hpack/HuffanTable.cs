﻿using System;

namespace Hpack
{
    static class HuffmanTree
    {
        /** A node in the binary huffman tree */
        public class TreeNode
        {
            /// <summary> Tree branch that is taken when decoder encounters 0</summary>
            public TreeNode Child0;
            /// <summary> Tree branch that is taken when decoder encounters 1</summary>
            public TreeNode Child1;
            /// <summary>
            /// The value of the node. This is only set in leaf nodes.
            /// Might also be ushort, since the max value is 256.
            /// However currently -1 depicts that no value is set for the node.
            /// </summary>
            public int Value; // 
        }

        public static readonly TreeNode Root;

        static HuffmanTree()
        {
            // Create a tree structure out of the huffman table
            Root = new TreeNode
            {
                Child0 = null,
                Child1 = null,
                Value = -1,
            };

            var i = 0;
            foreach (var entry in HuffmanTable.Entries)
            {
                InsertIntoTree(Root, i, entry.Bin, entry.Len);
                i++;
            }
        }

        private static void InsertIntoTree(TreeNode tree, int value, int bin, int len)
        {
            // Check the leftmost bit of the tree
            var firstBit = bin >> (len - 1);
            var child = (firstBit == 1) ? tree.Child1 : tree.Child0;
            if (len == 1)
            {
                // Leaf node
                if (child != null) throw new Exception("TreeNode alreay occupied");
                child = new TreeNode { Child0 = null, Child1 = null, Value = value };
                if (firstBit == 1) tree.Child1 = child;
                else tree.Child0 = child;
            }
            else
            {
                // Remaining data of the tree
                // Reset the first bit
                var rem = bin & ((1 << (len - 1)) - 1);
                if (child == null)
                {
                    // Create a new branch if necessary
                    child = new TreeNode { Child0 = null, Child1 = null, Value = -1 };
                    if (firstBit == 1) tree.Child1 = child;
                    else tree.Child0 = child;
                }

                InsertIntoTree(child, value, rem, len-1);
            }
        }
    }

    static class HuffmanTable
    {
        /// <summary>
        /// An entry in the huffman table
        /// </summary>
        public struct Entry
        {
            public int Bin;
            public int Len;
        }

        /// <summary>
        /// Entries in the huffman table
        /// </summary>
        public static readonly Entry[] Entries =
        {
            new Entry { Bin = 0x1ff8, Len = 13},
            new Entry { Bin = 0x7fffd8, Len = 23 },
            new Entry { Bin = 0xfffffe2, Len = 28 },
            new Entry { Bin = 0xfffffe3, Len = 28 },
            new Entry { Bin = 0xfffffe4, Len = 28 },
            new Entry { Bin = 0xfffffe5, Len = 28 },
            new Entry { Bin = 0xfffffe6, Len = 28 },
            new Entry { Bin = 0xfffffe7, Len = 28 },
            new Entry { Bin = 0xfffffe8, Len = 28 },
            new Entry { Bin = 0xffffea, Len = 24 },
            new Entry { Bin = 0x3ffffffc, Len = 30 },
            new Entry { Bin = 0xfffffe9, Len = 28 },
            new Entry { Bin = 0xfffffea, Len = 28 },
            new Entry { Bin = 0x3ffffffd, Len = 30 },
            new Entry { Bin = 0xfffffeb, Len = 28 },
            new Entry { Bin = 0xfffffec, Len = 28 },
            new Entry { Bin = 0xfffffed, Len = 28 },
            new Entry { Bin = 0xfffffee, Len = 28 },
            new Entry { Bin = 0xfffffef, Len = 28 },
            new Entry { Bin = 0xffffff0, Len = 28 },
            new Entry { Bin = 0xffffff1, Len = 28 },
            new Entry { Bin = 0xffffff2, Len = 28 },
            new Entry { Bin = 0x3ffffffe, Len = 30 },
            new Entry { Bin = 0xffffff3, Len = 28 },
            new Entry { Bin = 0xffffff4, Len = 28 },
            new Entry { Bin = 0xffffff5, Len = 28 },
            new Entry { Bin = 0xffffff6, Len = 28 },
            new Entry { Bin = 0xffffff7, Len = 28 },
            new Entry { Bin = 0xffffff8, Len = 28 },
            new Entry { Bin = 0xffffff9, Len = 28 },
            new Entry { Bin = 0xffffffa, Len = 28 },
            new Entry { Bin = 0xffffffb, Len = 28 },
            new Entry { Bin = 0x14, Len =  6 },
            new Entry { Bin = 0x3f8, Len = 10 },
            new Entry { Bin = 0x3f9, Len = 10 },
            new Entry { Bin = 0xffa, Len = 12 },
            new Entry { Bin = 0x1ff9, Len = 13 },
            new Entry { Bin = 0x15, Len =  6 },
            new Entry { Bin = 0xf8, Len =  8 },
            new Entry { Bin = 0x7fa, Len = 11 },
            new Entry { Bin = 0x3fa, Len = 10 },
            new Entry { Bin = 0x3fb, Len = 10 },
            new Entry { Bin = 0xf9, Len =  8 },
            new Entry { Bin = 0x7fb, Len = 11 },
            new Entry { Bin = 0xfa, Len =  8 },
            new Entry { Bin = 0x16, Len =  6 },
            new Entry { Bin = 0x17, Len =  6 },
            new Entry { Bin = 0x18, Len =  6 },
            new Entry { Bin = 0x0, Len =  5 },
            new Entry { Bin = 0x1, Len =  5 },
            new Entry { Bin = 0x2, Len =  5 },
            new Entry { Bin = 0x19, Len =  6 },
            new Entry { Bin = 0x1a, Len =  6 },
            new Entry { Bin = 0x1b, Len =  6 },
            new Entry { Bin = 0x1c, Len =  6 },
            new Entry { Bin = 0x1d, Len =  6 },
            new Entry { Bin = 0x1e, Len =  6 },
            new Entry { Bin = 0x1f, Len =  6 },
            new Entry { Bin = 0x5c, Len =  7 },
            new Entry { Bin = 0xfb, Len =  8 },
            new Entry { Bin = 0x7ffc, Len = 15 },
            new Entry { Bin = 0x20, Len =  6 },
            new Entry { Bin = 0xffb, Len = 12 },
            new Entry { Bin = 0x3fc, Len = 10 },
            new Entry { Bin = 0x1ffa, Len = 13 },
            new Entry { Bin = 0x21, Len =  6 },
            new Entry { Bin = 0x5d, Len =  7 },
            new Entry { Bin = 0x5e, Len =  7 },
            new Entry { Bin = 0x5f, Len =  7 },
            new Entry { Bin = 0x60, Len =  7 },
            new Entry { Bin = 0x61, Len =  7 },
            new Entry { Bin = 0x62, Len =  7 },
            new Entry { Bin = 0x63, Len =  7 },
            new Entry { Bin = 0x64, Len =  7 },
            new Entry { Bin = 0x65, Len =  7 },
            new Entry { Bin = 0x66, Len =  7 },
            new Entry { Bin = 0x67, Len =  7 },
            new Entry { Bin = 0x68, Len =  7 },
            new Entry { Bin = 0x69, Len =  7 },
            new Entry { Bin = 0x6a, Len =  7 },
            new Entry { Bin = 0x6b, Len =  7 },
            new Entry { Bin = 0x6c, Len =  7 },
            new Entry { Bin = 0x6d, Len =  7 },
            new Entry { Bin = 0x6e, Len =  7 },
            new Entry { Bin = 0x6f, Len =  7 },
            new Entry { Bin = 0x70, Len =  7 },
            new Entry { Bin = 0x71, Len =  7 },
            new Entry { Bin = 0x72, Len =  7 },
            new Entry { Bin = 0xfc, Len =  8 },
            new Entry { Bin = 0x73, Len =  7 },
            new Entry { Bin = 0xfd, Len =  8 },
            new Entry { Bin = 0x1ffb, Len = 13 },
            new Entry { Bin = 0x7fff0, Len = 19 },
            new Entry { Bin = 0x1ffc, Len = 13 },
            new Entry { Bin = 0x3ffc, Len = 14 },
            new Entry { Bin = 0x22, Len =  6 },
            new Entry { Bin = 0x7ffd, Len = 15 },
            new Entry { Bin = 0x3, Len =  5 },
            new Entry { Bin = 0x23, Len =  6 },
            new Entry { Bin = 0x4, Len =  5 },
            new Entry { Bin = 0x24, Len =  6 },
            new Entry { Bin = 0x5, Len =  5 },
            new Entry { Bin = 0x25, Len =  6 },
            new Entry { Bin = 0x26, Len =  6 },
            new Entry { Bin = 0x27, Len =  6 },
            new Entry { Bin = 0x6, Len =  5 },
            new Entry { Bin = 0x74, Len =  7 },
            new Entry { Bin = 0x75, Len =  7 },
            new Entry { Bin = 0x28, Len =  6 },
            new Entry { Bin = 0x29, Len =  6 },
            new Entry { Bin = 0x2a, Len =  6 },
            new Entry { Bin = 0x7, Len =  5 },
            new Entry { Bin = 0x2b, Len =  6 },
            new Entry { Bin = 0x76, Len =  7 },
            new Entry { Bin = 0x2c, Len =  6 },
            new Entry { Bin = 0x8, Len =  5 },
            new Entry { Bin = 0x9, Len =  5 },
            new Entry { Bin = 0x2d, Len =  6 },
            new Entry { Bin = 0x77, Len =  7 },
            new Entry { Bin = 0x78, Len =  7 },
            new Entry { Bin = 0x79, Len =  7 },
            new Entry { Bin = 0x7a, Len =  7 },
            new Entry { Bin = 0x7b, Len =  7 },
            new Entry { Bin = 0x7ffe, Len = 15 },
            new Entry { Bin = 0x7fc, Len = 11 },
            new Entry { Bin = 0x3ffd, Len = 14 },
            new Entry { Bin = 0x1ffd, Len = 13 },
            new Entry { Bin = 0xffffffc, Len = 28 },
            new Entry { Bin = 0xfffe6, Len = 20 },
            new Entry { Bin = 0x3fffd2, Len = 22 },
            new Entry { Bin = 0xfffe7, Len = 20 },
            new Entry { Bin = 0xfffe8, Len = 20 },
            new Entry { Bin = 0x3fffd3, Len = 22 },
            new Entry { Bin = 0x3fffd4, Len = 22 },
            new Entry { Bin = 0x3fffd5, Len = 22 },
            new Entry { Bin = 0x7fffd9, Len = 23 },
            new Entry { Bin = 0x3fffd6, Len = 22 },
            new Entry { Bin = 0x7fffda, Len = 23 },
            new Entry { Bin = 0x7fffdb, Len = 23 },
            new Entry { Bin = 0x7fffdc, Len = 23 },
            new Entry { Bin = 0x7fffdd, Len = 23 },
            new Entry { Bin = 0x7fffde, Len = 23 },
            new Entry { Bin = 0xffffeb, Len = 24 },
            new Entry { Bin = 0x7fffdf, Len = 23 },
            new Entry { Bin = 0xffffec, Len = 24 },
            new Entry { Bin = 0xffffed, Len = 24 },
            new Entry { Bin = 0x3fffd7, Len = 22 },
            new Entry { Bin = 0x7fffe0, Len = 23 },
            new Entry { Bin = 0xffffee, Len = 24 },
            new Entry { Bin = 0x7fffe1, Len = 23 },
            new Entry { Bin = 0x7fffe2, Len = 23 },
            new Entry { Bin = 0x7fffe3, Len = 23 },
            new Entry { Bin = 0x7fffe4, Len = 23 },
            new Entry { Bin = 0x1fffdc, Len = 21 },
            new Entry { Bin = 0x3fffd8, Len = 22 },
            new Entry { Bin = 0x7fffe5, Len = 23 },
            new Entry { Bin = 0x3fffd9, Len = 22 },
            new Entry { Bin = 0x7fffe6, Len = 23 },
            new Entry { Bin = 0x7fffe7, Len = 23 },
            new Entry { Bin = 0xffffef, Len = 24 },
            new Entry { Bin = 0x3fffda, Len = 22 },
            new Entry { Bin = 0x1fffdd, Len = 21 },
            new Entry { Bin = 0xfffe9, Len = 20 },
            new Entry { Bin = 0x3fffdb, Len = 22 },
            new Entry { Bin = 0x3fffdc, Len = 22 },
            new Entry { Bin = 0x7fffe8, Len = 23 },
            new Entry { Bin = 0x7fffe9, Len = 23 },
            new Entry { Bin = 0x1fffde, Len = 21 },
            new Entry { Bin = 0x7fffea, Len = 23 },
            new Entry { Bin = 0x3fffdd, Len = 22 },
            new Entry { Bin = 0x3fffde, Len = 22 },
            new Entry { Bin = 0xfffff0, Len = 24 },
            new Entry { Bin = 0x1fffdf, Len = 21 },
            new Entry { Bin = 0x3fffdf, Len = 22 },
            new Entry { Bin = 0x7fffeb, Len = 23 },
            new Entry { Bin = 0x7fffec, Len = 23 },
            new Entry { Bin = 0x1fffe0, Len = 21 },
            new Entry { Bin = 0x1fffe1, Len = 21 },
            new Entry { Bin = 0x3fffe0, Len = 22 },
            new Entry { Bin = 0x1fffe2, Len = 21 },
            new Entry { Bin = 0x7fffed, Len = 23 },
            new Entry { Bin = 0x3fffe1, Len = 22 },
            new Entry { Bin = 0x7fffee, Len = 23 },
            new Entry { Bin = 0x7fffef, Len = 23 },
            new Entry { Bin = 0xfffea, Len = 20 },
            new Entry { Bin = 0x3fffe2, Len = 22 },
            new Entry { Bin = 0x3fffe3, Len = 22 },
            new Entry { Bin = 0x3fffe4, Len = 22 },
            new Entry { Bin = 0x7ffff0, Len = 23 },
            new Entry { Bin = 0x3fffe5, Len = 22 },
            new Entry { Bin = 0x3fffe6, Len = 22 },
            new Entry { Bin = 0x7ffff1, Len = 23 },
            new Entry { Bin = 0x3ffffe0, Len = 26 },
            new Entry { Bin = 0x3ffffe1, Len = 26 },
            new Entry { Bin = 0xfffeb, Len = 20 },
            new Entry { Bin = 0x7fff1, Len = 19 },
            new Entry { Bin = 0x3fffe7, Len = 22 },
            new Entry { Bin = 0x7ffff2, Len = 23 },
            new Entry { Bin = 0x3fffe8, Len = 22 },
            new Entry { Bin = 0x1ffffec, Len = 25 },
            new Entry { Bin = 0x3ffffe2, Len = 26 },
            new Entry { Bin = 0x3ffffe3, Len = 26 },
            new Entry { Bin = 0x3ffffe4, Len = 26 },
            new Entry { Bin = 0x7ffffde, Len = 27 },
            new Entry { Bin = 0x7ffffdf, Len = 27 },
            new Entry { Bin = 0x3ffffe5, Len = 26 },
            new Entry { Bin = 0xfffff1, Len = 24 },
            new Entry { Bin = 0x1ffffed, Len = 25 },
            new Entry { Bin = 0x7fff2, Len = 19 },
            new Entry { Bin = 0x1fffe3, Len = 21 },
            new Entry { Bin = 0x3ffffe6, Len = 26 },
            new Entry { Bin = 0x7ffffe0, Len = 27 },
            new Entry { Bin = 0x7ffffe1, Len = 27 },
            new Entry { Bin = 0x3ffffe7, Len = 26 },
            new Entry { Bin = 0x7ffffe2, Len = 27 },
            new Entry { Bin = 0xfffff2, Len = 24 },
            new Entry { Bin = 0x1fffe4, Len = 21 },
            new Entry { Bin = 0x1fffe5, Len = 21 },
            new Entry { Bin = 0x3ffffe8, Len = 26 },
            new Entry { Bin = 0x3ffffe9, Len = 26 },
            new Entry { Bin = 0xffffffd, Len = 28 },
            new Entry { Bin = 0x7ffffe3, Len = 27 },
            new Entry { Bin = 0x7ffffe4, Len = 27 },
            new Entry { Bin = 0x7ffffe5, Len = 27 },
            new Entry { Bin = 0xfffec, Len = 20 },
            new Entry { Bin = 0xfffff3, Len = 24 },
            new Entry { Bin = 0xfffed, Len = 20 },
            new Entry { Bin = 0x1fffe6, Len = 21 },
            new Entry { Bin = 0x3fffe9, Len = 22 },
            new Entry { Bin = 0x1fffe7, Len = 21 },
            new Entry { Bin = 0x1fffe8, Len = 21 },
            new Entry { Bin = 0x7ffff3, Len = 23 },
            new Entry { Bin = 0x3fffea, Len = 22 },
            new Entry { Bin = 0x3fffeb, Len = 22 },
            new Entry { Bin = 0x1ffffee, Len = 25 },
            new Entry { Bin = 0x1ffffef, Len = 25 },
            new Entry { Bin = 0xfffff4, Len = 24 },
            new Entry { Bin = 0xfffff5, Len = 24 },
            new Entry { Bin = 0x3ffffea, Len = 26 },
            new Entry { Bin = 0x7ffff4, Len = 23 },
            new Entry { Bin = 0x3ffffeb, Len = 26 },
            new Entry { Bin = 0x7ffffe6, Len = 27 },
            new Entry { Bin = 0x3ffffec, Len = 26 },
            new Entry { Bin = 0x3ffffed, Len = 26 },
            new Entry { Bin = 0x7ffffe7, Len = 27 },
            new Entry { Bin = 0x7ffffe8, Len = 27 },
            new Entry { Bin = 0x7ffffe9, Len = 27 },
            new Entry { Bin = 0x7ffffea, Len = 27 },
            new Entry { Bin = 0x7ffffeb, Len = 27 },
            new Entry { Bin = 0xffffffe, Len = 28 },
            new Entry { Bin = 0x7ffffec, Len = 27 },
            new Entry { Bin = 0x7ffffed, Len = 27 },
            new Entry { Bin = 0x7ffffee, Len = 27 },
            new Entry { Bin = 0x7ffffef, Len = 27 },
            new Entry { Bin = 0x7fffff0, Len = 27 },
            new Entry { Bin = 0x3ffffee, Len = 26 },
            new Entry { Bin = 0x3fffffff, Len = 30 },
        };
    }
}
