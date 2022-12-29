using System;

namespace lab04
{
    public class MyMatrix
    {
        public static int min, max;

        private double[,] matrix;
        private int a, b;

        public MyMatrix(int a, int b)
        {
            this.a = a;
            this.b = b;

            Random rnd = new Random();

            matrix = new double[a,b];
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    matrix[i,j] = rnd.Next(min, max);
        }

        public static MyMatrix operator +(MyMatrix mt1, MyMatrix mt2)
        {
            MyMatrix NewMatrix = new MyMatrix(mt1.a, mt1.b);

            for (int i = 0; i < mt1.a; i++)
                for (int j = 0; j < mt1.b; j++)
                    NewMatrix.matrix[i,j] = mt1.matrix[i,j] + mt2.matrix[i,j];

            return NewMatrix;
        }

        public static MyMatrix operator -(MyMatrix mt1, MyMatrix mt2)
        {
            MyMatrix NewMatrix = new MyMatrix(mt1.a, mt1.b);

            for (int i = 0; i < mt1.a; i++)
                for (int j = 0; j < mt1.b; j++)
                    NewMatrix.matrix[i, j] = mt1.matrix[i, j] - mt2.matrix[i, j];

            return NewMatrix; 
        }

        public static MyMatrix operator *(MyMatrix mt1, MyMatrix mt2)
        {
            MyMatrix NewMatrix = new MyMatrix(mt1.a, mt1.b);

            for (int i = 0; i < mt1.a; i++)
                for (int j = 0; j < mt2.b; j++)
                    for (int k = 0; k < mt2.a; k++)
                        NewMatrix.matrix[i,j] = mt1.matrix[i,k] * mt2.matrix[k,j];

            return NewMatrix;
        }

        public static MyMatrix operator *(MyMatrix mt1, double num)
        {
            MyMatrix NewMatrix = new MyMatrix(mt1.a, mt1.b);

            for (int i = 0; i < mt1.a; i++)
                for (int j = 0; j < mt1.b; j++)
                    NewMatrix.matrix[i, j] = mt1.matrix[i, j] * num;

            return NewMatrix;
        }

        public static MyMatrix operator *(double num, MyMatrix mt2)
        {
            return mt2 * num;
        }

        public static MyMatrix operator /(MyMatrix mt1, double num)
        {
            MyMatrix NewMatrix = new MyMatrix(mt1.a, mt1.b);

            for (int i = 0; i < mt1.a; i++)
                for (int j = 0; j < mt1.b; j++)
                    NewMatrix.matrix[i, j] = mt1.matrix[i, j] / num;

            return NewMatrix;
        }

        public double this[int row, int sol]
        {
            get => matrix[row, sol];
        }
    }
}
