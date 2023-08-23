using Microsoft.AspNetCore.Mvc;
using Trains.API.Controllers;
using Xunit;

namespace Trains.API.Tests.Controller
{
    public class TrainControllerUnitTest
    {
        [Fact]
        public async void Task_GetUploaded_Document_Return_Success()
        {
            //Arrange  
            var controller = new TrainController();
            var documentName = "Document.txt";

            //Act  
            var data = await controller.GetUploadedDocument(documentName);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetUploaded_Document_Return_NotFound()
        {
            //Arrange  
            var controller = new TrainController();
            var documentName = "wrongDocumentName";

            //Act  
            var data = await controller.GetUploadedDocument(documentName);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }       
    }    
}
