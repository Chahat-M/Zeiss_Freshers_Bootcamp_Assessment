namespace DoorSystemLib.Tests
{

    public class SimpleDoorTests
    {
        [Fact]
        public void Open_ShouldChangeDoorStateToOpened()
        {
            // Arrange
             SimpleDoor door = new SimpleDoor();

            // Act
            door.Open();

            // Assert
            Assert.Equal(DoorState.Opened, door.GetState());
        }

        [Fact]
        public void Open_ShouldInvokeDoorOpenedEvent()
        {
            SimpleDoor door = new SimpleDoor();
            bool eventRaised = false;
            door.DoorOpened += () => eventRaised = true;

            door.Open();

            Assert.True(eventRaised);

        }

        [Fact]
        public void Open_WhenDoorIsAlreadyOpened_ShouldNotChangeDoorState()
        {
            // Arrange
            SimpleDoor door = new SimpleDoor();
            door.Open();  

            // Act
            door.Open();  

            // Assert
            Assert.Equal(DoorState.Opened, door.GetState());
        }

        [Fact]
        public void Close_ShouldChangeDoorStateToClosed()
        {
            // Arrange
            SimpleDoor door = new SimpleDoor();

            // Act
            door.Close();

            // Assert
            Assert.Equal(DoorState.Closed, door.GetState());
        }

        [Fact]
        public void Close_ShouldInvokeDoorClosedEvent()
        {
            SimpleDoor door = new SimpleDoor();
            bool eventRaised = false;
            door.DoorClosed += () => eventRaised = true;

            door.Close();

            Assert.True(eventRaised);

        }

        [Fact]
        public void Close_WhenDoorIsAlreadyClosed_ShouldNotChangeDoorState()
        {
            // Arrange
            SimpleDoor door = new SimpleDoor();
            door.Close(); 

            // Act
            door.Close();  

            // Assert
            Assert.Equal(DoorState.Closed, door.GetState());
        }


    }
}
