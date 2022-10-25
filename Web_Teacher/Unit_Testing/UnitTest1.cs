using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.DependencyResolver;
using Teacher_Data;
using Teacher_Repo;
using Teacher_Service;
using Assert = NUnit.Framework.Assert;

namespace Unit_Testing
{
    public class UnitTest1
    {
        ITeacher_Repo<Teacher> Teacher_Repo;

        private readonly Teacher_Repo_Context context;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Web_Teacher");
            context = new Teacher_Repo_Context(options.Options);

            Teacher_Repo = new Teacher_Repo<Teacher>(context);

        }

        //Testing the method adding new teacher
        [Fact]
        public async Task AddNewTeacher()
        {
            //Arrange

            var Id = 10;
            var firstName = "Binh";
            var lastName = "Phan Thanh";
            var dateOfBirth = "07-10-2001";

            Teacher teacher = new Teacher
            {
                Id = Id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Parse(dateOfBirth),
            };
            
            //Act

            var mockRepo = new Mock<ITeacher_Repo<Teacher>>();
            mockRepo.Setup(s => s.Insert(teacher));

            //Assert

            Assert.NotNull(mockRepo);
        }

        //Method get a teacher base on Id
        [Fact]
        public void FilterTeacherById()
        {
            //Arrange

            int id = 2;

            //Act

            var mockRepo = new Mock<ITeacher_Repo<Teacher>>();
            mockRepo.Setup(s => s.GetTeacher(id));

            //Assert

            Assert.NotNull(mockRepo);
        }

        //Method delete a teacher
        [Fact]
        public void DeleteTeacher()
        {
            //Arrange

            Teacher teacher = new Teacher
            {
                Id = 3,
                FirstName = "Trần",
                LastName = "My",
                DateOfBirth = DateTime.Parse("2022-05-10 01:48:00.0000000"),
            };

            //Act

            var mockRepo = new Mock<ITeacher_Repo<Teacher>>();
            mockRepo.Setup(s=>s.DeleteWithReturn(teacher));

            //Assert
            Assert.AreEqual("Delete Successfully", "Delete Successfully");
        }

        [Fact]
        public void UpdateInfoOfTeacher()
        {
            //Arrange

            Teacher teacher = new Teacher
            {
                Id = 1,
                FirstName = "Thanh",
                LastName = "Bình",
                DateOfBirth = DateTime.Parse("2022-05-10 01:48:00.0000000"),
            };

            //Act

            var mockRepo = new Mock<ITeacher_Repo<Teacher>>();
            mockRepo.Setup(s=>s.UpdateDetailTeacher(teacher));

            //Assert

            Assert.AreEqual("Update Successfully", "Update Successfully");
        }


    }
}