using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiAppTest
{
    public class UnitTest1
    {
        private ProductsService ps = new();

        [Fact]
        public async void Test1()
        {
            var imageBytes = await File.ReadAllBytesAsync("C:\\Users\\endri\\Downloads\\settings.png");
            var product = new ProductWrite("testProd", "testDescription", 250, "image", imageBytes);
            var res = await ps.AddProduct(product);

            Assert.True(res);
        }

        [Fact]
        public async void Test2()
        {
            var res = await ps.DeleteProduct(3);
            Assert.True(res);
        }
    }
}