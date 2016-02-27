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
    ///Analysis.Section.TorsionalStress Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class AnalysisSectionTorsionalStressController : ApiController
    {
        ///<summary> Calculates Normal stress due to warping in open cross section </summary>
        ///<param name="E"> Modulus of elasticity </param>
        ///<param name="W_ns"> Normalized warping function at point s </param>
        ///<param name="theta_2der"> Second derivative of angle of rotation with respect to z </param>
        ///<returns name="sigma_ws"> Normal stress at point s due to warping </returns>

        [HttpGet]
        [Route("Analysis/Section/TorsionalStress/NormalStressDueToWarping")]
        public Dictionary<string, object> NormalStressDueToWarping(Double E, Double W_ns, Double theta_2der)
        {
            return WosadAnalysis.Section.TorsionalStress.NormalStressDueToWarping(E, W_ns, theta_2der);
        }

        ///<summary> Calculates Pure torsion stress in open cross section </summary>
        ///<param name="G"> Shear modulus of elasticity </param>
        ///<param name="t_el"> Thickness of element </param>
        ///<param name="theta_1der"> First derivative of angle of rotation with respect to z </param>
        ///<returns name="tau_t"> Pure torsional shear stress </returns>

        [HttpGet]
        [Route("Analysis/Section/TorsionalStress/PureTorsionStress")]
        public Dictionary<string, object> PureTorsionStress(Double G, Double t_el, Double theta_1der)
        {
            return WosadAnalysis.Section.TorsionalStress.PureTorsionStress(G, t_el, theta_1der);
        }

        ///<summary> Calculates Shear stress due to warping in open cross section </summary>
        ///<param name="E"> Modulus of elasticity </param>
        ///<param name="S_ws"> Warping statical moment at point s </param>
        ///<param name="t_el"> Thickness of element </param>
        ///<param name="theta_3der"> Third derivative of angle of rotation with respect to z </param>
        ///<returns name="tau_w"> Shear stress due to warping </returns>

        [HttpGet]
        [Route("Analysis/Section/TorsionalStress/ShearStressDueToWarping")]
        public Dictionary<string, object> ShearStressDueToWarping(Double E, Double S_ws, Double t_el, Double theta_3der)
        {
            return WosadAnalysis.Section.TorsionalStress.ShearStressDueToWarping(E, S_ws, t_el, theta_3der);
        }

    }

}

