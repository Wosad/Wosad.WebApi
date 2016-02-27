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
    ///Steel.AISC10.Combination Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10CombinationController : ApiController
    {
        ///<summary> Interaction ratio for the combination of forces </summary>
        ///<param name="CombinationCaseId"> Defines a type of interaction equation to be used </param>
        ///<param name="N_u"> Required axial strength </param>
        ///<param name="T_uTorsion"> Required torsional strength </param>
        ///<param name="M_ux"> Required flexural strength with respect to x-axis </param>
        ///<param name="M_uy"> Required flexural strength with respect to x-axis </param>
        ///<param name="V_ur"> Required shear strength resultant </param>
        ///<param name="phiN_n"> Compressive strength </param>
        ///<param name="phiT_nTorsion"> Torsional strength </param>
        ///<param name="phiM_nx"> Moment strength with respect to section x-axis </param>
        ///<param name="phiM_ny"> Moment strength with respect to section y-axis </param>
        ///<param name="phiV_nr"> Shear strength resultant </param>
        ///<returns name="InteractionRatio"> Interaction ratio </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Combination/InteractionRatio")]
        public Dictionary<string, object> InteractionRatio(String CombinationCaseId, Double N_u = 0, Double T_uTorsion = 0, Double M_ux = 0, Double M_uy = 0, Double V_ur = 0, Double phiN_n = 0, Double phiT_nTorsion = 0, Double phiM_nx = 0, Double phiM_ny = 0, Double phiV_nr = 0)
        {
            return WosadSteel.AISC_10.Combination.InteractionRatio(CombinationCaseId, N_u, T_uTorsion, M_ux, M_uy, V_ur, phiN_n, phiT_nTorsion, phiM_nx, phiM_ny, phiV_nr);
        }

    }

}

