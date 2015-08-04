namespace Cqrsexy.Domain.LeaveApplication

open System
open Cqrsexy.DomainMessages

type ApplyForLeave = {
    LeaveId: Guid;
    EmployeeId: Guid;
    StartDate: DateTime;
    EndDate: DateTime;
    LeaveType: String;
} with interface ICommand

type AppliedForLeave = {
    LeaveEntryId: Guid;
} with interface IEvent

type LeaveEntryCreated = {
    EmployeeId: Guid;
    StartDate: DateTime;
    EndDate: DateTime;
    LeaveType: String;
} with interface IEvent

