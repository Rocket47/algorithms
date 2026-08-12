namespace HardWork.Tasks.Task1Elevator.Models;

public sealed class ElevatorState
{
    public int CurrentFloor { get; set; } = 1;

    public int TopFloor { get; init; } = 10;

    public ElevatorDirection Direction { get; set; } = ElevatorDirection.Stopped;
}
