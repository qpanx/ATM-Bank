using System;

public class cardHolder
{
    string cardNUM;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNUM = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public string getCardNum()
    {
        return cardNUM;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getbalance()
    {
        return balance;
    }

    public void setNum(string newcardNum)
    {
        cardNUM = newcardNum;
    }
    public void setpin(int newpin)
    { pin = newpin; }
    public void setfirstName(string newfirstName) { firstName = newfirstName; }
    public void setlastName(string newlastName) { lastName = newlastName; }
    public void setbalance(double newbalance) { balance = newbalance; }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. withdraw");
            Console.WriteLine("3. show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setbalance(currentUser.getbalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is:  " + currentUser.getbalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would like to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());
            if (currentUser.getbalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setbalance(currentUser.getbalance() - withdraw);
                Console.WriteLine("You're good to go! Thank you :) ");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getbalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5784372953", 9876, "Ahmed", "Maarouf", 925725.54));
        cardHolders.Add(new cardHolder("6547826864", 1234, "John", "Cena", 73.31));
        cardHolders.Add(new cardHolder("8934712874", 1289, "Elon", "Mask", 40.1));

        Console.WriteLine("Welcome to AhmedATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNUM == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userpin = 0;
        while (true)
        {
            try
            {
                userpin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userpin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :) (Made with Love By Ahmed Maarouf)");
    }

}