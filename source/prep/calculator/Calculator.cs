using System;
using System.Data;

namespace prep.calculator
{
    public class Calculator
    {
        private IDbConnection dbConnection;
        public Calculator(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public int add(int i, int i1)
        {
            if (i * i1 < 0)
                throw new ArgumentException();

            dbConnection.Open();
            return i + i1;
        }
    }
}