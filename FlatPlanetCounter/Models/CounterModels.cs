using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlatPlanetCounter.Models;
using FlatPlanetDAL;

namespace FlatPlanetCounter.Models
{
    public class CounterModels
    {
        public int CounterLimit { get { return 10; } }
        public int Counter { get; set; }
        public string Message { get; set; }


        private CounterDAL CounterDAL;

        public CounterModels()
        {
            this.CounterDAL = new CounterDAL();
        }


        public void CounterInsert(CounterModels prmCounter)
        {
            try
            {
                if (prmCounter.Counter > this.CounterLimit) throw new Exception("Failed to process your request because the Counter value exceeded upper limit.");

                if (prmCounter.Counter > 0)
                {
                    this.CounterDAL.CounterInsert(prmCounter.Counter);    //call DAL method to insert data into database

                    prmCounter.Message = "Successfully inserted counter value " + prmCounter.Counter + " into the database.";
                }
                else
                {
                    prmCounter.Counter = 0;
                    prmCounter.Message = "Waiting for the user to click the button...";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}