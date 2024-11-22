using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMatrix
{
    public class Matrix<T>
    {
        T[,] _data;
        int _rows;
        int _columns;

        public int Rows => _rows;
        public int Columns => _columns;

        public Matrix(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _data = new T[rows, columns];
        }

        public Matrix(int size) : this(size, size) { }

        public Matrix() : this(3, 3) { }

        public T this[int row, int column]
        {
            get => _data[row, column];
            set => _data[row, column] = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _rows; i++)
            {
                sb.Append("| ");
                for (int j = 0; j < _columns; j++)
                {
                    sb.Append(_data[i, j]?.ToString().PadRight(5) + ", ");
                }
                sb.Length -= 2;
                sb.AppendLine(" |");
            }
            return sb.ToString();
        }

        public static Matrix<T> Add(Matrix<T> A, Matrix<T> B)
        {
            if (A.Rows != B.Rows || A.Columns != B.Columns)
                throw new ArgumentException("Matrix dimensions must match for addition.");

            var result = new Matrix<T>(A.Rows, A.Columns);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    dynamic a = A[i, j];
                    dynamic b = B[i, j];
                    result[i, j] = a + b;
                }
            }
            return result;
        }

        public void Fill(T element)
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _data[i, j] = element;
                }
            }
        }

        private static void EnsureNumeric()
        {
            var type = typeof(T);
            if (!type.IsPrimitive || type == typeof(bool) || type == typeof(char))
            {
                throw new InvalidOperationException("Matrix operations require numeric types.");
            }
        }

        public (int Rows, int Columns) GetSize() => (Rows, Columns);
    }
}
