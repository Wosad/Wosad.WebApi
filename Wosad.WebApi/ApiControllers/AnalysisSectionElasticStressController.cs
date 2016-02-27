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
    ///Analysis.Section.ElasticStress Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class AnalysisSectionElasticStressController : ApiController
    {
        ///<summary> Calculates Normal stress due to axial load </summary>
        ///<param name="P"> Concentrated load in beam, or axial load in compression member </param>
        ///<param name="A"> Area of cross section </param>
        ///<returns name="sigma_a"> Normal stress due to axial load </returns>

        [HttpGet]
        [Route("Analysis/Section/ElasticStress/NormalStressDueToAxialLoad")]
        public Dictionary<string, object> NormalStressDueToAxialLoad(Double P, Double A)
        {
            return WosadAnalysis.Section.ElasticStress.NormalStressDueToAxialLoad(P, A);
        }

        ///<summary> Calculates Normal stress due to bending </summary>
        ///<param name="M"> Concentrated moment </param>
        ///<param name="y"> Vertical distance from horizontal neutral axis to section point under consideration </param>
        ///<param name="I"> Moment of inertia (I_x or I_y where applicable) </param>
        ///<returns name="sigma_b"> Normal stress due to bending about either the x or y </returns>

        [HttpGet]
        [Route("Analysis/Section/ElasticStress/NormalStressDueToBending")]
        public Dictionary<string, object> NormalStressDueToBending(Double M, Double y, Double I)
        {
            return WosadAnalysis.Section.ElasticStress.NormalStressDueToBending(M, y, I);
        }

        ///<summary> Calculates Shear stress due to applied shear </summary>
        ///<param name="V"> Internal shear force </param>
        ///<param name="Q"> Statical moment for the point in question </param>
        ///<param name="I"> Moment of inertia (I_x or I_y where applicable) </param>
        ///<returns name="tau_b"> Shear stress due to applied shear </returns>

        [HttpGet]
        [Route("Analysis/Section/ElasticStress/ShearStressDueToAppliedShear")]
        public Dictionary<string, object> ShearStressDueToAppliedShear(Double V, Double Q, Double I)
        {
            return WosadAnalysis.Section.ElasticStress.ShearStressDueToAppliedShear(V, Q, I);
        }

    }

}

