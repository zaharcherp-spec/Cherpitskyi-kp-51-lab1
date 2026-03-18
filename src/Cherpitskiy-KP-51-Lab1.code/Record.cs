class Record
{
    public int CardNumber { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public int District { get; set; }

    public override string ToString()
    {
        return $"{CardNumber} {LastName} {FirstName} {District}";
    }

    public Record(string name, string secondname, int district, int cardNumber)
    {
        CardNumber = cardNumber;
        LastName = secondname;
        FirstName = name;
        District = district;
    }
}

