using Analysis.Section;
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
    ///Steel.AISC10.Connection.AffectedElements Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class SteelAISC10ConnectionAffectedElementsController : ApiController
    {
        ///<summary> Calculates Block shear strength </summary>
        ///<param name="A_gv"> Gross area subject to shear </param>
        ///<param name="A_nv"> Net area subject to shear </param>
        ///<param name="A_nt"> Net area subject to tension </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<param name="StressDistibutionType"> Type of stress distribution in connected element </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/BlockShearStrength")]
        public Dictionary<string, object> BlockShearStrength(Double A_gv, Double A_nv, Double A_nt, Double F_y, Double F_u, String StressDistibutionType)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.BlockShearStrength(A_gv, A_nv, A_nt, F_y, F_u, StressDistibutionType);
        }

        ///<summary> Calculates Strength of bolt group for the bearing on base material limit state </summary>
        ///<param name="N_BoltRowParallel"> Number of bolt rows parallel to direction of load </param>
        ///<param name="N_BoltRowPerpendicular"> Number of bolt columns perpendicular to direction of load </param>
        ///<param name="phiR_nFirstRow"> Bolt bearing strength for first row of bolts </param>
        ///<param name="phiR_nInnerRow"> Bolt bearing strength for inner row of bolts </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/BoltGroupBearingStrength")]
        public Dictionary<string, object> BoltGroupBearingStrength(Double N_BoltRowParallel, Double N_BoltRowPerpendicular, Double phiR_nFirstRow, Double phiR_nInnerRow)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.BoltGroupBearingStrength(N_BoltRowParallel, N_BoltRowPerpendicular, phiR_nFirstRow, phiR_nInnerRow);
        }

        ///<summary> Calculates Net and gross shear and tension areas for block shear, shear yielding and shear rupture calculations </summary>
        ///<param name="ShearAreaCaseId"> Case selection for shear area calculations in affected elements in connections (block shear, shear yielding, shear rupture).Values are: StraightLine,TBlock,UBlock,Lblock </param>
        ///<param name="N_BoltRowParallel"> Number of bolt rows parallel to direction of load (for example number of rows when load is vertical) </param>
        ///<param name="N_BoltRowPerpendicular"> Number of bolt columns perpendicular to direction of load (for example number of columns when the load is vertical) </param>
        ///<param name="p_parallel"> Bolt spacing in the direction of load </param>
        ///<param name="p_perpendicular"> Bolt spacing perpendicular to the direction of load </param>
        ///<param name="d_hole"> Bolt hole diameter </param>
        ///<param name="t_p"> Thickness of plate </param>
        ///<param name="l_edgeParallel"> Edge distance measured parallel to direction of load (for example verical edge distance when the load is vertical) </param>
        ///<param name="l_edgePerpendicular"> Edge distance measured perpendicular to direction of load (for example horizontal edge distance when the load is vertical)</param>
        ///<returns>
        /// name="A_gv" Gross area subject to shear 
        /// name="A_nv" Net area subject to shear 
        /// name="A_nt" Net area subject to tension 
        ///</returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/BoltGroupShearAndTensionAreas")]
        public Dictionary<string, object> BoltGroupShearAndTensionAreas(String ShearAreaCaseId, Double N_BoltRowParallel, Double N_BoltRowPerpendicular, Double p_parallel, Double p_perpendicular, Double d_hole, Double t_p, Double l_edgeParallel, Double l_edgePerpendicular)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.BoltGroupShearAndTensionAreas(ShearAreaCaseId, N_BoltRowParallel, N_BoltRowPerpendicular, p_parallel, p_perpendicular, d_hole, t_p, l_edgeParallel, l_edgePerpendicular);
        }

        ///<summary> Connected element strength in flexure </summary>
        ///<param name="Shape"> Cross section shape </param>
        ///<param name="L_b"> Length between points that are either braced against lateral displacement of compression flange or braced against twist of the cross section </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<param name="HasHolesInTensionFlange"> Identifies if member has holes in tension flange, for checking tension rupture of flange per F13 </param>
        ///<param name="A_fg"> Gross area of tension flange </param>
        ///<param name="A_fn"> Net area of tension flange </param>
        ///<param name="IsCompactDoublySymmetricForFlexure"> Indicates whether shape is compact for flexure and doubly symmetric </param>
        ///<param name="C_b"> Lateral-torsional buckling modification factor for nonuniform moment diagrams </param>
        ///<returns name="phiM_n"> Moment strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/ConnectedElementStrengthInFlexure")]
        public Dictionary<string, object> ConnectedElementStrengthInFlexure(CustomProfile Shape, Double L_b, Double F_y, Double F_u, Boolean HasHolesInTensionFlange, Double A_fg = 0, Double A_fn = 0, Boolean IsCompactDoublySymmetricForFlexure = false, Double C_b = 1)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.ConnectedElementStrengthInFlexure(Shape, L_b, F_y, F_u, HasHolesInTensionFlange, A_fg, A_fn, IsCompactDoublySymmetricForFlexure, C_b);
        }

        ///<summary> Calculates Connected element strength in shear </summary>
        ///<param name="A_gv"> Gross area subject to shear </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<param name="A_nv"> Net area subject to shear </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/ConnectedElementStrengthInShear")]
        public Dictionary<string, object> ConnectedElementStrengthInShear(Double A_gv, Double F_y, Double F_u, Double A_nv)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.ConnectedElementStrengthInShear(A_gv, F_y, F_u, A_nv);
        }

        ///<summary> Calculates Connected element strength in tension </summary>
        ///<param name="A_g"> Gross cross-sectional area of member </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<param name="A_e"> Effective net area </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/ConnectedElementStrengthInTension")]
        public Dictionary<string, object> ConnectedElementStrengthInTension(Double A_g, Double F_y, Double F_u, Double A_e)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.ConnectedElementStrengthInTension(A_g, F_y, F_u, A_e);
        }

        ///<summary> Calculates Coped section strength in flexure </summary>
        ///<param name="d"> Full nominal depth of the section </param>
        ///<param name="b_f"> Width of flange </param>
        ///<param name="t_f"> Thickness of flange </param>
        ///<param name="d_cope"> Depth of cope </param>
        ///<param name="c"> Length of cope </param>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="F_u"> Specified minimum tensile strength </param>
        ///<param name="BeamCopeCase"> Identifies beam cope condition for stability calculations: single cope vs double cope </param>
        ///<returns name="phiM_n"> Moment strength </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/CopedSectionStrengthInFlexure")]
        public Dictionary<string, object> CopedSectionStrengthInFlexure(Double d, Double b_f, Double t_f, Double d_cope, Double c, Double t_w, Double F_y, Double F_u, String BeamCopeCase)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.CopedSectionStrengthInFlexure(d, b_f, t_f, d_cope, c, t_w, F_y, F_u, BeamCopeCase);
        }

        ///<summary> Calculates Concentrated force flange local bending </summary>
        ///<param name="F_yf"> Specified minimum yield stress </param>
        ///<param name="t_f"> Thickness of flange </param>
        ///<param name="l_edge"> Edge distance </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/FlangeLocalBending")]
        public Dictionary<string, object> FlangeLocalBending(Double F_yf, Double t_f, Double l_edge)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.FlangeLocalBending(F_yf, t_f, l_edge);
        }

        ///<summary> Calculates Gusset plate configuration compactness </summary>
        ///<param name="t_g"> Gusset plate thickness </param>
        ///<param name="c_Gusset"> Shortest distance between closest bolt and beam flange </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="E"> Modulus of elasticity of steel </param>
        ///<param name="l_1"> Gusset plate distance from beam to nearest row of bolts </param>
        ///<returns name="IsGussetCompactConfiguration"> Distinguishes between compact and noncompact configuration for gusset effective length factor </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/GussetPlateConfigurationCompactness")]
        public Dictionary<string, object> GussetPlateConfigurationCompactness(Double t_g, Double c_Gusset, Double F_y, Double E, Double l_1)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.GussetPlateConfigurationCompactness(t_g, c_Gusset, F_y, E, l_1);
        }

        ///<summary> Calculates Gusset plate effective compression length </summary>
        ///<param name="GussetPlateConfigurationId"> Type of gusset plate configuration for calculation of effective length </param>
        ///<param name="l_1"> Gusset plate distance from beam to nearest row of bolts </param>
        ///<param name="l_2"> Gusset plate distance from column to nearest row of bolts </param>
        ///<param name="IsGussetCompactConfiguration"> Indicates whether gusset plate configuration is compact (per Design Guide 29 Appendix C) </param>
        ///<returns name="KL_gusset"> Effective length of gusset plate </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/GussetPlateEffectiveCompressionLength")]
        public Dictionary<string, object> GussetPlateEffectiveCompressionLength(String GussetPlateConfigurationId, Double l_1, Double l_2, Boolean IsGussetCompactConfiguration)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.GussetPlateEffectiveCompressionLength(GussetPlateConfigurationId, l_1, l_2, IsGussetCompactConfiguration);
        }

        ///<summary> Calculates Connected element strength in compression </summary>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="KL"> Effective length of element in compression </param>
        ///<param name="b"> Width of stiffened or unstiffened compression element </param>
        ///<param name="t"> Thickness of element plate or element wall </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/PlateStrengthInCompression")]
        public Dictionary<string, object> PlateStrengthInCompression(Double F_y, Double KL, Double b, Double t)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.PlateStrengthInCompression(F_y, KL, b, t);
        }

        ///<summary> Calculates Concentrated force web compression buckling </summary>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="h_web"> Clear distance between flanges less the fillet or corner radius for rolled shapes </param>
        ///<param name="F_yw"> Specified minimum yield stress of the web material </param>
        ///<param name="E"> Modulus of elasticity of steel </param>
        ///<param name="d"> Full nominal depth of the section </param>
        ///<param name="l_edge"> Edge distance </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/WebCompressionBuckling")]
        public Dictionary<string, object> WebCompressionBuckling(Double t_w, Double h_web, Double F_yw, Double E, Double d, Double l_edge)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.WebCompressionBuckling(t_w, h_web, F_yw, E, d, l_edge);
        }

        ///<summary> Calculates Concentrated force web local crippling </summary>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="t_f"> Thickness of flange </param>
        ///<param name="l_b"> Length of bearing </param>
        ///<param name="d"> Full nominal depth of the section </param>
        ///<param name="F_yw"> Specified minimum yield stress of the web material </param>
        ///<param name="l_edge"> Edge distance </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/WebLocalCrippling")]
        public Dictionary<string, object> WebLocalCrippling(Double t_w, Double t_f, Double l_b, Double d, Double F_yw, Double l_edge)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.WebLocalCrippling(t_w, t_f, l_b, d, F_yw, l_edge);
        }

        ///<summary> Calculates Concentrated force web local yielding </summary>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="F_yw"> Specified minimum yield stress of the web material </param>
        ///<param name="k"> Distance from outer face of flange to the web toe of fillet </param>
        ///<param name="l_b"> Length of bearing </param>
        ///<param name="d"> Full nominal depth of the section </param>
        ///<param name="l_edge"> Edge distance </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/WebLocalYielding")]
        public Dictionary<string, object> WebLocalYielding(Double t_w, Double F_yw, Double k, Double l_b, Double d, Double l_edge)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.WebLocalYielding(t_w, F_yw, k, l_b, d, l_edge);
        }

        ///<summary> Calculates Concentrated force web panel zone shear </summary>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="t_cf"> Thickness of column flange </param>
        ///<param name="b_cf"> Width of column flange </param>
        ///<param name="d_b"> Nominal fastener diameter </param>
        ///<param name="d_c"> Depth of column </param>
        ///<param name="F_y"> Specified minimum yield stress </param>
        ///<param name="P_u"> Required axial strength </param>
        ///<param name="A_g"> Gross cross-sectional area of member </param>
        ///<param name="PanelDeformationConsideredInAnalysis"> Identifies whether the effect of panel-zone deformation on frame stability is considered in the analysis </param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/WebPanelZoneShear")]
        public Dictionary<string, object> WebPanelZoneShear(Double t_w, Double t_cf, Double b_cf, Double d_b, Double d_c, Double F_y, Double P_u, Double A_g, Boolean PanelDeformationConsideredInAnalysis)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.WebPanelZoneShear(t_w, t_cf, b_cf, d_b, d_c, F_y, P_u, A_g, PanelDeformationConsideredInAnalysis);
        }

        ///<summary> Calculates Concentrated force web sidesway buckling </summary>
        ///<param name="M_u"> Required flexural strength </param>
        ///<param name="M_y"> Moment at yielding of the extreme fiber </param>
        ///<param name="b_f"> Width of flange </param>
        ///<param name="t_f"> Thickness of flange </param>
        ///<param name="t_w"> Thickness of web </param>
        ///<param name="L_b_flange"> Largest laterally unbraced lengthalong either flange at the point of load </param>
        ///<param name="h_web"> Clear distance between flanges less the fillet or corner radius for rolled shapes </param>
        ///<param name="CompressionFlangeRestrained">Identifies whether comression flange is restrained</param>
        ///<returns name="phiR_n"> Strength of member or connection </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/WebSideswayBuckling")]
        public Dictionary<string, object> WebSideswayBuckling(Double M_u, Double M_y, Double b_f, Double t_f, Double t_w, Double L_b_flange, Double h_web, Boolean CompressionFlangeRestrained)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.WebSideswayBuckling(M_u, M_y, b_f, t_f, t_w, L_b_flange, h_web, CompressionFlangeRestrained);
        }

        ///<summary> Calculates Width of Whitmore section </summary>
        ///<param name="l"> Length of connection or weld </param>
        ///<param name="b_con"> Connection width </param>
        ///<returns name="b_Whitmore"> Whitmore section width </returns>

        [HttpGet]
        [Route("Steel/AISC_10/Connection/AffectedElements/WhitmoreSectionWidth")]
        public Dictionary<string, object> WhitmoreSectionWidth(Double l, Double b_con)
        {
            return WosadSteel.AISC_10.Connection.AffectedElements.WhitmoreSectionWidth(l, b_con);
        }

    }

}

