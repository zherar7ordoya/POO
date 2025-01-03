﻿/* TIM COREY
 * C# Events - Creating and Consuming Events in Your Application
 * https://youtu.be/-1cftB9q1kQ */

using DemoLibrary;
using System;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        readonly Customer customer = new Customer();

        public Dashboard()
        {
            InitializeComponent();
            LoadTestingData();
            WireUpForm();
        }

        private void LoadTestingData()
        {
            customer.CustomerName = "Tim Corey";
            customer.CheckingAccount = new Account();
            customer.SavingsAccount = new Account();

            customer.CheckingAccount.AccountName = "Tim's Checking Account";
            customer.SavingsAccount.AccountName = "Tim's Savings Account";

            customer.CheckingAccount.AddDeposit("Initial Balance", 155.43M);
            customer.SavingsAccount.AddDeposit("Initial Balance", 98.45M);
        }

        private void WireUpForm()
        {
            customerText.Text = customer.CustomerName;
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);

            customer.CheckingAccount.TransactionApprovedEvent += CheckingAccount_TransactionApprovedEvent;
            customer.SavingsAccount.TransactionApprovedEvent += SavingsAccount_TransactionApprovedEvent;
            customer.CheckingAccount.OverdraftEvent += CheckingAccount_OverdraftEvent;
        }

        private void CheckingAccount_OverdraftEvent(object sender, OverdraftEventArgs e)
        {
            errorMessage.Text = $"You had and overdraft protection transfer of {string.Format("{0:C2}", e.AmountOverdrafted)}";
            e.CancelTransaction = denyOverdraft.Checked;
            errorMessage.Visible = true;
        }

        private void SavingsAccount_TransactionApprovedEvent(object sender, string e)
        {
            savingsTransactions.DataSource = null;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);
        }

        private void CheckingAccount_TransactionApprovedEvent(object sender, string e)
        {
            checkingTransactions.DataSource = null;
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
        }

        private void RecordTransactionsButton_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(customer);
            transactions.Show();
        }

        private void ErrorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }
    }
}
