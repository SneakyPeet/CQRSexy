namespace Cqrsexy.Events

open System

//[<Interface>]
//type IEvent = 
//    abstract Version : int with get

[<Interface>]
type IEvent = interface end


//type LeaveEntryCreated = {
//    Version: int;
//    EmployeeId: Guid;
//    StartDate: DateTime;
//    EndDate: DateTime;
//    LeaveType: String;
//} with 
//    interface IEvent with
//        member this.Version
//            with get () = this.Version

type LeaveEntryCreated = {
    EmployeeId: Guid;
    StartDate: DateTime;
    EndDate: DateTime;
    LeaveType: String;
} with interface IEvent
