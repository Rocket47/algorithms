using HardWork.Tasks.Task1Elevator.Models;

namespace HardWork.Tasks.Task1Elevator.After;

internal interface IElevatorDirectionHandler
{
    ElevatorCommandResult Handle(ElevatorState state, int floor);
}
