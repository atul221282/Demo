﻿namespace AccountAtAGlance.Model.Repository
{
    public interface IAccountRepository
    {
        BrokerageAccount GetAccount(string acctNumber);
        BrokerageAccount GetAccount(int id);
        Customer GetCustomer(string custId);
    }
}