using System;
using System.Collections.Generic;
using Cqrsexy.Domain.LeaveApplication;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cqrsexy.Architecture.Tests
{
    /// <summary>
    /// See https://lostechies.com/gabrielschenker/2015/07/13/event-sourcing-applied-the-repository/
    /// </summary>
    [TestFixture]
    public class EventDeserializationTests
    {
        [Test]
        public void DeserialiseEventKnownFSharpTypeIsKnow()
        {
            var evt = new AppliedForLeave(Guid.NewGuid(), DateTime.Now, DateTime.UtcNow);
            var json = JsonConvert.SerializeObject(evt);
            var des = JsonConvert.DeserializeObject<AppliedForLeave>(json);
            Assert.AreEqual(evt, des);
        }

        [Test]
        public void DeserialiseEventKnownFSharpTypeIsKnowInvered()
        {
            var evt = new AppliedForLeave(Guid.NewGuid(), DateTime.Now, DateTime.UtcNow);
            var json = JsonConvert.SerializeObject(evt);
            var eventHeader = new Dictionary<string, string>
                           {
                               { "EventClrType", evt.GetType().AssemblyQualifiedName }
                           };
            var metaData = JsonConvert.SerializeObject(eventHeader);

            var eventName = JObject.Parse(metaData).Property("EventClrType").Value.ToString();
            var eventType = Type.GetType(eventName);
            var des = JsonConvert.DeserializeObject(json, eventType);
            Assert.AreEqual(evt, des);
        }

    }

    
}
