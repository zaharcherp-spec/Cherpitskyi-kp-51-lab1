class Menu
{
    private readonly Sorter Sorter;
    public Menu(Sorter sorter)
    {
        Sorter = sorter;
    }
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("0 -Вихід");
            Console.WriteLine($"1. initCollection() – створює порожню колекцію . (Порожня колекція за замовчуванням створена)");
            Console.WriteLine("2. addRecord(Record record) – додає новий елемент. ");
            Console.WriteLine("3. removeRecord(...) – видаляє елемент за заданим параметром. ");
            Console.WriteLine("4. printCollection() – виводить поточний вміст колекції. ");
            Console.WriteLine("5. generateControlData() – заповнює колекцію контрольними значеннями. ");
            Console.WriteLine("6. sortCollection() – виконує сортування відповідно до варіанту №9");
            Console.WriteLine("7. printIntermediateSteps() – виводить ключові етапи роботи алгоритму.");
            Console.WriteLine("8. printStatistics() – виводить статистику виконання алгоритму.");
            Console.WriteLine("9.Пошук по першій літері Прізвища");
            Console.WriteLine("10.Пошук по номерам районів");
        
            string? choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "0":
                        return;

                    case "1":
                        Sorter.initCollection();
                        Console.WriteLine("Створена нова порожня колекція!!");
                        break;

                    case "2":
                        Console.WriteLine("Ім'я--");
                        string? name = Console.ReadLine();

                        Console.WriteLine("Прізвище--");
                        string? surname = Console.ReadLine();

                        Console.WriteLine("Номер картки--");
                        int cardNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("Район--");
                        int district = int.Parse(Console.ReadLine());

                        Record record = new(name, surname, district, cardNumber);
                        Sorter.Add(record);
                        break;

                    case "3":
                        Console.WriteLine("Номер картки--");
                        int number = int.Parse(Console.ReadLine());

                        bool succces = Sorter.Delete(number);

                        if (succces)
                        {
                            Console.WriteLine("Успіх");
                        }
                        else
                        {
                            Console.WriteLine("Не знайдено");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Список елементів");
                        var list = Sorter.GetRecords();
                        foreach (var el in list) Console.WriteLine(el);
                        break;

                    case "5":
                        Sorter.ControlValues();
                        Console.WriteLine("Створена нова колекція для тестування на 5 елементів");
                        break;

                    case "6":
                        Sorter.SortCollection();
                        Console.WriteLine("Сортування завершено!");
                        break;

                    case "7":
                        Console.WriteLine("Проміжні кроки виводяться автоматично під час виконання пункту 6.");
                        break;

                    case "8":
                        Sorter.PrintStatistics();
                        break;

                    case "9":
                        Console.WriteLine("Введіть першу літеру прізвища:");
                        char letter = Console.ReadLine()[0];
                        var list1 = Sorter.SameStartLetter(letter);

                        if (list1.Count == 0) Console.WriteLine("Нічого не знайдено.");

                        foreach (var el in list1) Console.WriteLine(el);
                        break;

                    case "10":
                        var counts = Sorter.CountByDistricts();
                        Console.WriteLine("Статистика по районах:");
                        foreach (var kvp in counts)
                        {
                            Console.WriteLine($"Район {kvp.Key}: {kvp.Value} пацієнтів");
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}





