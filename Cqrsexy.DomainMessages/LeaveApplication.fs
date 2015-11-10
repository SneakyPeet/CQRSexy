namespace Cqrsexy.Domain.LeaveApplication

open System
open Cqrsexy.DomainMessages

type ApplyForLeave = {
    LeaveId: Guid;
    EmployeeId: Guid;
    From: DateTime;
    To: DateTime;
} with interface ICommand

type AppliedForLeave = {
    LeaveEntryId: Guid;
    From: DateTime;
    To: DateTime;
} with interface IEvent

type HireEmployee = {
    EmployeeId: Guid;
    Name: String;
    HireDate: DateTime;
} with interface ICommand

type EmployeeHired = {
    EmployeeId: Guid;
    Name: String;
    Date: DateTime;
} with interface IEvent

type ApproveLeave = {
    EmployeeId: Guid;
    LeaveId: Guid;
    ApproverId: Guid;
} with interface ICommand

type LeaveApproved = {
    LeaveId: Guid;
    ApproverId: Guid;
} with interface IEvent

