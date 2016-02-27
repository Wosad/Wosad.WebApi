using Steel.AISC_10.Composite;
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
    ///Steel.AISC10.Composite.Flexure Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10CompositeFlexureController : ApiController
    {
        ///<summary> Calculates Beam effective slab width </summary>
        ///<param name="L"> Length of member length of span or unbraced length of member </param>
        ///<param name="L_centerLeft"> Beam spacing measured normal to beam span (left side of beam) </param>
        ///<param name="L_centerRight"> Beam spacing measured normal to beam span (right side of beam) </param>
        ///<param name="L_edgeLeft"> Distance between slab edges measured normal to beam span (left side of beam) </param>
        ///<param name="L_edgeRight"> Distance between slab edges measured normal to beam span (right side of beam) </param>
        ///<returns name="b_eff"> Effective width of concrete slab in composite beam design </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Composite/Flexure/BeamEffectiveSlabWidth")]
        public Dictionary<string, object> BeamEffectiveSlabWidth(Double L, Double L_centerLeft, Double L_centerRight, Double L_edgeLeft, Double L_edgeRight)
        {
            return WosadSteel.AISC_10.Composite.Flexure.BeamEffectiveSlabWidth(L, L_centerLeft, L_centerRight, L_edgeLeft, L_edgeRight);
        }

        ///<summary> Calculates Lower-bound moment of inertia </summary>
        ///<param name="Shape"> Steel shape instance (must be of CompositeSteelShape type) </param>
        ///<param name="b_eff"> Effective width of concrete slab in composite beam design </param>
        ///<param name="h_solid"> Depth of solid portian of concrete slab on metal deck (fill above deck) </param>
        ///<param name="h_rib"> Depth of ribs for corrugated metal deck </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="fc_prime"> Specified compressive strength of concrete </param>
        ///<param name="SumQ_n"> Sum of the nominal strengths of steel anchors between the point of maximum positive moment and the point of zero moment to either side </param>
        ///<returns name="I_LB"> Lower-bound moment of inertia for composite beam </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Composite/Flexure/LowerBoundMomentOfInertia")]
        public Dictionary<string, object> LowerBoundMomentOfInertia(CompositeSteelShape Shape, Double b_eff, Double h_solid, Double h_rib, Double F_y, Double fc_prime, Double SumQ_n)
        {
            return WosadSteel.AISC_10.Composite.Flexure.LowerBoundMomentOfInertia(Shape, b_eff, h_solid, h_rib, F_y, fc_prime, SumQ_n);
        }

        ///<summary> Calculates Positive moment flexural strength for composite beam </summary>
        ///<param name="Shape"> Steel shape instance (must be of CompositeSteelShape type) </param>
        ///<param name="b_eff"> Effective width of concrete slab in composite beam design </param>
        ///<param name="h_solid"> Depth of solid portian of concrete slab on metal deck (fill above deck) </param>
        ///<param name="h_rib"> Depth of ribs for corrugated metal deck </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="fc_prime"> Specified compressive strength of concrete </param>
        ///<param name="SumQ_n"> Sum of the nominal strengths of steel anchors between the point of maximum positive moment and the point of zero moment to either side </param>
        ///<returns name="phiM_n"> Moment strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Composite/Flexure/PositiveMomentFlexuralStrength")]
        public Dictionary<string, object> PositiveMomentFlexuralStrength(CompositeSteelShape Shape, Double b_eff, Double h_solid, Double h_rib, Double F_y, Double fc_prime, Double SumQ_n)
        {
            return WosadSteel.AISC_10.Composite.Flexure.PositiveMomentFlexuralStrength(Shape, b_eff, h_solid, h_rib, F_y, fc_prime, SumQ_n);
        }

    }

}

