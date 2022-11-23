using System;


	public class ATM
	{
		public int userCash = 10000;
		public string userPin = "1234";
		public OperationType operationType;
		public LanguageType languageType;

		public virtual void Start()
		{
			Console.WriteLine("Welcome to Nneka's Bank! Bank of the Rich.");

			var isPinCorrect = PinCheck();

			if (isPinCorrect)
			{

				Console.WriteLine("Select your language \n1. Native \n2. English \n3. Pidgin");
				var languageInput = Console.ReadLine();
				var languageSelected = Int32.Parse(languageInput);

				languageType = (LanguageType)languageSelected;

				Console.WriteLine("Please select an operation \n1. Withdraw\n2. Check Balance\n3. Transfer");

                var operationInput = Console.ReadLine();
                var numberSelected = Int32.Parse(operationInput);

                operationType = (OperationType)numberSelected;

                Console.WriteLine(operationType);


                switch (operationType)
                {
                    case OperationType.Withdraw:
                        Withdraw();
                        break;
                    case OperationType.CheckBalance:
                        CheckBalance();
                        break;
                    case OperationType.Transfer:
                        Transfer();
                        break;
                }
            } else
			{
				Console.WriteLine("PIN incorrect. Enter a valid PIN");
				Restart();
			}
			
		}

		// Main Logic

		private bool PinCheck()
		{
			Console.WriteLine("Enter your ATM Pin.");
			var atmInput = Console.ReadLine();

			if (atmInput == userPin)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void CheckBalance()
		{
			CheckBalanceOperation();
		}

		private void Transfer()
		{
			Console.WriteLine("Enter the bank name");
			var bankName = Console.ReadLine();

			Console.WriteLine("Enter account number");
			var accountNumber = Console.ReadLine();

            Console.WriteLine("Enter amount");
            var amountInput = Console.ReadLine();
			var amount = Int32.Parse(amountInput);

			TransferOperation(amount, bankName, accountNumber);
        }

        private void Withdraw()
		{
			Console.WriteLine("How much do you want to withdraw?");
			var withdrawInput = Console.ReadLine();
			var withdrawAmount = Int32.Parse(withdrawInput);

			WithdrawOperation(withdrawAmount);
		}

		// Operation Logic

		private void CheckBalanceOperation()
		{
            Console.WriteLine($"Your balance is ₦{userCash} and your pin is {userPin}");

            Restart();
        }

		private void TransferOperation(int transferAmount, string bankName, string accountNumber)
		{
			if (transferAmount > userCash)
			{
				Console.WriteLine("Insufficient funds!");
			}
			else
			{
                userCash -= transferAmount;
                Console.WriteLine($"Transfer successful to {accountNumber} - {bankName}");
                Console.WriteLine($"You have ₦{userCash} left in your account.");
            }

			Restart();
		}

		private void WithdrawOperation(int amount)
		{
			if (amount > userCash)
			{
				Console.WriteLine("Insufficient funds!");
			}
			else
			{
				userCash -= amount;
				Console.WriteLine("Withdrawal successful. Please take your cash!");
				Console.WriteLine($"You have ₦{userCash} left in your account.");
			}

			Restart();
		}

		private void Restart()
		{
			Console.WriteLine("Do you want to carry out another operation? Y/N");
			var input = Console.ReadLine();

			if (input.ToUpper() == "Y")
			{
				Start();
			}
			else
			{
				Console.WriteLine("Please take your card! Have a lovely day!");
			}
		}

		private string GenerateLanguageText()
		{
			switch (languageType)
			{
				case LanguageType.Native:
					return "";
				case LanguageType.English:
					return "";
				case LanguageType.Pidgin:
					return "";
			}

			return "";
		}
	}

	public enum OperationType
	{
		Withdraw = 1, CheckBalance = 2, Transfer = 3 
	}

	public enum LanguageType
	{
		Native = 1, English = 2, Pidgin = 3
	}


