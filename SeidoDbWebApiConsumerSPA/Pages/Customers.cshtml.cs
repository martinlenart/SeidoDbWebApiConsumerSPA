using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeidoDbWebApiConsumerSPA.Models;
using SeidoDbWebApiConsumerSPA.Services;

namespace SeidoDbWebApiConsumerSPA.Pages
{
    public class CustomersModel : PageModel
    {
        ISeidoDbHttpService _httpService;

        public IEnumerable<ICustomer> Customers { get; private set; }
        
        public async Task OnGet()
        {
            Customers = await _httpService.GetCustomersAsync();
            Customers = Customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).Take(10);
        }
        public async Task<IActionResult> OnPostDelete(string id)
        {
            var CustId = new Guid(id);
            await _httpService.DeleteCustomerAsync(CustId);

            return RedirectToPage("/customers");
        }

        #region Create
        [BindProperty]
        public Customer NewCustomer { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if ((NewCustomer != null) && ModelState.IsValid)
            {
                await _httpService.CreateCustomerAsync(NewCustomer);
            }
            return RedirectToPage("/customers");
        }
        #endregion

        #region Update
        [BindProperty]
        public Customer UpdatedCustomer { get; set; }

        public async Task OnPostEdit(string id)
        {
            var CustId = new Guid(id);
            UpdatedCustomer = (Customer) await _httpService.GetCustomerAsync(CustId);
        }

        public async Task<IActionResult> OnPostUpdate(string id)
        {
            var CustId = new Guid(id);
            var cust = (Customer) await _httpService.GetCustomerAsync(CustId);

            //Set the updated values. Guid of CustomerToUpdate is wrong as it is a newly created object
            cust.Copy(UpdatedCustomer);
            await _httpService.UpdateCustomerAsync(cust);

            return RedirectToPage("/customers");
        }
        #endregion

        public CustomersModel()//ISeidoDbHttpService service)
        {
            this._httpService = new SeidoDbHttpService();// service;
        }
    }
}
