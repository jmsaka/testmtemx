class Triangulo
{
    public static void Main(string[] args)
    {
        int[][] triangulo = [
            [6],
            [3, 5],
            [9, 7, 1],
            [4, 6, 8, 4]
        ];

        Console.WriteLine("Triângulo original:");
        ExibirTriangulo(triangulo);

        Console.WriteLine("\nInforme um número existente no triângulo para iniciar a busca da soma máxima:");
        int numeroBuscado = int.Parse(Console.ReadLine());

        (int linha, int coluna) = EncontrarNumero(triangulo, numeroBuscado);

        if (linha == -1)
        {
            Console.WriteLine($"\nO número {numeroBuscado} não foi encontrado no triângulo.");
        }
        else
        {
            int somaMaxima = EncontrarSomaMaxima(triangulo, linha, coluna);
            Console.WriteLine($"\nA soma máxima a partir de {numeroBuscado} é: {somaMaxima}");
        }
    }

    public static void ExibirTriangulo(int[][] triangulo)
    {
        foreach (var linha in triangulo)
        {
            Console.WriteLine(string.Join(" ", linha));
        }
    }

    public static (int, int) EncontrarNumero(int[][] triangulo, int numero)
    {
        for (int i = 0; i < triangulo.Length; i++)
        {
            for (int j = 0; j < triangulo[i].Length; j++)
            {
                if (triangulo[i][j] == numero)
                {
                    return (i, j); 
                }
            }
        }
        return (-1, -1); 
    }

    public static int EncontrarSomaMaxima(int[][] triangulo, int linhaInicial, int colunaInicial)
    {
        int[][] somaTriangulo = new int[triangulo.Length][];
        for (int i = 0; i < triangulo.Length; i++)
        {
            somaTriangulo[i] = (int[])triangulo[i].Clone();
        }

        for (int i = somaTriangulo.Length - 2; i >= linhaInicial; i--)
        {
            for (int j = 0; j < somaTriangulo[i].Length; j++)
            {
                somaTriangulo[i][j] += Math.Max(somaTriangulo[i + 1][j], somaTriangulo[i + 1][j + 1]);
            }
        }

        return somaTriangulo[linhaInicial][colunaInicial];
    }
}
