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
    ///Steel.AISC10.Connection.SpecialCase.ExtendedSinglePlate Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10ConnectionSpecialCaseExtendedSinglePlateController : ApiController
    {
        ///<summary> Calculates Flexural strength of extended single plate, using plate buckling equation for coped beams </summary>
        ///<param name="a_bolts"> Distance from support to first line of bolts </param>
        ///<param name="t_p"> Thickness of plate </param>
        ///<param name="d_pl"> Depth of plate </param>
        ///<param name="F_y"> Specified minimum yield stress of plate </param>
        ///<returns name="phiM_n"> Moment strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/SpecialCase/ExtendedSinglePlate/ExtendedSinglePlateFlexuralBucklingStrength")]
        public Dictionary<string, object> ExtendedSinglePlateFlexuralBucklingStrength(Double a_bolts, Double t_p, Double d_pl, Double F_y)
        {
            return WosadSteel.AISC_10.Connection.SpecialCase.ExtendedSinglePlate.ExtendedSinglePlateFlexuralBucklingStrength(a_bolts, t_p, d_pl, F_y);
        }

        ///<summary> Calculates Extended single plate maximum plate thickness </summary>
        ///<param name="F_nv"> Nominal shear stress </param>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="C_prime"> Coefficient for bolt group subjected to pure moment </param>
        ///<param name="F_yp"> Specified minimum yield stress of plate </param>
        ///<param name="d_pl"> Depth of plate </param>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="L_ehBm"> Horizontal edge distance for bolts in connected beam </param>
        ///<param name="L_ehPl"> Horizontal edge distance for bolts in connected plate </param>
        ///<param name="N_cols"> Number of bolt columns in bolt groups </param>
        ///<returns name="t_max"> Maximum plate thickness </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/SpecialCase/ExtendedSinglePlate/ExtendedSinglePlateMaxPlateThickness")]
        public Dictionary<string, object> ExtendedSinglePlateMaxPlateThickness(Double F_nv, Double d_b, Double C_prime, Double F_yp, Double d_pl, Double t_w, Double L_ehBm, Double L_ehPl, Double N_cols)
        {
            return WosadSteel.AISC_10.Connection.SpecialCase.ExtendedSinglePlate.ExtendedSinglePlateMaxPlateThickness(F_nv, d_b, C_prime, F_yp, d_pl, t_w, L_ehBm, L_ehPl, N_cols);
        }

        ///<summary> Extended single plate shear strength if no stabilizer plates are added per AISC SCM Chapter 10 </summary>
        ///<param name="d_pl"> Depth of plate </param>
        ///<param name="t_p"> Thickness of plate </param>
        ///<param name="a_bolts"> Distance from support to first line of bolts </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/SpecialCase/ExtendedSinglePlate/ExtendedSinglePlateShearStrengthWithoutStabilizer")]
        public Dictionary<string, object> ExtendedSinglePlateShearStrengthWithoutStabilizer(Double d_pl, Double t_p, Double a_bolts, Double F_y)
        {
            return WosadSteel.AISC_10.Connection.SpecialCase.ExtendedSinglePlate.ExtendedSinglePlateShearStrengthWithoutStabilizer(d_pl, t_p, a_bolts, F_y);
        }

        ///<summary> Extended single plate design torsional moment, to be compared with flexural strength of stabilized single plate per AISC SCM Chapter 10 </summary>
        ///<param name="R_u"> Required strength </param>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="t_p"> Thickness of plate </param>
        ///<returns name="M_tu"> Stabilized extended shear tab design moment </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/SpecialCase/ExtendedSinglePlate/StabilizedExtendedSinglePlateTorsionalMoment")]
        public Dictionary<string, object> StabilizedExtendedSinglePlateTorsionalMoment(Double R_u, Double t_w, Double t_p)
        {
            return WosadSteel.AISC_10.Connection.SpecialCase.ExtendedSinglePlate.StabilizedExtendedSinglePlateTorsionalMoment(R_u, t_w, t_p);
        }

        ///<summary> Flexural strength of extended single plate per AISC SCM Chapter 10 </summary>
        ///<param name="R_u"> Required strength </param>
        ///<param name="F_yp"> Specified minimum yield stress of plate </param>
        ///<param name="d_pl"> Depth of plate </param>
        ///<param name="t_p"> Thickness of plate </param>
        ///<param name="L_bm"> Span length of beam </param>
        ///<param name="F_ybm"> Specified minimum yield stress of beam </param>
        ///<param name="b_f"> Width of flange </param>
        ///<param name="t_w"> Thickness of web </param>
        ///<returns name="phiM_n"> Moment strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/SpecialCase/ExtendedSinglePlate/StabilizedExtendedSinglePlateTorsionalStrength")]
        public Dictionary<string, object> StabilizedExtendedSinglePlateTorsionalStrength(Double R_u, Double F_yp, Double d_pl, Double t_p, Double L_bm, Double F_ybm, Double b_f, Double t_w)
        {
            return WosadSteel.AISC_10.Connection.SpecialCase.ExtendedSinglePlate.StabilizedExtendedSinglePlateTorsionalStrength(R_u, F_yp, d_pl, t_p, L_bm, F_ybm, b_f, t_w);
        }

    }

}

