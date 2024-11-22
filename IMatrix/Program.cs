using IMatrix;

var matrix1 = new Matrix<int>(3, 3);
matrix1.Fill(1);
Console.WriteLine("Matrix 1:");
Console.WriteLine(matrix1);

var matrix2 = new Matrix<int>(3, 3);
matrix2.Fill(2);
Console.WriteLine("Matrix 2:");
Console.WriteLine(matrix2);

var addedMatrix = Matrix<int>.Add(matrix1, matrix2);
Console.WriteLine("Added Matrix:");
Console.WriteLine(addedMatrix);
