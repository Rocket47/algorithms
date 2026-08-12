using HardWork.Tasks.Task1Elevator.Models;

namespace HardWork.Tasks.Task1Elevator.After;

public sealed class ElevatorControllerAfter
{
    private readonly IReadOnlyDictionary<ElevatorDirection, IElevatorDirectionHandler> _handlers =
        new Dictionary<ElevatorDirection, IElevatorDirectionHandler>
        {
            [ElevatorDirection.Down] = new DownDirectionHandler(),
            [ElevatorDirection.Stopped] = new StoppedDirectionHandler(),
            [ElevatorDirection.Up] = new UpDirectionHandler()
        };

    public ElevatorCommandResult FloorPress(ElevatorState state, int floor)
    {
        if (floor < 1)
        {
            return new ElevatorCommandResult(state, "Floor must be positive");
        }

        if (floor > state.TopFloor)
        {
            return new ElevatorCommandResult(state, $"We only have {state.TopFloor} floors");
        }

        return _handlers[state.Direction].Handle(state, floor);
    }
}
