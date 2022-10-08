using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

var input = new HelloRequest { Name = "Mateusz" };

var channel = GrpcChannel.ForAddress("https://localhost:7168");
//var client = new Greeter.GreeterClient(channel);
var client = new Customer.CustomerClient(channel);
//var reply = await client.SayHelloAsync(input);

var clientRequested = new CustomerLookupModel { UserId = 1 };

var reply = await client.GetCustomerInfoAsync(clientRequested);

Console.WriteLine($"{reply.FirstName} {reply.LastName}");
using (var call = client.GetNewCustomer(new NewCustomerRequest()))
{
    while (await call.ResponseStream.MoveNext(CancellationToken.None))
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName} {currentCustomer.Age} {currentCustomer.EmailAddress}");
    }
}

    Console.ReadLine();
