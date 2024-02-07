using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class SmartDoorTimerMonitor
{
    private Timer timer;
    SmartDoor door;

    public SmartDoorTimerMonitor(SmartDoor door)
    {
        this.door = door;
        timer = new Timer(CheckAlertRequired, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    private void CheckAlertRequired(object state)
    {
        if (door.GetState() == DoorState.Opened)
        {
            TimeSpan duration = DateTime.Now - door.openedTime;

            if (duration.TotalSeconds > door.DurationThresholdSec)
            {
                door.SetAlertRequired(true);
            }
        }
    }
}
