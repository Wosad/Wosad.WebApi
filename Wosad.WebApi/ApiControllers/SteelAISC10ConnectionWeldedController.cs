using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WosadSteel = Steel;

namespace Wosad.WebApi.Controllers
{
    /// <summary>
    ///Steel.AISC10.Connection.Welded Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10ConnectionWeldedController : ApiController
    {
        ///<summary> Calculates Concentrically loaded fillet weld group strength </summary>
        ///<param name="WeldGroupPattern"> Weld group pattern type </param>
        ///<param name="l_transv"> Length of transversely loaded welds </param>
        ///<param name="l_longit"> Length of longitudinally loaded welds </param>
        ///<param name="w_weld"> Size of weld leg </param>
        ///<param name="F_EXX"> Filler metal classification strength </param>
        ///<param name="theta"> Angle of load from vertical </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Welded/FilletWeldGroupConcentricLoadStrength")]
        public Dictionary<string, object> FilletWeldGroupConcentricLoadStrength(String WeldGroupPattern, Double l_transv, Double l_longit, Double w_weld, Double F_EXX, Double theta)
        {
            return WosadSteel.AISC_10.Connection.Welded.FilletWeldGroupConcentricLoadStrength(WeldGroupPattern, l_transv, l_longit, w_weld, F_EXX, theta);
        }

        ///<summary> Calculates Eccentrically loaded fillet weld group strength </summary>
        ///<param name="C_WeldGroup"> Coefficient for eccentrically loaded weld group </param>
        ///<param name="l"> Length of connection or weld </param>
        ///<param name="w_weld"> Size of fillet weld leg </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Welded/FilletWeldGroupEccentricLoadStrength")]
        public Dictionary<string, object> FilletWeldGroupEccentricLoadStrength(Double C_WeldGroup, Double l, Double w_weld)
        {
            return WosadSteel.AISC_10.Connection.Welded.FilletWeldGroupEccentricLoadStrength(C_WeldGroup, l, w_weld);
        }

        ///<summary> Calculates Eccentrically loaded weld group coefficient </summary>
        ///<param name="WeldGroupPattern"> Weld group pattern type </param>
        ///<param name="l_Weld_horizontal"> Weld group horizontal dimension </param>
        ///<param name="l_Weld_vertical"> Weld group vertical dimension </param>
        ///<param name="e_group"> Connection bolt or weld group eccentricity </param>
        ///<param name="theta"> Angle of loading for eccentric bolt or weld group </param>
        ///<param name="w_weld"> Size of weld leg </param>
        ///<param name="F_EXX"> Filler metal classification strength </param>
        ///<param name="IsLoadOutOfPlane"> Indicates whether the load on bolt group is not in the plane of welds. In such case eccentricity is measured normal to the plane of welds. </param>
        ///<returns>
        /// name="C_WeldGroup" Coefficient for eccentrically loaded weld group 
        /// name="phiR_n" Ultimate load value at given angle and eccentricity 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Welded/FilletWeldGroupCoefficient")]
        public Dictionary<string, object> FilletWeldGroupCoefficient(String WeldGroupPattern, Double l_Weld_horizontal, Double l_Weld_vertical, Double e_group, Double theta, Double w_weld, Double F_EXX, Boolean IsLoadOutOfPlane)
        {
            return WosadSteel.AISC_10.Connection.Welded.FilletWeldGroupCoefficient(WeldGroupPattern, l_Weld_horizontal, l_Weld_vertical, e_group, theta, w_weld, F_EXX, IsLoadOutOfPlane);
        }

        ///<summary> Calculates Weld strength </summary>
        ///<param name="l_weld"> Weld length </param>
        ///<param name="WeldType"> Weld type </param>
        ///<param name="WeldLoadTypeId"> Type of load on weld under consideration </param>
        ///<param name="t_weld"> Weld throat thickness </param>
        ///<param name="F_EXX"> Filler metal classification strength </param>
        ///<param name="A_nBase"> Area of base metal in a welded connection </param>
        ///<param name="F_y"> Base metal specified minimum yield stress </param>
        ///<param name="F_u"> Base metal tensile strength </param>
        ///<param name="theta"> Angle of loading for eccentric bolt or weld group </param>
        ///<param name="IgnoreBaseMetalChecks"> Indicates whether weld strength calculation should include base metal checks </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Welded/WeldStrength")]
        public Dictionary<string, object> WeldStrength(Double l_weld, String WeldType, String WeldLoadTypeId, Double t_weld, Double F_EXX = 70, Double A_nBase = 0, Double F_y = 36, Double F_u = 58, Double theta = 0, Boolean IgnoreBaseMetalChecks = false)
        {
            return WosadSteel.AISC_10.Connection.Welded.WeldStrength(l_weld, WeldType, WeldLoadTypeId, t_weld, F_EXX, A_nBase, F_y, F_u, theta, IgnoreBaseMetalChecks);
        }

    }

}

