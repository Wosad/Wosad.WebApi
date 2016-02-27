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
    ///Analysis.Section.AISC.StandardShapeProperties Dynamo Web Api Wrapper
    /// </summary>
    [RoutePrefix("api")]
    public class AnalysisSectionAISCStandardShapePropertiesController : ApiController
    {
        ///<summary> Calculates AISC shape geometric properties </summary>
        ///<param name="SteelShapeId"> Section name from steel shape database </param>
        ///<returns>
        /// name="d" Full nominal depth of the section 
        /// name="b_f" Width of flange 
        /// name="t_f" Thickness of flange 
        /// name="t_w" Thickness of web 
        /// name="k" Distance from outer face of flange to the web toe of fillet 
        /// name="D" Outside diameter of round HSS 
        /// name="B" Overall width of rectangular steel section along face transferring load or overall width of rectangular HSS member 
        /// name="H_t" Overall depth of square or rectangular HSS 
        /// name="t" Thickness of element plate or element wall 
        /// name="t_nom" HSS and pipe nominal wall thickness 
        /// name="A" Cross-sectional area 
        ///</returns>

        [HttpGet]
        [Route("Analysis/Section/AISC/StandardShapeProperties/ShapeBasicGeometricProperties")]
        public Dictionary<string, object> ShapeBasicGeometricProperties(String SteelShapeId)
        {
            return WosadAnalysis.Section.AISC.StandardShapeProperties.ShapeBasicGeometricProperties(SteelShapeId);
        }

        ///<summary> Calculates AISC shape torsional properties </summary>
        ///<param name="SteelShapeId"> Section name from steel shape database </param>
        ///<returns>
        /// name="J" Torsional constant (Torsional moment of inertia) 
        /// name="C" HSS torsional constant 
        /// name="C_w" Warping constant 
        /// name="W_no" Normalized warping function 
        /// name="S_w1" Warping statical moment at point 1 on cross section 
        /// name="S_w2" Warping statical moment at point 2 on cross section 
        /// name="S_w3" Warping statical moment at point 3 on cross section 
        /// name="Q_fl" Statical moment for a point in the flange directly above the vertical edge of the web 
        /// name="Q_w" Statical moment for a point at mid-depth of the cross section 
        ///</returns>

        [HttpGet]
        [Route("Analysis/Section/AISC/StandardShapeProperties/TorsionalProperties")]
        public Dictionary<string, object> TorsionalProperties(String SteelShapeId)
        {
            return WosadAnalysis.Section.AISC.StandardShapeProperties.TorsionalProperties(SteelShapeId);
        }

        ///<summary> Calculates AISC shape properties about X axis </summary>
        ///<param name="SteelShapeId"> Section name from steel shape database </param>
        ///<returns>
        /// name="x_e" Horizontal distance from designated member edge to member elastic centroidal axis 
        /// name="x_p" Horizontal distance from designated member edge to member plastic neutral axis 
        /// name="I_x" Moment of inertia about the principal x-axis 
        /// name="Z_x" Plastic section modulus about the x-axis 
        /// name="S_x" Elastic section modulus taken about the x-axis 
        /// name="r_x" Radius of gyration about the x-axis 
        ///</returns>

        [HttpGet]
        [Route("Analysis/Section/AISC/StandardShapeProperties/XAxisProperties")]
        public Dictionary<string, object> XAxisProperties(String SteelShapeId)
        {
            return WosadAnalysis.Section.AISC.StandardShapeProperties.XAxisProperties(SteelShapeId);
        }

        ///<summary> Calculates AISC shape properties about Y axis </summary>
        ///<param name="SteelShapeId"> Section name from steel shape database </param>
        ///<returns>
        /// name="y_e" Vertical distance from designated member edge to member elastic centroidal axis 
        /// name="y_p" Vertical distance from designated member edge to member plastic neutral axis 
        /// name="I_y" Moment of inertia about the principal y-axis 
        /// name="Z_y" Plastic section modulus about the y-axis 
        /// name="S_y" Elastic section modulus taken about the y-axis. For a channel the minimum section modulus 
        /// name="r_y" Radius of gyration about y-axis 
        ///</returns>

        [HttpGet]
        [Route("Analysis/Section/AISC/StandardShapeProperties/YAxisProperties")]
        public Dictionary<string, object> YAxisProperties(String SteelShapeId)
        {
            return WosadAnalysis.Section.AISC.StandardShapeProperties.YAxisProperties(SteelShapeId);
        }

    }

}

