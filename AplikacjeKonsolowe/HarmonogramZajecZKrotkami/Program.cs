namespace HarmonogramZajecZKrotkami;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Harmonogram zajęć:");
        List<(string day, string subject, string time)> schedule = new List<(string day, string subject, string time)>
        {
            (day: "Poniedziałek", subject: "Matematyka", time: "10:00-11:30"),
            (day: "Poniedziałek", subject: "Informatyka", time: "12:00-13:30"),
            (day: "Poniedziałek", subject: "Język Angielski", time: "14:00-15:30"),
            (day: "wtorek", subject: "Historia", time: "10:00-11:30"),
            (day: "Wtorek", subject: "Fizyka", time: "12:00-13:30"),
            (day: "Wtorek", subject: "WF", time: "14:00-15:30"),
            (day: "Środa", subject: "Biologia", time: "10:00-11:30"),
            (day: "Środa", subject: "Chemia", time: "14:00-15:30"),
            (day: "Czwartek", subject: "Geografia", time: "10:00-11:30"),
            (day: "Czwartek", subject: "Muzyka", time: "12:00-13:30"),
            (day: "Piątek", subject: "Plastyka", time: "14:00-15:30"),
            (day: "Piątek", subject: "Religia", time: "12:00-13:30")
        };

        Console.WriteLine("Podaj dzień tygodnia, aby zobaczyć harmonogram zajęć:");
        string usrInput = Console.ReadLine();
        ShowScheduleForDay(schedule, usrInput);
    }

    static void ShowScheduleForDay(List<(string day, string subject, string time)> schedule, string day)
    {
        foreach (var entry in schedule)
        {
            if (entry.day.Equals(day, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Przedmiot: {entry.subject}, Czas: {entry.time}");
            }
        }
    }
}
