class Program
{
    static void Main()
    {
        Sorter sorter = new Sorter();
        Menu menu = new(sorter);
        menu.Run();
    }
}
