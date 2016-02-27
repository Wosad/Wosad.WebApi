using Concrete.ACI318_14.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WosadConcrete = Concrete;

namespace Wosad.WebApi.Controllers
{
    /// <summary>
    ///Concrete.ACI31814.Flexure Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class ConcreteACI31814FlexureController : ApiController
    {
        ///<summary> Flexural strength </summary>
        ///<param name="ReinforcedConcreteSection"> Reinforced concrete section object. Create the object using input parameters first </param>
        ///<param name="FlexuralCompressionFiberLocation"> Indicates whether the section in flexure has top or bottom in compression due to stresses from bending moment </param>
        ///<returns name="phiM_n"> Design flexural strength at section </returns>

        [HttpGet]
        [Route("Concrete/ACI318_14/Flexure/SectionFlexuralStrength")]
        public Dictionary<string, object> SectionFlexuralStrength(ConcreteSection ConcreteSection, String FlexuralCompressionFiberLocation = "Top")
        {
            return WosadConcrete.ACI318_14.Flexure.SectionFlexuralStrength(ConcreteSection, FlexuralCompressionFiberLocation);
        }

    }

}

