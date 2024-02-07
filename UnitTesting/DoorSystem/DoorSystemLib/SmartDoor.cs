//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//public class SmartDoor : SimpleDoor
//{
//    private readonly List<IDoorFeature> features = new List<IDoorFeature>();
//    private int timerDuration;
//    private TimerNotifier timer;
//    public event Action TimerExpired;

//    public void AddFeature(IDoorFeature feature)
//    {
//        features.Add(feature);
//    }

//    public void SetTimer(int time)
//    {
//        this.timerDuration = time;
//        timer = new TimerNotifier(time);
//        Console.WriteLine($"Timer set for {time} seconds.");

//        timer.TimerExpired += () =>
//        {
//            TimerExpired?.Invoke(); // Forward the TimerExpired event of TimerNotifier to SmartDoor
//        };
//    }

//    public new void Open()
//    {
//        base.Open();
//        if (timer != null)
//        {
//            timer.StartTimer();
//            if (timer.GetElapsedTime() > timerDuration && GetState() == DoorState.Opened)
//            {
//                // Activate features when the door is opened
//                foreach (var feature in features)
//                {
//                    feature.Activate?.Invoke();
//                }
//            }
//            timer.StopTimer();
//        }
//    }

//    // Create a new timer class which will notify smartDoor if it's expired or not
//    // call the setTimer in open of smartdoor
//    // include logic for checking threshold then if door is still open then call for features
//    // relate smart door with timer, in class, not in main
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class SmartDoor : SimpleDoor
{
    private readonly List<IDoorFeature> features = new List<IDoorFeature>();
    private DoorState state;
    private bool alertRequired;
    private int durationThresholdSec;
    public DateTime openedTime;
    public event Action<bool> alertRequiredChanged;

    private SmartDoorTimerMonitor monitor;

    public SmartDoor()
    {
        alertRequired = false;
        durationThresholdSec = 2;
        // Since the door is closed at the beginning,
        // setting openedTime to the future ensures that timer doesn't exceed threshold
        openedTime = DateTime.MaxValue;
        monitor = new SmartDoorTimerMonitor(this);  // Gets the monitor, and its async thread running
    }

    public void AddFeature(IDoorFeature feature)
    {
        features.Add(feature);
    }

    public void SetTimer(int time)
    {
        durationThresholdSec = time;
        Console.WriteLine($"Timer set for {time} seconds.");
    }

public new void Open()
    {
        if (this.state == DoorState.Closed)
        {
            base.Open();
            this.state = DoorState.Opened;
            openedTime = DateTime.Now;
        }
        if (GetState() == DoorState.Opened)
        {
            // activate features when the door is opened
            foreach (var feature in features)
            {
                feature.Activate?.Invoke();
            }
        }
    }

    public new void Close()
    {
        if (this.state == DoorState.Opened)
        {
            base.Close();
            this.state = DoorState.Closed;
        }
    }

    public DoorState State { get { return state; } }

    public DateTime OpenedTime { get { return openedTime; } }

    public int DurationThresholdSec { get { return durationThresholdSec; } }

    public void SetAlertRequired(bool flag)
    {
        alertRequired = flag;
        if (alertRequired)
        {
            alertRequiredChanged.Invoke(alertRequired);
            alertRequired = false;
        }
    }
}
