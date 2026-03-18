class SortStatistics
{
    public int Comparisons { get; set; } = 0;
    public int Copies { get;  set; } = 0;
    public int RecursiveCalls { get; set; } = 0;
    public int ExecutionTime { get; set; } = 0;

    public void Reset()
    {
        Comparisons = 0;
        Copies = 0;
        RecursiveCalls = 0;
        ExecutionTime = 0;
    }

    public void RecursiveCallsAdd()
    {
        RecursiveCalls++;
    }
}
