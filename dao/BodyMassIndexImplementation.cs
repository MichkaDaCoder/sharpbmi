using SharpBMI.model;
using SharpBMI.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBMI.dao
{
    class BodyMassIndexImplementation : GenericImpl
    {
        int index = 0;

        public BodyMassIndexImplementation()
        {
            connect();
        }

        public int add(BodyMassIndex bmi)
        {
            int index = createSQLInsert(FormUtils.loadConfigs("TABLE_BMI"), parametres(bmi));
            return index;
        }

        public bool delete(BodyMassIndex bmi)
        {
            bool index = createSQLDelete(FormUtils.loadConfigs("TABLE_BMI"), singleParam(bmi));
            return index;
        }

        public Dictionary<String, Object> parametres(BodyMassIndex bmi)
        {
            Dictionary<String, object> d = new Dictionary<String, Object>()
             {
                    {"@Date_Bmi",DateTime.Now.Date},
                    {"@Weight",bmi.getWeight()},
                    {"@Height",bmi.getHeight()},
                    {"@Value",bmi.getResult()},
                    {"@Evaluation",bmi.getEvaluation()},
             };
            return d;
        }

        public Dictionary<String, Object> singleParam(BodyMassIndex bmi)
        {
            Dictionary<String, Object> d = new Dictionary<string, object>()
            {

                {"@DateBmi",bmi.getDateBmi()}
            };
            return d;
        }
    }
}
