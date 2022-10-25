using Web_Teacher;
using System;
using NUnit.Framework;
using Teacher_Service;
using Web_Teacher.Models;
using System.Linq;

namespace UnitTests
{
    public class TeacherUnitTest
    {
        ITeacher_Service teacher_Service;

        [SetUp]
        public void SetUp(ITeacher_Service _Service)
        {
            this.teacher_Service = _Service;
        }

        [Test]
        public void FilterTeacherById()
        {
            var id = 2;

            var filter = teacher_Service.GetTeacher(id);

            Assert.That(filter, Is.EqualTo(teacher_Service.GetAllTeachers().Where(x => x.Id == 2)));
        }
    }
}
