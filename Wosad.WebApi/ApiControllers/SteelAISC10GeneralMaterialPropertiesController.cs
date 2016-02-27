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
    ///Steel.AISC10.General.MaterialProperties Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10GeneralMaterialPropertiesController : ApiController
    {
        ///<summary> Calculates yield and ultimate stress for slected steel material as well as modulus of elasticity and shear modulus </summary>
        ///<param name="SteelMaterialId"> Steel material </param>
        ///<param name="d_b"> Bolt diameter (if applicable) </param>
        ///<returns>
        /// name="F_y" Specified minimum yield stress 
        /// name="F_u" Specified minimum tensile strength 
        /// name="E" Modulus of elasticity of steel 
        /// name="G" Shear modulus of elasticity of steel 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/General/MaterialProperties/MaterialMechanicalProperties")]
        public Dictionary<string, object> MaterialMechanicalProperties(String SteelMaterialId, Double d_b = 0)
        {
            return WosadSteel.AISC_10.General.MaterialProperties.MaterialMechanicalProperties(SteelMaterialId, d_b);
        }

    }

}

