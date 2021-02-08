﻿using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense { Details = "Test", Amount = 1400 };
            manager.HandleExpense(expense);
        }
    }

    class Expense
    {
        public string Details { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if(Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount < 1000)
            {
                Console.WriteLine("VicePresident handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
        }
    }
}
