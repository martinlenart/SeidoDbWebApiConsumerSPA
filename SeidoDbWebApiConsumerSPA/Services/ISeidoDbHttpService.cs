using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SeidoDbWebApiConsumerSPA.Models;

namespace SeidoDbWebApiConsumerSPA.Services
{
    public interface ISeidoDbHttpService
    {
        Task<IEnumerable<ICustomer>> GetCustomersAsync();
        Task<ICustomer> GetCustomerAsync(Guid custId);

        Task<ICustomer> UpdateCustomerAsync(Customer cus);

        Task<ICustomer> CreateCustomerAsync(Customer cus);
        Task<ICustomer> DeleteCustomerAsync(Guid custId);
    }
}
