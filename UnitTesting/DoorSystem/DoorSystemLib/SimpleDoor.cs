using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SimpleDoor
{
    private DoorState state;

    public event Action DoorOpened;
    public event Action DoorClosed;

    public SimpleDoor()
    {
        state = DoorState.Closed;
    }

    public void Open()
    {
        state = DoorState.Opened;
        OnDoorOpened();
    }

    public void Close()
    {
        state = DoorState.Closed;
        OnDoorClosed();
    }

    public DoorState GetState()
    {
        return state;
    }

    protected virtual void OnDoorOpened()
    {
        DoorOpened?.Invoke();
    }

    protected virtual void OnDoorClosed()
    {
        DoorClosed?.Invoke();
    }
}
