using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeidoDbWebApiConsumerSPA.Models;
using SeidoDbWebApiConsumerSPA.Services;

namespace SeidoDbWebApiConsumerSPA.Pages
{
    public class OrdersModel : PageModel
    {
        ISeidoDbHttpService _httpService;
        public Customer Customer { get; private set; }

        public async Task OnGet(string CustomerId)
        {
            var custID = Guid.Parse(CustomerId);
            Customer = (Customer) await _httpService.GetCustomerAsync(custID);
        }

        public OrdersModel(ISeidoDbHttpService service)
        {
            this._httpService = new SeidoDbHttpService();// service;
        }
    }
}
