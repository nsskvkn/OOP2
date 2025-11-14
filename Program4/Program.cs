namespace lab3_4;

public delegate int[] DiagonalExtractor(int[,] matrix);

static class Program
{
    static void Main()
    {
        Console.WriteLine("Делегати і лямбда");

        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        DiagonalExtractor anonExtractor = delegate (int[,] m) {
            int n = Math.Min(m.GetLength(0), m.GetLength(1));
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
                result[i] = m[i, i];
            return result;
        };

        int[] diagAnon = anonExtractor.Invoke(matrix);
        Console.WriteLine($"Результат анонімної функції: {string.Join(", ", diagAnon)}");

        DiagonalExtractor lambdaExtractor = (m) => {
            int n = Math.Min(m.GetLength(0), m.GetLength(1));
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
                result[i] = m[i, i];
            return result;
        };

        int[] diagLambda = lambdaExtractor.Invoke(matrix);
        Console.WriteLine($"Результат анонімної функції: {string.Join(", ", diagLambda)}");

        Console.WriteLine("Події (MobileAccount)");

        var account = new MobileAccount(50m, 10m);
        account.BalanceUsed += onBalanceUsed;
        account.BalanceReachedMinimum += onBalanceReachedMinimum;

        account.TopUp(20m);
        account.Use(30m);
        account.Use(25m);
        account.TopUp(10m);
        account.Use(45m); 

        Console.WriteLine("...");
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
