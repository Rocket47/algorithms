using HardWork.Tasks.Task1Elevator.Models;

namespace HardWork.Tasks.Task1Elevator.Before;

public sealed class ElevatorControllerBefore
{
    public ElevatorCommandResult FloorPress(ElevatorState state, int floor)
    {
        var message = "";

        if (floor < 1)
        {
            message = "Floor must be positive";
        }
        else if (floor > state.TopFloor)
        {
            message = $"We only have {state.TopFloor} floors";
        }
        else
        {
            switch (state.Direction)
            {
                case ElevatorDirection.Down:
                    if (state.CurrentFloor > floor)
                    {
                        state.CurrentFloor = floor;
                        state.Direction = ElevatorDirection.Stopped;
                        message = $"Going down and stopped at floor {floor}";
                    }
                    else if (state.CurrentFloor == floor)
                    {
                        state.Direction = ElevatorDirection.Stopped;
                        message = "That is our current floor";
                    }
                    else
                    {
                        state.Direction = ElevatorDirection.Up;
                        state.CurrentFloor = floor;
                        message = $"Changing direction and going up to floor {floor}";
                    }

                    break;

                case ElevatorDirection.Stopped:
                    if (state.CurrentFloor < floor)
                    {
                        state.Direction = ElevatorDirection.Up;
                        state.CurrentFloor = floor;
                        state.Direction = ElevatorDirection.Stopped;
                        message = $"Going up and stopped at floor {floor}";
                    }
                    else if (state.CurrentFloor == floor)
                    {
                        message = "That is our current floor";
                    }
                    else
                    {
                        state.Direction = ElevatorDirection.Down;
                        state.CurrentFloor = floor;
                        state.Direction = ElevatorDirection.Stopped;
                        message = $"Going down and stopped at floor {floor}";
                    }

                    break;

                case ElevatorDirection.Up:
                    if (state.CurrentFloor < floor)
                    {
                        state.CurrentFloor = floor;
                        state.Direction = ElevatorDirection.Stopped;
                        message = $"Going up and stopped at floor {floor}";
                    }
                    else if (state.CurrentFloor == floor)
                    {
                        state.Direction = ElevatorDirection.Stopped;
                        message = "That is our current floor";
                    }
                    else
                    {
                        state.Direction = ElevatorDirection.Down;
                        state.CurrentFloor = floor;
                        message = $"Changing direction and going down to floor {floor}";
                    }

                    break;

                default:
                    message = "Unknown elevator direction";
                    break;
            }
        }

        return new ElevatorCommandResult(state, message);
    }
}
