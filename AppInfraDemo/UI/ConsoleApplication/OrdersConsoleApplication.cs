using Contracts.Sales;

namespace ConsoleApplication
{
	class OrdersConsoleApplication
	{
		private readonly IConsole console;
		private readonly IOrderingService orderingService;

		public OrdersConsoleApplication(IConsole console, IOrderingService orderingService)
		{
			this.console = console;
			this.orderingService = orderingService;
		}

		public void ShowAllOrders()
		{
			console.WriteLine("OrdersConsole: Show all orders function");
			string customerName = console.AskInput("Enter customer last name: ");

			SalesOrderInfo[] orders = orderingService.GetOrdersInfo(customerName);

			console.WriteLine($"Orders for customer {customerName}: "); //Test data: Abel | Smith | Adams
			foreach (SalesOrderInfo salesOrderInfo in orders)
			{
				console.WriteEntity(salesOrderInfo);
			}
		}
	}
}