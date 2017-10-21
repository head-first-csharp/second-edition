using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beehive_Management_System
{
    class Queen : Bee
    {
        private Worker[] workers;
        private int shiftNumber = 0;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            return false;
        }

        public Queen(Worker[] workers)
            : base(275)
        {
            this.workers = workers;
        }

        public string WorkTheNextShift()
        {
            double totalConsumption = 0;
            for (int i = 0; i < workers.Length; i++)
                totalConsumption += workers[i].GetHoneyConsumption();
            totalConsumption += GetHoneyConsumption();

            // ... here’s where the original code for this method goes, minus the return statement

            shiftNumber++;
            string report = "Report for shift #" + shiftNumber + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].WorkOneShift())
                    report += "Worker #" + (i + 1) + " finished the job\r\n";
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                    report += "Worker #" + (i + 1) + " is not working\r\n";
                else
                    if (workers[i].ShiftsLeft > 0)
                        report += "Worker #" + (i + 1) + " is doing ‘" + workers[i].CurrentJob
                            + "’ for " + workers[i].ShiftsLeft + " more shifts\r\n";
                    else
                        report += "Worker #" + (i + 1) + " will be done with ‘"
                            + workers[i].CurrentJob + "’ after this shift\r\n";
            }

            // End of the original code for this method

            report += "Total honey consumption: " + totalConsumption + " units";
            return report;
        }

        public override double GetHoneyConsumption()
        {
            double consumption = 0;
            double largestWorkerConsumption = 0;
            int workersDoingJobs = 0;
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].GetHoneyConsumption() > largestWorkerConsumption)
                    largestWorkerConsumption = workers[i].GetHoneyConsumption();
                if (workers[i].ShiftsLeft > 0)
                    workersDoingJobs++;
            }
            consumption += largestWorkerConsumption;
            if (workersDoingJobs >= 3)
                consumption += 30;
            else
                consumption += 20;
            return consumption;
        }
    }
}