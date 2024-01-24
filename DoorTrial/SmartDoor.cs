using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class SmartDoor : SimpleDoor
{
    private readonly List<IDoorFeature> features = new List<IDoorFeature>();
    private int timerDuration;

    public event Action TimerExpired;

    public void AddFeature(IDoorFeature feature)
    {
        features.Add(feature);
    }

    public void SetTimer(int time)
    {
        timerDuration = time;
        Console.WriteLine($"Timer set for {time} seconds.");

        // Start the timer
        System.Threading.Thread timerThread = new System.Threading.Thread(() =>
        {
            Thread.Sleep(timerDuration * 1000);
            TimerExpired?.Invoke();
        });
        timerThread.Start();
    }

    public new void Open()
    {
        base.Open();

        Thread.Sleep(2000);

        // Activate features when the door is opened
        foreach (var feature in features)
        {
            feature.Activate?.Invoke();
        }
    }

    // Create a new timer class which will notify smartDoor if it's expired or not
    // call the setTimer in open of smartdoor
    // include logic for checking threshold then if door is still open then call for features
    // relate smart door with timer, in class, not in main
}
