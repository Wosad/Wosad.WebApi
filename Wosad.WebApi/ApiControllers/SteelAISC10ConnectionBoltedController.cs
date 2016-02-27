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
    ///Steel.AISC10.Connection.Bolted Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10ConnectionBoltedController : ApiController
    {
        ///<summary> Calculates bolt nominal shear stress from AISC Table J3.2 </summary>
        ///<param name="BoltMaterialId"> Bolt material specification </param>
        ///<param name="BoltThreadCase"> Identifies whether threads are included or excluded from shear planes </param>
        ///<returns name="F_nv"> Nominal shear stress </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BearingBoltNominalShearStress")]
        public Dictionary<string, object> BearingBoltNominalShearStress(String BoltMaterialId, String BoltThreadCase)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BearingBoltNominalShearStress(BoltMaterialId, BoltThreadCase);
        }

        ///<summary> Calculates bearing bolt shear strength </summary>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="BoltMaterialId"> Bolt material specification </param>
        ///<param name="BoltThreadCase"> Identifies whether threads are included or excluded from shear planes </param>
        ///<param name="NumberShearPlanes"> Number of shear planes </param>
        ///<param name="IsEndLoadedConnectionWithLengthEfect"> Identifies whether connection is end-loaded with length over 38 inches </param>
        ///<returns name="phiR_nv"> Connection shear strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BearingBoltShearStrength")]
        public Dictionary<string, object> BearingBoltShearStrength(Double d_b, String BoltMaterialId, String BoltThreadCase, Double NumberShearPlanes, Boolean IsEndLoadedConnectionWithLengthEfect)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BearingBoltShearStrength(d_b, BoltMaterialId, BoltThreadCase, NumberShearPlanes, IsEndLoadedConnectionWithLengthEfect);
        }

        ///<summary> Calculates Bearing strength at bolt hole </summary>
        ///<param name="BoltHoleType"> Type of bolt hole </param>
        ///<param name="l_c"> Clear distance in the direction of the force between the edge of the hole and the edge of the adjacent hole or edge of the material </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="t"> Thickness of element plate or element wall </param>
        ///<param name="BoltHoleDeformationType"> Identifies of bolt deformation is a design consideration </param>
        ///<param name="IsUnstiffenedHollowSection"> Distinguishes between connections made using bolts that pass completely through an unstiffened box member or HSS and all other cases </param>
        ///<returns name="phiR_nv"> Connection shear strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BearingStrengthAtBoltHole")]
        public Dictionary<string, object> BearingStrengthAtBoltHole(String BoltHoleType, Double l_c, Double F_u, Double F_y, Double d_b, Double t, String BoltHoleDeformationType = "ConsideredUnderServiceLoad", Boolean IsUnstiffenedHollowSection = false)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BearingStrengthAtBoltHole(BoltHoleType, l_c, F_u, F_y, d_b, t, BoltHoleDeformationType, IsUnstiffenedHollowSection);
        }

        ///<summary> Calculates Bolt minimum edge distance </summary>
        ///<param name="l_BoltEdge"> Distance from bolt centerline to connected material edge </param>
        ///<param name="l_BoltCenter"> Bolt centerline spacing </param>
        ///<param name="d_hole"> Bolt hole diameter </param>
        ///<returns>
        /// name="l_cEdge" Clear distance from bolt centerline to connected material edge 
        /// name="l_cCenter" Bolt clear centerline spacing 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BoltClearDistance")]
        public Dictionary<string, object> BoltClearDistance(Double l_BoltEdge, Double l_BoltCenter, Double d_hole)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BoltClearDistance(l_BoltEdge, l_BoltCenter, d_hole);
        }

        ///<summary> Calculates Eccentrically loaded bolt group coefficient </summary>
        ///<param name="N_rows"> Number of bolt rows in bolt groups </param>
        ///<param name="N_cols"> Number of bolt columns in bolt groups </param>
        ///<param name="p_h"> Horizontal bolt spacing </param>
        ///<param name="p_v"> Vertical bolt spacing </param>
        ///<param name="e_group"> Connection bolt or weld group eccentricity </param>
        ///<param name="theta"> Angle of loading for eccentric bolt or weld group </param>
        ///<returns>
        /// name="C_BoltGroup" Coefficient for eccentrically loaded bolt group 
        /// name="C_prime" Coefficient for bolt group subjected to pure moment 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BoltGroupCoefficient")]
        public Dictionary<string, object> BoltGroupCoefficient(Double N_rows, Double N_cols, Double p_h, Double p_v, Double e_group, Double theta)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BoltGroupCoefficient(N_rows, N_cols, p_h, p_v, e_group, theta);
        }

        ///<summary> Calculates Eccentrically loaded bolt group strength </summary>
        ///<param name="C_BoltGroup"> Coefficient for eccentrically loaded bolt group </param>
        ///<param name="phiR_nv"> Connection shear strength </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BoltGroupStrength")]
        public Dictionary<string, object> BoltGroupStrength(Double C_BoltGroup, Double phiR_nv)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BoltGroupStrength(C_BoltGroup, phiR_nv);
        }

        ///<summary> Calculates Bolt nominal hole dimension </summary>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="BoltHoleType"> Type of bolt hole </param>
        ///<param name="IsTensionOrShear"> Identifies whether limit state involves tension or shear (for bolt dimension calculations)</param>
        ///<returns>
        /// name="d_hole" Bolt hole diameter 
        /// name="b_hole" Bolt hole width (long dimension) 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BoltHoleSize")]
        public Dictionary<string, object> BoltHoleSize(Double d_b, String BoltHoleType, Boolean IsTensionOrShear)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BoltHoleSize(d_b, BoltHoleType, IsTensionOrShear);
        }

        ///<summary> Calculates bolt nominal tensile stress from AISC Table J3.2 </summary>
        ///<param name="BoltMaterialId"> Bolt material specification </param>
        ///<param name="BoltThreadCase"> Identifies whether threads are included or excluded from shear planes </param>
        ///<returns name="F_nt"> Nominal tensile stress </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BoltNominalTensileStress")]
        public Dictionary<string, object> BoltNominalTensileStress(String BoltMaterialId, String BoltThreadCase)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BoltNominalTensileStress(BoltMaterialId, BoltThreadCase);
        }

        ///<summary> Calculates bolt tensile strength </summary>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="BoltMaterialId"> Bolt material specification </param>
        ///<param name="BoltThreadCase"> Identifies whether threads are included or excluded from shear planes </param>
        ///<returns name="phiR_nt"> Connection tensile strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/BoltTensileStrength")]
        public Dictionary<string, object> BoltTensileStrength(Double d_b, String BoltMaterialId, String BoltThreadCase)
        {
            return WosadSteel.AISC_10.Connection.Bolted.BoltTensileStrength(d_b, BoltMaterialId, BoltThreadCase);
        }

        ///<summary> Calculates Prying action maximum tension force </summary>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="d_hole"> Bolt hole diameter (in the direction of prying action) </param>
        ///<param name="t_p"> Thickness of plate </param>
        ///<param name="a_edge"> Distance from edge of flange or leg of tensile element to bolt centerline, for prying action calculation </param>
        ///<param name="b_stem"> Distance from tensile element to bolt centerline, for prying action calculation taken as distance to face of stem for tee and to centerline of leg for angle </param>
        ///<param name="p"> Pitch </param>
        ///<param name="B_bolt"> Design bolt tension using nominal tensile strength of bolt or modified to include effects of shear stress </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<returns name="phiT_n"> Tensile strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/MaximumTensileForceWithEffectsOfPryingAction")]
        public Dictionary<string, object> MaximumTensileForceWithEffectsOfPryingAction(Double d_b, Double d_hole, Double t_p, Double a_edge, Double b_stem, Double p, Double B_bolt, Double F_u)
        {
            return WosadSteel.AISC_10.Connection.Bolted.MaximumTensileForceWithEffectsOfPryingAction(d_b, d_hole, t_p, a_edge, b_stem, p, B_bolt, F_u);
        }

        ///<summary> Calculates Prying action minimum plate thickness </summary>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="d_hole"> Bolt hole diameter (in the direction of prying action) </param>
        ///<param name="T_bolt"> Bolt tension </param>
        ///<param name="a_edge"> Distance from edge of flange or leg of tensile element to bolt centerline, for prying action calculation </param>
        ///<param name="b_stem"> Distance from tensile element to bolt centerline, for prying action calculation taken as distance to face of stem for tee and to centerline of leg for angle </param>
        ///<param name="p"> Pitch </param>
        ///<param name="B_bolt"> Design bolt tension using nominal tensile strength of bolt or modified to include effects of shear stress </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<returns name="t_min"> Minimum thickness of connection material </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/MinimumPlateThicknessEffectsOfPryingAction")]
        public Dictionary<string, object> MinimumPlateThicknessEffectsOfPryingAction(Double d_b, Double d_hole, Double T_bolt, Double a_edge, Double b_stem, Double p, Double B_bolt, Double F_u)
        {
            return WosadSteel.AISC_10.Connection.Bolted.MinimumPlateThicknessEffectsOfPryingAction(d_b, d_hole, T_bolt, a_edge, b_stem, p, B_bolt, F_u);
        }

        ///<summary> Calculates Bearing bolt combined tension and shear </summary>
        ///<param name="V_u"> Required shear strength </param>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="BoltMaterialId"> Bolt material specification </param>
        ///<param name="BoltThreadCase"> Identifies whether threads are included or excluded from shear planes </param>
        ///<returns name="phiR_nt_modified"> Modified shear strength of bolt subjected to tension </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/ModifiedBoltShearStrength")]
        public Dictionary<string, object> ModifiedBoltShearStrength(Double V_u, Double d_b, String BoltMaterialId, String BoltThreadCase)
        {
            return WosadSteel.AISC_10.Connection.Bolted.ModifiedBoltShearStrength(V_u, d_b, BoltMaterialId, BoltThreadCase);
        }

        ///<summary> Calculates Modified shear strength slip-critical bolt combined tension and shear </summary>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="T_u"> Required tension force </param>
        ///<param name="BoltMaterialId"> Bolt material specification </param>
        ///<param name="BoltHoleType"> Type of bolt hole </param>
        ///<param name="BoltFillerCase"> Distinguishes between filler cases for slip-critical bolt capacity calculations </param>
        ///<param name="BoltFayingSurfaceClass"> Identifies the type of faying surface for a slip critical bolt </param>
        ///<param name="NumberShearPlanes"> Number of shear planes </param>
        ///<returns name="phiR_nModified"> Modified shear strength of bolt subjected to tension </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/SlipCriticalBoltCombinedTensionAndShear")]
        public Dictionary<string, object> SlipCriticalBoltCombinedTensionAndShear(Double d_b, Double T_u, String BoltMaterialId, String BoltHoleType, String BoltFillerCase = "One", String BoltFayingSurfaceClass = "ClassA", Double NumberShearPlanes = 1)
        {
            return WosadSteel.AISC_10.Connection.Bolted.SlipCriticalBoltCombinedTensionAndShear(d_b, T_u, BoltMaterialId, BoltHoleType, BoltFillerCase, BoltFayingSurfaceClass, NumberShearPlanes);
        }

        ///<summary> Calculates Slip-critical bolt shear strength </summary>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="BoltMaterialId"> Bolt material specification </param>
        ///<param name="BoltHoleType"> Type of bolt hole </param>
        ///<param name="BoltFillerCase"> Distinguishes between filler cases for slip-critical bolt capacity calculations </param>
        ///<param name="BoltFayingSurfaceClass"> Identifies the type of faying surface for a slip critical bolt </param>
        ///<param name="NumberShearPlanes"> Number of shear planes </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/Bolted/SlipCriticalBoltShearStrength")]
        public Dictionary<string, object> SlipCriticalBoltShearStrength(Double d_b, String BoltMaterialId, String BoltHoleType, String BoltFillerCase = "One", String BoltFayingSurfaceClass = "ClassA", Double NumberShearPlanes = 1)
        {
            return WosadSteel.AISC_10.Connection.Bolted.SlipCriticalBoltShearStrength(d_b, BoltMaterialId, BoltHoleType, BoltFillerCase, BoltFayingSurfaceClass, NumberShearPlanes);
        }

    }

}

