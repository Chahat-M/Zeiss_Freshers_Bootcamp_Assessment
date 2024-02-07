using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class TimerNotifier
{
    private readonly int timerDuration;
    private System.Threading.Thread timerThread;
    //public event Action TimerExpired;
    private DateTime startTime;
    private int runningTime;

    public TimerNotifier(int duration)
    {
        this.timerDuration = duration;
    }

    public void StartTimer()
    {
        startTime = DateTime.Now;
        //timerThread = new Thread(() =>
        //{
        //    while (runningTime < timerDuration)
        //    {
        //        runningTime = GetElapsedTime();
        //    }
        //    TimerExpired?.Invoke();
        //});
        timerThread.Start();
    }

    public void StopTimer()
    {
        if (timerThread != null && timerThread.IsAlive)
        {
            timerThread.Abort();
        }
    }

    public int GetElapsedTime()
    {
        TimeSpan elapsedTime = DateTime.Now - startTime;
        int runningTime2 = (int)elapsedTime.TotalSeconds;
        Console.WriteLine($"Time: {runningTime}");
        return runningTime2;
    }
}

//public class SmartDoorTimerMonitor
//{
//    private Timer timer;
//    SmartDoor door;

//    public SmartDoorTimerMonitor(SmartDoor door)
//    {
//        this.door = door;
//        timer = new Timer(CheckAlertRequired, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
//    }

//    private void CheckAlertRequired(object state)
//    {
//        if (door.GetState() == DoorState.Opened)
//        {
//            TimeSpan duration = DateTime.Now - door.openedTime;

//            if (duration.TotalSeconds > door.DurationThresholdSec)
//            {
//                door.SetAlertRequired(true);
//            }
//        }
//    }
//}
