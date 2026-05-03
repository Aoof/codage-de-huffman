using codage_de_huffman;

/// <summary>
/// Main program demonstrating Huffman coding compression.
/// This program takes user input, builds a frequency table of characters,
/// constructs a Huffman tree, generates Huffman codes, and demonstrates
/// encoding and decoding of the input message.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter message: ");
        string input = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("No input provided.");
            return;
        }

        // Build frequency table by counting occurrences of each character
        var frequencies = new Dictionary<char, int>();
        foreach (var c in input)
        {
            frequencies[c] = frequencies.GetValueOrDefault(c, 0) + 1;
        }

        Console.WriteLine("Frequency table:");
        foreach (var kvp in frequencies.OrderBy(k => k.Key))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        // Build Huffman tree and create codec
        var root = HuffmanTree.BuildTree(frequencies);
        var codec = new HuffmanCodec(root);

        Console.WriteLine("Huffman codes:");
        var codeMap = codec.GetCodeMap();
        foreach (var kvp in codeMap.OrderBy(k => k.Key))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        // Encode the input using Huffman codes
        string encoded = codec.Encode(input);
        Console.WriteLine($"Encoded bitstring: {encoded}");

        // Decode the bitstring back to original message
        string decoded = codec.Decode(encoded);
        Console.WriteLine($"Decoded message: {decoded}");

        // Verify that decoding was successful
        if (decoded == input)
        {
            Console.WriteLine("Decoding successful!");
        }
        else
        {
            Console.WriteLine("Decoding failed!");
        }
    }
}
