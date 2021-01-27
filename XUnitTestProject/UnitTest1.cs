using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            var post = new Post() { Title = "Test Title 3", Description = "Test Description 3", CategoryId = 2, CreatedDate = DateTime.Now };

            //Act  
            var data = await controller.AddPost(post);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
