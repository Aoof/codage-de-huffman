using System.Text;

namespace codage_de_huffman
{
    /// <summary>
    /// Provides encoding and decoding functionality using Huffman coding.
    /// This class uses a pre-built Huffman tree to compress text by assigning
    /// shorter codes to more frequent characters and longer codes to less frequent ones.
    /// </summary>
    public class HuffmanCodec
    {
        private HuffmanNode root;
        private Dictionary<char, string> codeMap;

        /// <summary>
        /// Initializes a new HuffmanCodec with the given Huffman tree root.
        /// Builds the character-to-code mapping during construction.
        /// </summary>
        /// <param name="root">The root node of the Huffman tree.</param>
        public HuffmanCodec(HuffmanNode root)
        {
            this.root = root;
            codeMap = new Dictionary<char, string>();
            BuildCodes(root, "");
        }

        /// <summary>
        /// Recursively builds the Huffman code mapping by traversing the tree.
        /// Each left branch adds '0', each right branch adds '1' to the code.
        /// </summary>
        /// <param name="node">Current node being processed.</param>
        /// <param name="currentCode">The Huffman code built so far for this path.</param>
        private void BuildCodes(HuffmanNode node, string currentCode)
        {
            if (node.IsLeaf && node.Character.HasValue)
            {
                codeMap[node.Character.Value] = string.IsNullOrEmpty(currentCode) ? "0" : currentCode;
                return;
            }
            if (node.Left != null) BuildCodes(node.Left, currentCode + "0");
            if (node.Right != null) BuildCodes(node.Right, currentCode + "1");
        }

        /// <summary>
        /// Encodes a text string into a Huffman-coded bitstring.
        /// Each character in the input is replaced with its corresponding Huffman code.
        /// </summary>
        /// <param name="text">The text to encode.</param>
        /// <returns>A string of '0's and '1's representing the compressed data.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when a character in the text is not in the code map.</exception>
        public string Encode(string text)
        {
            var result = new StringBuilder();
            foreach (var c in text)
            {
                if (codeMap.ContainsKey(c))
                    result.Append(codeMap[c]);
                else
                    throw new KeyNotFoundException($"Character '{c}' not found in code map.");
            }
            return result.ToString();
        }

        /// <summary>
        /// Decodes a Huffman-coded bitstring back to the original text.
        /// Traverses the Huffman tree using the bitstring: '0' for left, '1' for right.
        /// When reaching a leaf node, appends the character and resets to root.
        /// </summary>
        /// <param name="bitstring">The Huffman-coded bitstring to decode.</param>
        /// <returns>The decoded text string.</returns>
        /// <exception cref="ArgumentException">Thrown when the bitstring contains invalid characters.</exception>
        public string Decode(string bitstring)
        {
            var result = new StringBuilder();
            var current = root;
            foreach (var bit in bitstring)
            {
                if (bit == '0')
                    current = current.Left;
                else if (bit == '1')
                    current = current.Right;
                else
                    throw new ArgumentException("Invalid bit in bitstring.");

                if (current!.IsLeaf)
                {
                    result.Append(current!.Character!.Value);
                    current = root;
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Returns a copy of the character-to-Huffman-code mapping.
        /// </summary>
        /// <returns>Dictionary mapping characters to their Huffman codes.</returns>
        public Dictionary<char, string> GetCodeMap() => new Dictionary<char, string>(codeMap);
    }
}