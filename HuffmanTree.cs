namespace codage_de_huffman
{
    /// <summary>
    /// Represents a node in the Huffman tree used for compression.
    /// Each node contains a character (for leaf nodes), its frequency,
    /// and references to left and right child nodes.
    /// </summary>
    public class HuffmanNode
    {
        /// <summary>
        /// The character this node represents. Null for internal nodes.
        /// </summary>
        public char? Character { get; set; }

        /// <summary>
        /// The frequency of the character in the input text.
        /// For internal nodes, this is the sum of child frequencies.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Left child node (represents '0' bit in Huffman code).
        /// </summary>
        public HuffmanNode? Left { get; set; }

        /// <summary>
        /// Right child node (represents '1' bit in Huffman code).
        /// </summary>
        public HuffmanNode? Right { get; set; }

        /// <summary>
        /// Indicates whether this is a leaf node (has no children).
        /// </summary>
        public bool IsLeaf => Left == null && Right == null;
    }

    /// <summary>
    /// Static utility class for building Huffman trees.
    /// Uses a priority queue to construct the optimal binary tree
    /// based on character frequencies.
    /// </summary>
    public static class HuffmanTree
    {
        /// <summary>
        /// Builds a Huffman tree from character frequency data.
        /// The algorithm repeatedly combines the two nodes with lowest
        /// frequencies until only one root node remains.
        /// </summary>
        /// <param name="frequencies">Dictionary mapping characters to their frequencies.</param>
        /// <returns>The root node of the constructed Huffman tree.</returns>
        public static HuffmanNode BuildTree(Dictionary<char, int> frequencies)
        {
            var pq = new PriorityQueue<HuffmanNode, int>();
            foreach (var kvp in frequencies)
            {
                pq.Enqueue(new HuffmanNode { Character = kvp.Key, Frequency = kvp.Value }, kvp.Value);
            }

            while (pq.Count > 1)
            {
                var left = pq.Dequeue();
                var right = pq.Dequeue();
                var parent = new HuffmanNode
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };
                pq.Enqueue(parent, parent.Frequency);
            }

            return pq.Dequeue();
        }
    }
}