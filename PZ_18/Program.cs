namespace PZ_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Caller sub1 = new Caller("Иванов Иван Иванович", Tariff.Maxi);
            sub1.MakeCall(501);
            sub1.TransferData(25600);

            Console.WriteLine();
            Caller sub2 = new Caller("Петров Петр Петрович", Tariff.Standard);
            sub2.MakeCall(250);
            sub2.TransferData(20480);

            Console.WriteLine();
            Caller sub3 = new Caller("Сидоров Сидор Сидорович", Tariff.Economy);
            sub3.MakeCall(99);
            sub3.TransferData(5120);

            Console.WriteLine();
            Caller.GetCount();
        }
    }
}