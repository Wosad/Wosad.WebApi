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
    ///Concrete.ACI31814.General.Rebar Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class ConcreteACI31814GeneralRebarController : ApiController
    {
        ///<summary> Bar area </summary>
        ///<param name="RebarSizeId"> Rebar designation (number) indicating the size of bar </param>
        ///<returns name="A_b"> Area of an individual bar </returns>

        [HttpGet]
        [Route("Concrete/ACI318_14/General/Rebar/BarArea")]
        public Dictionary<string, object> BarArea(String RebarSizeId)
        {
            return WosadConcrete.ACI318_14.General.Rebar.BarArea(RebarSizeId);
        }

        ///<summary> Rebar area by width and spacing </summary>
        ///<param name="RebarSizeId"> Rebar designation (number) indicating the size of the bar </param>
        ///<param name="b_element"> Element width </param>
        ///<param name="s"> Center-to-center spacing of reinforcement </param>
        ///<param name="N_faces"> Number of faces (layers) of reinforcement </param>
        ///<returns name="A_s"> Area of nonprestressed longitudinal tension reinforcement </returns>

        [HttpGet]
        [Route("Concrete/ACI318_14/General/Rebar/RebarAreaByElementWidthAndIdAndSpacing")]
        public Dictionary<string, object> RebarAreaByElementWidthAndIdAndSpacing(String RebarSizeId, Double b_element, Double s, Double N_faces)
        {
            return WosadConcrete.ACI318_14.General.Rebar.RebarAreaByElementWidthAndIdAndSpacing(RebarSizeId, b_element, s, N_faces);
        }

        ///<summary> Rebar area by number of bars </summary>
        ///<param name="RebarSizeId"> Rebar designation (number) indicating the size of the bar </param>
        ///<param name="N_bars"> Number of bars </param>
        ///<returns name="A_s"> Area of longitudinal reinforcement </returns>

        [HttpGet]
        [Route("Concrete/ACI318_14/General/Rebar/RebarAreaByIdAndNumberOfBars")]
        public Dictionary<string, object> RebarAreaByIdAndNumberOfBars(String RebarSizeId, Double N_bars)
        {
            return WosadConcrete.ACI318_14.General.Rebar.RebarAreaByIdAndNumberOfBars(RebarSizeId, N_bars);
        }

    }

}

