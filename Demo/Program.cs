using BLL.EntityManager;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get All WALLETS
            var resWallets = WalletManger.GetWalletsList();
            Console.WriteLine("Wallet Data");
            Console.WriteLine("==================================");
            foreach (var w in resWallets) {
                Console.WriteLine(w);
            }
            Console.WriteLine("==================================");
            Console.WriteLine("Transactions Data");
            Console.WriteLine("==================================");
            //Get All Transactions
            var resTrans = TransactionManger.GetTransList();
            foreach (var t in resTrans)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("==================================");
            //Add New Wallet Item 
            Console.WriteLine("Add New Wallet");
            var NewWallet = WalletManger.ADD("Rawan", 8000);
            Console.WriteLine(NewWallet);

            //Add New Trans
            Console.WriteLine("Add New Transactions");
            DateTime date1 = new DateTime(2015, 12, 25);
            var NewTrans = TransactionManger.Add(4, date1, 3500, "Deposit");
            Console.WriteLine(NewTrans);

            //Update Trans
            Console.WriteLine("Update Transactions");
            DateTime date2 = new DateTime(2023, 5, 25);
            var UpdateTrans = TransactionManger.Update(2, date2, 500, "Withdraw");
            Console.WriteLine(UpdateTrans);

            //Update Wallet
            Console.WriteLine("Update Wallet");
            var UpdateWallet = WalletManger.Update(2, "Shimaa", 7500);
            Console.WriteLine(UpdateWallet);

            //Delete Trans
            Console.WriteLine("Trans Delete");
            var TransDel = TransactionManger.Delete(2);
            Console.WriteLine(TransDel);

            //Wallet Delete 
            Console.WriteLine("Wallet Delete");
            var WalletDel = WalletManger.Delete(5);
            Console.WriteLine(WalletDel);

            //ADD New Wallet Avoid Sql injection
            Console.WriteLine("ADD Wallet");
            int res = WalletManger.ADD2("Salma", 2500);
            Console.WriteLine(res);


            //Add New Trans Avoid Sql injection
            Console.WriteLine("Add New Transactions");
            DateTime date3 = new DateTime(2015, 2, 5);
            var NewTrans2 = TransactionManger.Add(4, date3, 5500, "Deposit");
            Console.WriteLine(NewTrans2);

            //Update Trans Avoid Sql injection
            Console.WriteLine("Update Transactions");
            DateTime date4 = new DateTime(2024, 8, 15);
            var UpdateTrans2 = TransactionManger.Update(2, date4, 500, "Withdraw");
            Console.WriteLine(UpdateTrans2);

            //Update Wallet Avoid Sql injection
            Console.WriteLine("Update Wallet");
            var UpdateWallet2 = WalletManger.Update(1, "Mahmed", 75000);
            Console.WriteLine(UpdateWallet2);

            //Delete Trans Avoid Sql injection
            Console.WriteLine("Trans Delete");
            var TransDel2 = TransactionManger.Delete(3);
            Console.WriteLine(TransDel2);

            //Wallet Delete Avoid Sql injection
            Console.WriteLine("Wallet Delete");
            var WalletDel2 = WalletManger.Delete(6);
            Console.WriteLine(WalletDel2);



        }
    }
}
