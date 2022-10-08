using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.Services;

public class CustomerService : Customer.CustomerBase
{
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(ILogger<CustomerService> logger)
    {
        _logger = logger;
    }

    public override Task<CustomerModel> GetCustomerInfo(
        CustomerLookupModel request, 
        ServerCallContext context)
    {
        CustomerModel output = new ();
        
        if(request.UserId == 1)
        {
            output.FirstName = "Jacek";
            output.LastName = "Kowalski";
        }
        else
        {
            output.FirstName = "Tomasz";
            output.LastName = "Nowak";
        }

        return Task.FromResult(output);
    }

    public override async Task GetNewCustomer(
        NewCustomerRequest request, 
        IServerStreamWriter<CustomerModel> responseStream, 
        ServerCallContext context)
    {
        var customers = new List<CustomerModel>
        {
            new CustomerModel
            {
                FirstName = "Janek",
                LastName = "Kamionka",
                Age = 32,
                EmailAddress = "JKamionka@wp.pl",
                IsAlive = true
            }
        };

        foreach (var customer in customers)
        {
            await responseStream.WriteAsync(customer);
        }
    }
}