using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;

[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{
    [Test]
    public async Task Open_Page()
    {
        //open the url: https://finance.vietstock.vn/doanh-nghiep-a-z?page=1 //
        await Page.GotoAsync("https://finance.vietstock.vn/doanh-nghiep-a-z?page=1");        
    }
    public async Task Query_Table()
    {
        //select the table content companies info
        var companiesTableLocator = Page.Locator(selector: (".table-responsive"));
        //select rows from the companiesTable
        var rows = companiesTableLocator.Locator("tr");
        //counting the amount of row in table
        var count = await rows.CountAsync();
        //write the text content in table
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(await rows.Nth(i).TextContentAsync());
        }
    }
}