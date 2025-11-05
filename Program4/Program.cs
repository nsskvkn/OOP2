namespace lab3_4;

public delegate int[] DiagonalExtractor(int[,] matrix);

static class Program
{
    static void Main()
    {
        Console.WriteLine("=============================");
        Console.WriteLine("Part 1 — Делегати і лямбда");
        Console.WriteLine("=============================\n");

        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        // Анонімний метод
        DiagonalExtractor anonExtractor = delegate (int[,] m) {
            int n = Math.Min(m.GetLength(0), m.GetLength(1));
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
                result[i] = m[i, i];
            return result;
        };

        int[] diagAnon = anonExtractor.Invoke(matrix);
        Console.WriteLine($"Anonymous function result: {string.Join(", ", diagAnon)}");

        // Лямбда-вираз
        DiagonalExtractor lambdaExtractor = (m) => {
            int n = Math.Min(m.GetLength(0), m.GetLength(1));
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
                result[i] = m[i, i];
            return result;
        };

        int[] diagLambda = lambdaExtractor.Invoke(matrix);
        Console.WriteLine($"Lambda function result: {string.Join(", ", diagLambda)}");

        Console.WriteLine("\n=============================");
        Console.WriteLine("Part 2 — Події (MobileAccount)");
        Console.WriteLine("=============================\n");

        var account = new MobileAccount(50m, 10m);
        account.BalanceUsed += onBalanceUsed;
        account.BalanceReachedMinimum += onBalanceReachedMinimum;

        account.TopUp(20m);
        account.Use(30m);
        account.Use(25m); // спрацює подія "BalanceReachedMinimum"
        account.TopUp(10m);
        account.Use(45m); // знову спрацює BalanceReachedMinimum

        Console.WriteLine("\nProgram finished. Press any key...");
        Console.ReadKey();
    }

    static void onBalanceUsed(object? sender, BalanceEventArgs e)
    {
        Console.WriteLine($"[INFO] Баланс змінено: {e.Message}");
    }

    static void onBalanceReachedMinimum(object? sender, BalanceEventArgs e)
    {
        Console.WriteLine($"[WARNING] {e.Message} (Поточний баланс: {e.Balance})");
    }
}
