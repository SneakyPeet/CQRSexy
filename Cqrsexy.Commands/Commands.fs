namespace Cqrsexy.Commands

open System

[<Interface>]
type ICommand = interface end

type CreateLeaveEntry = {
    EmployeeId: Guid;
    StartDate: DateTime;
    EndDate: DateTime;
    LeaveType: String;
} with interface ICommand