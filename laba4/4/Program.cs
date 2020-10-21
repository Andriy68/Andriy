using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class room
{
    public room(int id)
    {
        Id = id;
        Patients = new List<patient>();
    }
    public List<patient> Patients { get; private set; }
    public int Id { get; private set; }

    public void AddPatient(patient patient)
    {
        if (Patients.Count >= 3)
        {
            throw new Exception();
        }

        this.Patients.Add(patient);
    }
}
public class patient
{
    public patient(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}
public class doc
{
    public doc(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Patients = new List<patient>();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public List<patient> Patients { get; private set; }

    public void AddPatient(patient patient)
    {
        Patients.Add(patient);
    }

    public string GetPatients()
    {
        return String.Join(Environment.NewLine, Patients.Select(p => p.Name).OrderBy(p => p));
    }
}
public class dep
{
    private List<room> rooms;
    private string name;

    public dep(string name)
    {
        this.name = name;

        this.rooms = new List<room>();
        for (int i = 0; i < 20; i++)
        {
            rooms.Add(new room(i + 1));
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public void AddPatientToRoom(patient patient)
    {
        var room = this.rooms.FirstOrDefault(r => r.Patients.Count < 3);

        if (room != null)
        {
            room.AddPatient(patient);
        }
    }

    public string GetAllPatients()
    {
        var a = this.rooms.SelectMany(r => r.Patients).ToList();
        return String.Join(Environment.NewLine, this.rooms.SelectMany(r => r.Patients).Select(p => p.Name).ToList());
    }

    public string GetPatientsByRoom(int id)
    {
        return String.Join(Environment.NewLine, rooms.Single(r => r.Id == id).Patients.Select(p => p.Name).OrderBy(p => p));
    }
}
class Program
{
    private static List<dep> departments = new List<dep>();
    private static List<doc> doctors = new List<doc>();

    static void Main(string[] args)
    {
        string command;

        while ((command = Console.ReadLine()) != "Output")
        {
            var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ParseCommand(commandArgs);
        }

        while ((command = Console.ReadLine()) != "End")
        {
            var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            PrintOutput(commandArgs);
        }
    }

    private static void PrintOutput(string[] commandArgs)
    {
        if (commandArgs.Length == 1)
        {
            string departmentName = commandArgs[0];

            Console.WriteLine(departments.Single(d => d.Name == departmentName).GetAllPatients());
        }
        else if (commandArgs.Length == 2)
        {
            if (commandArgs[1].All(Char.IsDigit))
            {
                string departmentName = commandArgs[0];
                int roomNumber = int.Parse(commandArgs[1]);

                Console.WriteLine(departments.Single(d => d.Name == departmentName).GetPatientsByRoom(roomNumber));
            }
            else
            {
                string doctorFirstName = commandArgs[0];
                string doctorLastName = commandArgs[1];

                Console.WriteLine(doctors.Single(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName).GetPatients());
            }
        }
    }

    private static void ParseCommand(string[] commandArgs)
    {
        string departmentName = commandArgs[0];
        string doctorFirstName = commandArgs[1];
        string doctorLastName = commandArgs[2];
        string patientName = commandArgs[3];

        if (!departments.Any(d => d.Name == departmentName))
        {
            departments.Add(new dep(departmentName));
        }

        var department = departments.Single(d => d.Name == departmentName);
        var patient = new patient(patientName);

        department.AddPatientToRoom(patient);

        if (!doctors.Any(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName))
        {
            doctors.Add(new doc(doctorFirstName, doctorLastName));
        }

        var doctor = doctors.Single(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName);

        doctor.AddPatient(patient);
    }
}