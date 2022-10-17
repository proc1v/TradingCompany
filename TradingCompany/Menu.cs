using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany
{
    public class Menu
    {
		public void showMenu()
		{
			char userInput;

			do
			{
				showMainMenu();
				userInput = Console.ReadLine()[0];
				safeHandleMainMenuInput(userInput);

			} while (userInput != 'q');
		}
		private void showMainMenu()
		{
			Console.Clear();
			Console.WriteLine("Welcome to Trading Company!");
			Console.WriteLine("\nPlease select an option:\n");
			Console.WriteLine("p - Product CRUD");
			Console.WriteLine("r - Review CRUD");
			Console.WriteLine("q - Exit.");
			Console.Write("Your choice >> ");
		}

		private void safeHandleMainMenuInput(char userInput)
        {
            try
            {
				handleMainMenuInput(userInput);
			}
			catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
            }
        }

        private void handleMainMenuInput(char userInput)
		{
			switch (userInput)
			{
				case 'p':
					showProductMenu();
					break;
				case 'r':
					showReviewMenu();
					break;
				case 'q':
					break;
				default:
					Console.WriteLine("Wrong command selected");
					break;
			}
		}

        private void showReviewMenu()
        {
			char userInput;
			Console.Clear();

			do
			{
				Console.WriteLine("Review CRUD");
				Console.WriteLine("\nPlease select an option:\n");
				Console.WriteLine("1 - Create new Review");
				Console.WriteLine("2 - Print all Reviews");
				Console.WriteLine("3 - Delete Review");
				Console.WriteLine("q - Return to main menu.");
				Console.Write("Your choice >> ");

				userInput = char.Parse(Console.ReadLine());
				safeHandleReviewMenuInput(userInput);
			}
			while (userInput != 'q');
		}

        private void safeHandleReviewMenuInput(char userInput)
        {
			try
			{
				handleReviewMenuInput(userInput);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

        private void handleReviewMenuInput(char userInput)
		{
			switch (userInput)
			{
				case '1':
					Command.ReviewsCommand.CreateReview();
					break;
				case '2':
					Command.ReviewsCommand.PrintAllReviews();
					break;
				case '3':
					Command.ReviewsCommand.DeleteReview();
					break;
				case 'q':
					break;
				default:
					Console.WriteLine("Wrong command selected");
					break;
			}
		}

        private void showProductMenu()
        {
			char userInput;
			Console.Clear();

			do
			{
				Console.WriteLine("Product CRUD");
				Console.WriteLine("\nPlease select an option:\n");
				Console.WriteLine("1 - Create new Product");
				Console.WriteLine("2 - Print all Products");
				Console.WriteLine("3 - Update existing Product");
				Console.WriteLine("4 - Delete Product");
				Console.WriteLine("q - Return to main menu.");
				Console.Write("Your choice >> ");

				userInput = char.Parse(Console.ReadLine());
				safeHandleProductMenuInput(userInput);
			}
			while (userInput != 'q');
        }

        private void safeHandleProductMenuInput(char userInput)
        {
			try
			{
				handleProductMenuInput(userInput);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

        private void handleProductMenuInput(char userInput)
        {
            switch (userInput)
            {
				case '1':
					Command.ProductsCommand.CreateProduct();
					break;
				case '2':
					Command.ProductsCommand.PrintAllProducts();
					break;
				case '3':
					Command.ProductsCommand.UpdateProduct();
					break;
				case '4':
					Command.ProductsCommand.DeleteProduct();
					break;
				case 'q':
					break;
				default:
					Console.WriteLine("Wrong command selected");
					break;

			}
        }
    }
}
