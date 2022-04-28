using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSquare : Generator
{
    private int Width;
    public float[,] Array;//0<=value<=1;
    private float roudness;
    public DiamondSquare(float[,] array, int width, float roudness = 1)
    {
        Width = width;
        Array = array;
        this.roudness = roudness;


    }
    private bool beyondBorder(int coord_x, int coord_y, int reach)
    {
        if (coord_x - reach == 0 || coord_x + reach == Width)
            return true;
        if (coord_y - reach == 0 || coord_y + reach == Width)
            return true;

        return false;
    }
    private void Step(int size)
    {
        int half = size / 2;
        if (half < 1)
            return;
        for (int y = half; y < Width; y += size)
            for (int x = half; x < Width; x += size)
                squareStep(x % Width, y % Width, half);
        int col = 0;
        for (int x = 0; x < Width; x += half)
        {
            col++;
            for (int z = half * (col % 2); z < Width; z += size)
                diamondStep(x % Width, z % Width, half);
        }
        Step(size / 2);

    }

    private void squareStep(int x, int y, int reach)
    {
        int count = 0;
        float avg = 0.0f;
        if (beyondBorder(x, y, reach))
        {
            Array[x, y] = 0.0f;
            return;
        }
        else
        {
            if (x - reach >= 0 && y - reach >= 0)
            {
                avg += Array[x - reach, y - reach];
                count++;
            }
            if (x - reach >= 0 && y + reach < Width)
            {
                avg += Array[x - reach, y + reach];
                count++;
            }
            if (x + reach < Width && y - reach >= 0)
            {
                avg += Array[x + reach, y - reach];
                count++;
            }
            if (x + reach < Width && y + reach < Width)
            {
                avg += Array[x + reach, y + reach];
                count++;
            }
            avg += 2*Random.Range(-roudness * reach, roudness * reach);
            avg /= count;
            if (avg < 0)
                avg = 0;
            Array[x, y] = avg;
        }


    }

    private void diamondStep(int x, int y, int reach)
    {
        int count = 0;
        float avg = 0.0f;
        if (beyondBorder(x, y, reach))
        {
            Array[x, y] = 0;
            return;
        }

        {
            if (x - reach >= 0)
            {
                avg += Array[x - reach, y];
                count++;
            }
            if (x + reach < Width)
            {
                avg += Array[x + reach, y];
                count++;
            }
            if (y - reach >= 0)
            {
                avg += Array[x, y - reach];
                count++;
            }
            if (y + reach < Width)
            {
                avg += Array[x, y + reach];
                count++;
            }
            avg += 2*Random.Range(-roudness * reach, roudness * reach);
            avg /= count;
            if (avg < 0)
                avg = 0;
            Array[x, y] = avg;
        }
    }

    public override void Generate()
    {
        Step(Width / 2);
        Scale();
    }

    private void Scale()
    {
        float max = float.MinValue;
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Width; j++)
            {
                if (max < Array[i, j])
                    max = Array[i, j];
            }

        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Width; j++)
            {
                Array[i, j] /= max;//make values bettwen 0 and 1
            }
    }
}

 
