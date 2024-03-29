﻿using System.Numerics;

namespace ComplexMatrices
{
    public class SystemOfLinearEqs
    {
        private Matrix A;
        private Matrix B;

        private int M;

        public SystemOfLinearEqs(Matrix A, Matrix B)
        {
            if (!(B.M == B.M && B.M == A.N && B.N == 1)) throw new Exception();

            this.A = A;
            this.B = B;

            this.M = A.M;
        }

        public Matrix GetA() => A;
        public Matrix GetB() => B;

        public Matrix GetSolutions()
        {
            var answers = new Complex[1, M];

            var det = A.Determinant();

            for (int i = 0; i < M; i++)
            {
                answers[0, i] = A.ReplaceColumn(B, i).Determinant() / det;
            }

            return new Matrix(answers);
        }
    }
}
