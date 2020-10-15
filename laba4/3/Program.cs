using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EVIL
{
    public int Row { get; private set; }
    public int Col { get; private set; }

    public void UpdateCoordinates(int row, int col)
    {
        Row = row;
        Col = col;
    }
}

public class IVO
{
    public int Row { get; private set; }
    public int Col { get; private set; }
    public long Score { get; private set; }

    public void UpdateCoordinates(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public void CollectPoints(int points)
    {
        Score += points;
    }
}

class Program
{
    static void Main(string[] args)
    {
        short[] sizes = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(short.Parse)
            .ToArray();

        var matrix = InitializeMatrix(sizes);
        var ivo = new IVO();
        var evil = new EVIL();

        string command;

        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            UpdateCoordinates(command, ivo, evil);
            MoveEvil(evil, matrix);
            MoveIvo(ivo, matrix);
        }

        Console.WriteLine(ivo.Score);
    }

    private static void MoveIvo(IVO ivo, int[,] matrix)
    {
        while (ivo.Row >= 0)
        {
            if (ivo.Row < matrix.GetLength(0) && ivo.Col >= 0 && ivo.Col < matrix.GetLength(1))
            {
                ivo.CollectPoints(matrix[ivo.Row, ivo.Col]);
            }

            ivo.UpdateCoordinates(ivo.Row - 1, ivo.Col + 1);
        }
    }

    private static void MoveEvil(EVIL evil, int[,] matrix)
    {
        while (evil.Row >= 0)
        {
            if (evil.Row < matrix.GetLength(0) && evil.Col >= 0 && evil.Col < matrix.GetLength(1))
            {
                matrix[evil.Row, evil.Col] = 0;
            }
            evil.UpdateCoordinates(evil.Row - 1, evil.Col - 1);
        }
    }

    private static void UpdateCoordinates(string command, IVO ivo, EVIL evil)
    {
        var ivoCoordinates = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        ivo.UpdateCoordinates(ivoCoordinates[0], ivoCoordinates[1]);

        command = Console.ReadLine();

        var evilCoordinates = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        evil.UpdateCoordinates(evilCoordinates[0], evilCoordinates[1]);
    }

    private static int[,] InitializeMatrix(short[] sizes)
    {
        int rowsCount = sizes[0];
        int colsCount = sizes[1];
        int count = 0;
        var matrix = new int[rowsCount, colsCount];

        for (short i = 0; i < rowsCount; i++)
        {
            for (short j = 0; j < colsCount; j++)
            {
                matrix[i, j] = count++;
            }
        }

        return matrix;
    }
}