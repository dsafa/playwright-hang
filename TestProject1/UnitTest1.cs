using Microsoft.Playwright;

namespace TestProject1
{
    public class Tests : PageTest
    {
        [Test]
        public async Task OutOfMemory()
        {
            var testFile = new UriBuilder
            {
                Path = Path.GetFullPath("test.html", AppContext.BaseDirectory),
                Scheme = "file",
            };

            await Page.GotoAsync(testFile.Uri.ToString());

            await Page.GetByRole(AriaRole.Button, new() { Name = "out of memory" }).ClickAsync();

            await Task.Delay(1_000);
            await Expect(Page.GetByText("child")).ToBeVisibleAsync();
        }
    }
}
