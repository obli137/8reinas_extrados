int[][] tablero = CrearTablero();
PonerReinas(tablero, 0);
ImprimirTablero(tablero);


int[][] CrearTablero()
{
    int[][] tablero = new int[8][];
    for (int fila = 0; fila < 8; fila++)
    {
        tablero[fila] = new int[8];
        for (int columna = 0; columna < 8; columna++)
        {
            tablero[fila][columna] = 0;
        }
    }
    return tablero;
}



bool EsSeguro(int[][] tablero, int fila, int columna)
{
    int tamaño = tablero.Length;
    for (int i = 0; i < tamaño; i++)
    {
        if (tablero[fila][i] == 1)
            return false;
    }

    for (int i = 0; i < tamaño; i++)
    {
        if (tablero[i][columna] == 1)
            return false;
    }


    for (int i = 0; i < tamaño; i++)
    {
        for (int j = 0; j < tamaño; j++)
        {
            if (tablero[i][j] == 1 && (Math.Abs(fila - i) == Math.Abs(columna - j)))
                return false;
        }
    }

    return true;
}

bool PonerReinas(int[][] tablero, int fila)
{

    if (fila == 8)
    {

        return true;
    }

    for (int columna = 0; columna < 8; columna++)
    {
        if (EsSeguro(tablero, fila, columna))
        {
            tablero[fila][columna] = 1;

            if (PonerReinas(tablero, fila + 1))
            {
                return true;
            }

            tablero[fila][columna] = 0;
        }
    }

    return false;
}

void ImprimirTablero(int[][] tablero)
{

    for (int fila = 0; fila < 8; fila++)
    {
        for (int columna = 0; columna < 8; columna++)
        {
            Console.Write(tablero[fila][columna] + " ");
        }
        Console.WriteLine();
    }
}

