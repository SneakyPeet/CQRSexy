namespace Cqrsexy.Events

open System

[<Interface>]
type IEvent = interface end

type AppliedForLeave = {
    LeaveEntryId: Guid;
} with interface IEvent

type LeaveEntryCreated = {
    EmployeeId: Guid;
    StartDate: DateTime;
    EndDate: DateTime;
    LeaveType: String;
} with interface IEvent
