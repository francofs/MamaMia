using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Order
    {
        private List<IServable> m_Servings = new List<IServable>();

        public void AddServable(IServable serving)
        {
            m_Servings.Add(serving);
            m_Servings.Sort();
        }
        
        public string OrderSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int counter = 0;
                List<IServable> listedServings = new List<IServable>(); //To control which servings we already displayed on the summary

                foreach (IServable servable in m_Servings)
                {
                    //In this case, serving already shown using the multplier i.e. (x2), so, jump to next serving
                    if (listedServings.Contains(servable) && servable.CanServeMoreThanOnce())
                        continue;

                    int numberOfServables = m_Servings.Count(s => s.Equals(servable));

                    if (counter > 0)
                        sb.Append(", ");

                    //If the same serving is listed, we do the logic to use the multiplier instead of
                    //repeating the same serving several times.
                    if (numberOfServables > 1)
                    {
                        //In this if the serving can be served more than once, we use the multiplier
                        if (servable.CanServeMoreThanOnce())
                        {
                            sb.Append(servable.Serve()).Append("(x").Append(numberOfServables).Append(")");
                        }
                        else
                        {
                            //If the serving cannot be served more than once, we display it only one time and the remaining as errors
                            if (!listedServings.Contains(servable))
                            {
                                sb.Append(servable.Serve());
                            }
                            else
                            {
                                sb.Append("error");
                            }
                        }
                    }
                    else
                    {
                        //Serve servings uniquely
                        sb.Append(servable.Serve());
                    }

                    //Serving has been listed for the records
                    listedServings.Add(servable);
                    counter++;
                }

                return sb.ToString();
            }
        }
    }
}
