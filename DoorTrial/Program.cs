using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        // Using Smart Door with Configurable Features
        Console.WriteLine("Using Smart Door with Configurable Features:");
        var smartDoor = new SmartDoor();

        // Dynamically add features
        smartDoor.AddFeature(new RingBuzzerFeature());
        smartDoor.AddFeature(new NotifyPagerFeature());
        smartDoor.AddFeature(new AutoCloseFeature(true)); // Example: Auto close condition

        // Subscribe to door events
        smartDoor.DoorOpened += () => Console.WriteLine("Door is opened.");
        smartDoor.DoorClosed += () => Console.WriteLine("Door is closed.");
        smartDoor.TimerExpired += () => Console.WriteLine("Timer expired!");

        // Set timer and simulate door interactions
        smartDoor.SetTimer(40);
        smartDoor.Open();
        smartDoor.Close();
    }
}

