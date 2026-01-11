public class Student
{
    public int Id { get; set;}
    public string? Nazwisko { get; set;}  // Make nullable
    public int Wiek { get; set; }
    public List<string>? Umiejetnosci { get; set; } = new List<string>();
    public string Imie { get; set; } = string.Empty;  // Add this property

    public Student()
    {
        Nazwisko = string.Empty;  // Or a default value
    }
}