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
    ///Loads.ASCE710.General Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class LoadsASCE710GeneralController : ApiController
    {
        ///<summary> Calculates Selection of Building risk category - ASCE7-10 </summary>
        ///<param name="BuildingOccupancyId"> Occupancy description</param>
        ///<returns> "Parameter name: BuildingRiskCategory", Parameter description: Building risk category </returns>

        [HttpGet]
        [Route("Loads/ASCE7_10/General/BuildingRiskCategory")]
        public Dictionary<string, object> BuildingRiskCategory(String BuildingOccupancyId)
        {
            return WosadLoads.ASCE7_10.General.BuildingRiskCategory(BuildingOccupancyId);
        }

    }

}

