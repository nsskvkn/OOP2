namespace lab3_4;

public class BalanceEventArgs(decimal balance, string message) : EventArgs
{
    public decimal Balance { get; } = balance;
    public string Message { get; } = message;
}

public class MobileAccount
{
    private decimal balance;
    private readonly decimal minimumThreshold;

    public decimal Balance => this.balance;
    public event EventHandler<BalanceEventArgs>? BalanceReachedMinimum;
    public event EventHandler<BalanceEventArgs>? BalanceUsed;

    public MobileAccount(decimal initialBalance, decimal minThreshold)
    {
        this.balance = initialBalance;
        this.minimumThreshold = minThreshold;
    }

    public void TopUp(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума має бути позитивною");
        this.balance += amount;
        Console.WriteLine($"[MobileAccount] Поповнення: +{amount}. Поточний баланс = {this.balance}");
    }

    public void Use(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума має бути позитивною");
        if (amount > this.balance)
            throw new InvalidOperationException("Недостатньо коштів на рахунку");

        this.balance -= amount;
        this.BalanceUsed?.Invoke(this, new BalanceEventArgs(this.balance, $"Використано {amount}. Залишок: {this.balance}"));

        if (this.balance <= this.minimumThreshold)
            this.onBalanceReachedMinimum(new BalanceEventArgs(this.balance, "Баланс досяг або нижчий за мінімальний поріг!"));
    }

    private void onBalanceReachedMinimum(BalanceEventArgs e)
    {
        this.BalanceReachedMinimum?.Invoke(this, e);
    }
}

