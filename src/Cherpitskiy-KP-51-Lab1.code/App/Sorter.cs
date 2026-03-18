class Sorter
{
    private List<Record> records = new();
    private SortStatistics statistics = new();

    public void initCollection()
    {
        records = new();
        statistics = new();
    }

    public void Add(Record record)
    {
        records.Add(record);
    }

    public bool Delete(int TargetNumber)
    {
        for (int i = 0; i < records.Count; i++)
        {
            if (TargetNumber == records[i].CardNumber)
            {
                records.Remove(records[i]);
                return true;
            }
        }
        return false;
    }

    public IReadOnlyList<Record> GetRecords()
    {
        return records;
    }

    public void ControlValues()
    {
        initCollection();
        Add(new Record("Ivan", "Ivanov", 1, 101));
        Add(new Record("Anton", "Ivanov", 2, 105));
        Add(new Record("Petro", "Petrov", 3, 103));
        Add(new Record("Anna", "Bondar", 1, 102));
        Add(new Record("Oleg", "Shevchenko", 2, 104));
        Add(new Record("Zahar", "Petrov", 1, 20));
        Add(new Record("Ivan", "Petrov", 3, 103));
        Add(new Record("Masha", "Petrova", 3, 103));
        Add(new Record("Artem", "Petrov", 3, 103));
    }

    public void Merge(Record[] record)
    {
        statistics.RecursiveCallsAdd();
        int length = record.Length;
        if (length <= 1) return;

        int middle = length / 2;
        Record[] LeftArray = new Record[middle];
        Record[] rightArray = new Record[length - middle];
        int j = 0;
        for (int i = 0; i < length; i++)
        {
            if (i < middle)
            {
                LeftArray[i] = record[i];
            }
            else
            {
                rightArray[j] = record[i];
                j++;
            }
        }
        Console.WriteLine($"Масив {record.Length} розділено на праву : {LeftArray.Length} та ліву : {rightArray.Length} ");
        Merge(LeftArray);
        Merge(rightArray);
        MergeSort(LeftArray, rightArray, record);
    }
    public void MergeSort(Record[] leftarray, Record[] rightarray, Record[] array)
    {
        int i = 0; int j = 0; int k = 0;
        //left     // right      //array
        while (i < leftarray.Length && j < rightarray.Length)
        {
            statistics.Comparisons++;
            int res = string.Compare(leftarray[i].LastName, rightarray[j].LastName);

            if (res < 0 || (res == 0 && string.Compare(leftarray[i].FirstName, rightarray[j].FirstName) <= 0))
            {
                if (res == 0) statistics.Comparisons++;
                array[k++] = leftarray[i++];
            }
            else
            {
                array[k++] = rightarray[j++];
            }
            statistics.Copies++;
        }

        while (i < leftarray.Length)
        {
            array[k++] = leftarray[i++];
            statistics.Copies++;
        }

        while (j < rightarray.Length)
        {
            array[k++] = rightarray[j++];
            statistics.Copies++;
        }
        PrintIntermediateSteps(array);
    }

    public IReadOnlyList<Record> SameStartLetter(char letter)
    {
        List<Record> list = new();
        char search = char.ToUpper(letter);
        for (int i = 0; i < records.Count; i++)
        {
            char checkLetter = char.ToUpper(records[i].LastName[0]);
            if (checkLetter == search)
            {
                list.Add(records[i]);
            }
        }
        return list;
    }

    public IReadOnlyDictionary<int, int> CountByDistricts()
    {
        var counts = new Dictionary<int, int>();
        foreach (var p in records)
        {
            if (counts.ContainsKey(p.District)) counts[p.District]++;
            else counts[p.District] = 1;
        }
        return counts;
    }

    public void SortCollection()
    {
        if (records.Count == 0) return;
        statistics.Reset();
        var watch = System.Diagnostics.Stopwatch.StartNew();

        Record[] array = records.ToArray();
        Merge(array);
        records = array.ToList();

        watch.Stop();
        statistics.ExecutionTime = (int)watch.ElapsedMilliseconds;
    }

    public void PrintIntermediateSteps(Record[] currentSegment)
    {
        foreach (var item in currentSegment)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(new string('-', 20));
    }

    public void PrintStatistics()
    {
        Console.WriteLine($"Comparisons: {statistics.Comparisons}");
        Console.WriteLine($"Copies: {statistics.Copies}");
        Console.WriteLine($"Recursive calls: {statistics.RecursiveCalls}");
        Console.WriteLine($"Execution time: {statistics.ExecutionTime} ms");
    }
}














