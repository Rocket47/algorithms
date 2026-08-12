using HardWork.Tasks.Task1Elevator.Models;

namespace HardWork.Tasks.Task1Elevator.After;

internal sealed class UpDirectionHandler : IElevatorDirectionHandler
{
    public ElevatorCommandResult Handle(ElevatorState state, int floor)
    {
        if (state.CurrentFloor < floor)
        {
            return ElevatorMovement.MoveTo(state, floor, ElevatorDirection.Up);
        }

        return state.CurrentFloor == floor ? ElevatorMovement.Stay(state) : ElevatorMovement.ChangeDirection(state, floor, ElevatorDirection.Down);
    }
}
