using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conferenceware.Models;

namespace Conferenceware.Tests.Models
{
    /// <summary>
    /// Summary description for RepositoryTimeSlotTests
    /// </summary>
    [TestClass]
    public class RepositoryTimeSlotTests
    {
        /// <summary
        /// Repository to use for testing
        /// </summary>
        private readonly IRepository _repository = new TestRepository();
        //private IRepository _repository = new ConferencewareRepository();

        /// <summary>
        /// Generates a simple one hour timeslot.
        /// </summary>
        /// <returns>The timeslot. duh.</returns>
        private static TimeSlot GenerateTimeSlot1()
        {
            return new TimeSlot
            {
                start_time = new DateTime(2010, 2, 20, 12, 0, 0),
                end_time = new DateTime(2010, 2, 20, 13, 0, 0)
            };
        }

        /// <summary>
        /// Test to make sure we can insert into the db.
        /// </summary>
        [TestMethod]
        public void CreateAndInsertTimeSlot()
        {
            TimeSlot ts = GenerateTimeSlot1();
            _repository.AddTimeSlot(ts);
            _repository.Save();
            Assert.AreEqual(2, _repository.GetAllTimeSlots().Count());
        }
    }
}
