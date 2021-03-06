using System.Collections.Generic;
using VehicleInsurance.Interfaces;
using VehicleInsurance.Model;

namespace VehicleInsurance.Rules
{
    public class DeclineRules
   {
       private readonly List<IDecline> rules;

       public DeclineRules(List<IDecline> rules)
       {
           this.rules = rules;
       }

        /// <summary>
        /// Implements each rule and checks for a decline reason.
        /// Returns the result.
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        public Result ImplementRules(Policy policy)
       {
           Result result = new Result(string.Empty, true);

           foreach (var rule in rules)
           {
               result = rule.ImplementRule(policy);

               if (!result.IsSuccessful)
               {
                   return result;
               }
           }

           return result;
       }
   }
}
