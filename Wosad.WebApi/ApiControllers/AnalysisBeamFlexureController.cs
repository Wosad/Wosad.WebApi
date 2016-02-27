#region Copyright
   /*Copyright (C) 2015 Wosad Inc

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion
 
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
    ///Analysis.Beam.Flexure Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class AnalysisBeamFlexureController : ApiController
    {
        ///<summary> Calculates Calculation of beam deflections </summary>
        ///<param name="BeamDeflectionCaseId"> Case ID used in calculation of the beam deflection</param>
        ///<param name="L"> member span length </param>
        ///<param name="P"> Concentrated load in beam, or axial load in compression member </param>
        ///<param name="M"> Concentrated moment </param>
        ///<param name="w"> Uniformly distributed load </param>
        ///<param name="E"> Modulus of elasticity of steel </param>
        ///<param name="I"> Moment of inertia (I_x or I_y where applicable) </param>
        ///<param name="a_load"> Load offset dimension </param>
        ///<param name="b_load"> Load offset dimension </param>
        ///<param name="c_load"> Load offset dimension </param>
        ///<param name="P1"> Concentrated load 1, when multiple point loads are present </param>
        ///<param name="P2"> Concentrated load 2, when multiple point loads are present </param>
        ///<param name="M1"> Concentrated moment 1, when multiple point moments are applied </param>
        ///<param name="M2"> Concentrated moment 2, when multiple point moments are applied </param>
        ///<returns name="Delta_max"> Maximum deflection </returns>

        [HttpGet]
        [Route("Analysis/Beam/Flexure/BeamDeflections")]
        public Dictionary<string, object> BeamDeflections(String BeamDeflectionCaseId, Double L, Double P, Double M, Double w, Double E, Double I, Double a_load = 0, Double b_load = 0, Double c_load = 0, Double P1 = 0, Double P2 = 0, Double M1 = 0, Double M2 = 0)
        {
            return WosadAnalysis.Beam.Flexure.BeamDeflections(BeamDeflectionCaseId, L, P, M, w, E, I, a_load, b_load, c_load, P1, P2, M1, M2);
        }

        ///<summary> Calculates Calculation of beam forces </summary>
        ///<param name="BeamForcesCaseId"> Case ID used in calculation of the beam forces </param>
        ///<param name="L"> member span length </param>
        ///<param name="X"> Distance from left support </param>
        ///<param name="P"> Concentrated load in beam, or axial load in compression member </param>
        ///<param name="M"> Concentrated moment </param>
        ///<param name="w"> Uniformly distributed load </param>
        ///<param name="a_load"> Load offset dimension </param>
        ///<param name="b_load"> Load offset dimension </param>
        ///<param name="c_load"> Load offset dimension </param>
        ///<param name="P1"> Concentrated load 1, when multiple point loads are present </param>
        ///<param name="P2"> Concentrated load 2, when multiple point loads are present </param>
        ///<param name="M1"> Concentrated moment 1, when multiple point moments are applied </param>
        ///<param name="M2"> Concentrated moment 2, when multiple point moments are applied </param>
        ///<returns>
        /// name="M_max" Maximum positive moment 
        /// name="M_min" Maximum negative moment 
        /// name="V_max" Maximum shear (absolute value) 
        /// name="M_x" Moment at location X 
        /// name="V_x" Shear at loaction X 
        ///</returns>

        [HttpGet]
        [Route("Analysis/Beam/Flexure/BeamForces")]
        public Dictionary<string, object> BeamForces(String BeamForcesCaseId, Double L, Double X = 0, Double P = 0, Double M = 0, Double w = 0, Double a_load = 0, Double b_load = 0, Double c_load = 0, Double P1 = 0, Double P2 = 0, Double M1 = 0, Double M2 = 0)
        {
            return WosadAnalysis.Beam.Flexure.BeamForces(BeamForcesCaseId, L, X, P, M, w, a_load, b_load, c_load, P1, P2, M1, M2);
        }

    }

}

