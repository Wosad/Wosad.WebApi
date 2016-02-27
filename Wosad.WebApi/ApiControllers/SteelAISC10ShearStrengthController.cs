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
    ///Steel.AISC10.Shear.Strength Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10ShearStrengthController : ApiController
    {
        ///<summary> Shear strength circular member </summary>
        ///<param name="D"> Outside diameter of round HSS </param>
        ///<param name="t_nom"> HSS and pipe nominal wall thickness </param>
        ///<param name="Is_SAW_member"> Indicates whether HSS is a ERW or SAW </param>
        ///<param name="L_v"> Distance from maximum to zero shear force </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<returns name="phiV_n"> Shear strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Shear/Strength/ShearStrengthCircular")]
        public Dictionary<string, object> ShearStrengthCircular(Double D, Double t_nom, Boolean Is_SAW_member, Double L_v, Double F_y)
        {
            return WosadSteel.AISC_10.Shear.Strength.ShearStrengthCircular(D, t_nom, Is_SAW_member, L_v, F_y);
        }

        ///<summary> Shear strength noncircular member </summary>
        ///<param name="ShearCase"> Shape type for shear </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="h"> Width of stiffened element </param>
        ///<param name="a_s"> Clear distance between transverse stiffeners </param>
        ///<param name="E"> Modulus of elasticity of steel </param>
        ///<returns name="phiV_n"> Shear strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Shear/Strength/ShearStrengthNonCircular")]
        public Dictionary<string, object> ShearStrengthNonCircular(String ShearCase, Double F_y, Double t_w, Double h, Double a_s, Double E)
        {
            return WosadSteel.AISC_10.Shear.Strength.ShearStrengthNonCircular(ShearCase, F_y, t_w, h, a_s, E);
        }

    }

}

