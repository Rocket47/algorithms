using HardWork.Tasks.Task1Elevator.Models;

namespace HardWork.Tasks.Task1Elevator.After;

internal static class ElevatorMovement
{
    public static ElevatorCommandResult MoveTo(ElevatorState state, int floor, ElevatorDirection direction)
    {
        state.Direction = direction;
        state.CurrentFloor = floor;
        state.Direction = ElevatorDirection.Stopped;
        return new ElevatorCommandResult(state, $"Going {direction.ToString().ToLowerInvariant()} and stopped at floor {floor}");
    }

    public static ElevatorCommandResult Stay(ElevatorState state) =>
        new(state, "That is our current floor");

    public static ElevatorCommandResult ChangeDirection(ElevatorState state, int floor, ElevatorDirection direction)
    {
        state.Direction = direction;
        state.CurrentFloor = floor;
        return new ElevatorCommandResult(state, $"Changing direction and going {direction.ToString().ToLowerInvariant()} to floor {floor}");
    }
}
