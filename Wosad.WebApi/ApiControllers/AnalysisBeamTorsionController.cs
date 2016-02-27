using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WosadAnalysis = Analysis;

namespace Wosad.WebApi.Controllers
{
    /// <summary>
    ///Analysis.Beam.Torsion Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class AnalysisBeamTorsionController : ApiController
    {
        ///<summary> Calculates Evaluation of torsional functions </summary>
        ///<param name="TorsionalFunctionCaseId"> Case ID used in calculation of the values of torsional functions (per AISC design guide 9) </param>
        ///<param name="E"> Modulus of elasticity </param>
        ///<param name="G"> Shear modulus of elasticity </param>
        ///<param name="J"> Torsional constant for the cross-section </param>
        ///<param name="L"> member span length </param>
        ///<param name="z"> Distance from left support </param>
        ///<param name="T"> Concentrated torque </param>
        ///<param name="C_w"> Warping constant for the cross-section </param>
        ///<param name="t"> Uniformly distributed torque </param>
        ///<param name="alpha"> Fraction of total span at the point of concentrated torque </param>
        ///<returns>
        /// name="theta" Angle of rotation 
        /// name="theta_1der" First derivative of angle of rotation with respect to z 
        /// name="theta_2der" Second derivative of angle of rotation with respect to z 
        /// name="theta_3der" Third derivative of angle of rotation with respect to z 
        ///</returns>

        [HttpGet]
        [Route("Analysis/Beam/Torsion/TorsionalFunctionValues")]
        public Dictionary<string, object> TorsionalFunctionValues(String TorsionalFunctionCaseId, Double E, Double G, Double J, Double L, Double z, Double T, Double C_w, Double t, Double alpha)
        {
            return WosadAnalysis.Beam.Torsion.TorsionalFunctionValues(TorsionalFunctionCaseId, E, G, J, L, z, T, C_w, t, alpha);
        }

    }

}

