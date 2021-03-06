using System.Linq;
using VehicleInsurance.Enum;
using VehicleInsurance.Interfaces;
using VehicleInsurance.Model;

namespace VehicleInsurance.BusinessRules.CalculationRules
{
    public class DriverOccupationRule : ICalculate
    {
        /// <summary>
        ///If there is driver who is a Chauffeur on the policy increase the premium by 10%.
        ///If there is driver who is an Accountant on the policy decrease the premium by 10%.
        /// </summary>
        /// <param name="policy"></param>
        /// <param name="premium"></param>
        /// <returns></returns>
        public decimal ImplementRule(Policy policy, decimal premium)
        {
            
            if (policy.DriversOnPolicy.Any(d => d.Occupation.JobTitle.Equals(OccupationEnum.Accountant)))
            {

                premium -= premium * 0.1m;
            }

            
            else if (policy.DriversOnPolicy.Any(d => d.Occupation.JobTitle.Equals(OccupationEnum.Chauffeur)))
            {
                premium += premium * 0.1m;
            }

            
            else if (policy.DriversOnPolicy.Any(d => d.Occupation.JobTitle.Equals(OccupationEnum.Other)))
            {
                return premium;
            }

            return premium;
        }
    }
}
