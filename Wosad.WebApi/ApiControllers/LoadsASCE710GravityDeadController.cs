using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WosadLoads = Loads;

namespace Wosad.WebApi.Controllers
{
    /// <summary>
    ///Loads.ASCE710.Gravity.Dead Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class LoadsASCE710GravityDeadController : ApiController
    {
        ///<summary> Calculates Building component weight per surface area of the component (psf) - ASCE7-10. </summary>
        ///<param name="ComponentId"> building component id (name) </param>
        ///<param name="ComponentOption1"> building component subtype (option1) </param>
        ///<param name="ComponentOption2"> building component subtype (option2) </param>
        ///<param name="ComponentValue"> building component numerical value</param>
        ///<returns> "Parameter name: q_D", Parameter description: Uniformly distributed component dead load </returns>

        [HttpGet]
        [Route("Loads/ASCE7_10/Gravity/Dead/ComponentWeight_q_D")]
        public Dictionary<string, object> ComponentWeight_q_D(String ComponentId, Double ComponentOption1, Double ComponentOption2, Double ComponentValue)
        {
            return WosadLoads.ASCE7_10.Gravity.Dead.ComponentWeight_q_D(ComponentId, ComponentOption1, ComponentOption2, ComponentValue);
        }

    }

}

