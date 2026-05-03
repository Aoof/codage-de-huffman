# Huffman Coding in C#

A simple console application that implements Huffman coding for text compression.

## Usage

Run the program and enter a message when prompted. It will:
- Compute character frequencies
- Build a Huffman tree
- Generate Huffman codes
- Encode the message to a bitstring
- Decode back to the original text

Example input: `HAPPY MIND HAPPY LIFE`

## Requirements

- .NET 8.0

## Build and Run

```bash
dotnet build
dotnet run
```

## Requirements Mapping

This implementation fulfills all assignment requirements:

- **Développée en C# (Console)** : Application console utilisant .NET 8.0.
- **Au moins 2 structures de données** : HuffmanNode (arbre), PriorityQueue, Dictionary<char, int>, Dictionary<char, string>.
- **Opérations pertinentes** : Insertion (fréquences), recherche (codes Huffman), tri (affichage ordonné), encodage/décodage.
- **Gestion des entrées utilisateur et affichage** : Console.ReadLine pour input, affichage clair des résultats (fréquences, codes, bitstring).
- **Justification des structures** : Voir presentation pour détails et complexité temporelle (O(n log n) construction, O(m) encodage).
- **Qualité du code POO** : Classes séparées (HuffmanNode, HuffmanTree, HuffmanCodec), encapsulation, modularité, commentaires XML.
- **Démonstration** : Code prêt pour explication ligne par ligne et modifications en direct (ajout de fonctionnalités comme taux de compression).