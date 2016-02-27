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
    ///Steel.AISC10.Composite.Anchor Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10CompositeAnchorController : ApiController
    {
        ///<summary> Calculates Strength of headed stud anchor </summary>
        ///<param name="N_anchors"> Number of shear anchors along full length of element </param>
        ///<param name="Q_n"> Nominal strength of one steel headed stud or steel channel anchor </param>
        ///<returns name="SumQ_n"> Sum of the nominal strengths of steel anchors between the point of maximum positive moment and the point of zero moment to either side </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Composite/Anchor/DesignSumOfAnchorStrengths")]
        public Dictionary<string, object> DesignSumOfAnchorStrengths(Double N_anchors, Double Q_n)
        {
            return WosadSteel.AISC_10.Composite.Anchor.DesignSumOfAnchorStrengths(N_anchors, Q_n);
        }

        ///<summary> Calculates Strength of headed stud anchor </summary>
        ///<param name="HeadedAnchorDeckCondition"> Identifies whether deck runs parallel or perpendicular to beam or there is no deck </param>
        ///<param name="HeadedAnchorWeldCase"> Identifies the type of welding between the anchor and shape (through deck or not) </param>
        ///<param name="N_saRib"> Number of steel headed stud anchors occupying the same decking rib </param>
        ///<param name="e_mid_ht"> Distance from the edge of steel headed stud anchor shank to the steel deck web </param>
        ///<param name="h_r"> Nominal height of rib </param>
        ///<param name="w_r"> Average width of concrete rib or haunch </param>
        ///<returns>
        /// name="R_g" Coefficient to account for group effect 
        /// name="R_p" Position effect factor for shear anchors 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/Composite/Anchor/HeadedAnchorPositionAndGroupFactors")]
        public Dictionary<string, object> HeadedAnchorPositionAndGroupFactors(String HeadedAnchorDeckCondition, String HeadedAnchorWeldCase, Double N_saRib, Double e_mid_ht, Double h_r, Double w_r)
        {
            return WosadSteel.AISC_10.Composite.Anchor.HeadedAnchorPositionAndGroupFactors(HeadedAnchorDeckCondition, HeadedAnchorWeldCase, N_saRib, e_mid_ht, h_r, w_r);
        }

        ///<summary> Calculates Shear strength of headed anchor </summary>
        ///<param name="d_sa"> Headed anchor diameter </param>
        ///<param name="R_g"> Coefficient to account for group effect </param>
        ///<param name="R_p"> Position effect factor for shear anchors </param>
        ///<param name="fc_prime"> Specified compressive strength of concrete </param>
        ///<param name="w_c"> Weight of concrete per unit volume (pcf) </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<returns>
        /// name="Q_n" Nominal strength of one steel headed stud or steel channel anchor 
        /// name="phiQ_n" Strength of one steel headed stud or steel channel anchor 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/Composite/Anchor/ShearStrengthOfHeadedAnchor")]
        public Dictionary<string, object> ShearStrengthOfHeadedAnchor(Double d_sa, Double R_g, Double R_p, Double fc_prime, Double w_c, Double F_u = 65)
        {
            return WosadSteel.AISC_10.Composite.Anchor.ShearStrengthOfHeadedAnchor(d_sa, R_g, R_p, fc_prime, w_c, F_u);
        }

    }

}

