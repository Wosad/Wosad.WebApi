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
    ///Loads.ASCE710.Gravity.Live Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class LoadsASCE710GravityLiveController : ApiController
    {
        ///<summary> Calculates Minimum uniformly distributed live load (psf) - ASCE7-10. </summary>
        ///<param name="SpaceOccupancyId"> description of space for calculation of live loads</param>
        ///<returns> Uniformly distributed live load </returns>

        [HttpGet]
        [Route("Loads/ASCE7_10/Gravity/Live/UniformLiveLoad_q_L")]
        public Dictionary<string, object> UniformLiveLoad_q_L(String SpaceOccupancyId)
        {
            return WosadLoads.ASCE7_10.Gravity.Live.UniformLiveLoad_q_L(SpaceOccupancyId);
        }

    }

}

