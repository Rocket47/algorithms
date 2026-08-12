using HardWork.Tasks.Task1Elevator.Models;

namespace HardWork.Tasks.Task1Elevator.After;

internal sealed class StoppedDirectionHandler : IElevatorDirectionHandler
{
    public ElevatorCommandResult Handle(ElevatorState state, int floor)
    {
        if (state.CurrentFloor < floor)
        {
            return ElevatorMovement.MoveTo(state, floor, ElevatorDirection.Up);
        }

        if (state.CurrentFloor == floor)
        {
            return ElevatorMovement.Stay(state);
        }

        return ElevatorMovement.MoveTo(state, floor, ElevatorDirection.Down);
    }
}
