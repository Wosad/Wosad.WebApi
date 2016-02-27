//#region Copyright
//   /*Copyright (C) 2015 Wosad Inc

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//   http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//   */
//#endregion
 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using Wosad.Common.Section.SectionTypes;
//using Wosad.WebApi.Models;

//namespace Wosad.WebApi.Controllers
//{
//    [RoutePrefix("api")]
//    public class SectionIRolledController : ApiController
//    {

//        /// <summary>
//        /// Procedure retreives IRolled section mass properties
//        /// </summary>
//        /// <param name="depth"></param>
//        /// <param name="flangeWidth"></param>
//        /// <param name="flangeThickness"></param>
//        /// <param name="webThickness"></param>
//        /// <param name="filletDistance"></param>
//        /// <returns></returns>
//        [Route("massprop/irolled/depth/{depth:double}/flangeWidth/{flangeWidth:double}/flangeThickness/{flangeThickness:double}/webThickness/{webThickness:double}/filletDistance/{filletDistance:double}/full")]
//        // example "", 17.7, 6.0, 0.425, 0.3, 0.827
//        // massprop/irolled/depth/17.7/flangeWidth/6.0/flangeThickness/0.425/webThickness/0.3/filletDistance/0.827/full"
//        public MassPropertiesModel GetFull(double depth, 
//            double flangeWidth, double flangeThickness, double webThickness, 
//            double filletDistance)
//        {
//            SectionIRolled section = new SectionIRolled("", depth, flangeWidth, flangeThickness, webThickness, filletDistance);
        
//            MassPropertiesModel result = new MassPropertiesModel
//            {
//                Area = section.Area,
//                Centroid = section.Centroid,
//                MomentOfInertiaX = section.MomentOfInertiaX,
//                MomentOfInertiaY = section.MomentOfInertiaY,
//                RadiusOfGyrationX = section.RadiusOfGyrationX,
//                RadiusOfGyrationY= section.RadiusOfGyrationY,
//                SectionModulusXBot = section.SectionModulusXBot,
//                SectionModulusXTop = section.SectionModulusXTop,
//                SectionModulusYLeft = section.SectionModulusYLeft,
//                SectionModulusYRight = section.SectionModulusYRight,
//                TorsionalConstant = section.TorsionalConstant,
//                // doesn't work for some reason
//                //PlasticCentroidCoordinate = section.PlasticCentroidCoordinate,
//                //PlasticSectionModulusX = section.PlasticSectionModulusX,
//                //PlasticSectionModulusY = section.PlasticSectionModulusY,
//            };

//            return result;
//        }

//        /// <summary>
//        /// Procedure retreives IRolled section area
//        /// </summary>
//        /// <param name="depth"></param>
//        /// <param name="flangeWidth"></param>
//        /// <param name="flangeThickness"></param>
//        /// <param name="webThickness"></param>
//        /// <param name="filletDistance"></param>
//        /// <returns></returns>
//        [Route("massprop/irolled/depth/{depth:double}/flangeWidth/{flangeWidth:double}/flangeThickness/{flangeThickness:double}/webThickness/{webThickness:double}/filletDistance/{filletDistance:double}/area")]
//        // example "", 17.7, 6.0, 0.425, 0.3, 0.827
//        // massprop/irolled/depth/17.7/flangeWidth/6.0/flangeThickness/0.425/webThickness/0.3/filletDistance/0.827/full"
//        public double GetArea(double depth,
//            double flangeWidth, double flangeThickness, double webThickness,
//            double filletDistance)
//        {
//            SectionIRolled section = new SectionIRolled("", depth, flangeWidth, flangeThickness, webThickness, filletDistance);

//            return section.Area;                
//        }

//        /// <summary>
//        /// Procedure retreives IRolled section moment of inertia about X axis
//        /// </summary>
//        /// <param name="depth"></param>
//        /// <param name="flangeWidth"></param>
//        /// <param name="flangeThickness"></param>
//        /// <param name="webThickness"></param>
//        /// <param name="filletDistance"></param>
//        /// <returns></returns>
//        [Route("massprop/irolled/depth/{depth:double}/flangeWidth/{flangeWidth:double}/flangeThickness/{flangeThickness:double}/webThickness/{webThickness:double}/filletDistance/{filletDistance:double}/momentOfInertiaX")]
//        // example "", 17.7, 6.0, 0.425, 0.3, 0.827
//        // massprop/irolled/depth/17.7/flangeWidth/6.0/flangeThickness/0.425/webThickness/0.3/filletDistance/0.827/full"
//        public double GetMomentOfInertiaX(double depth,
//            double flangeWidth, double flangeThickness, double webThickness,
//            double filletDistance)
//        {
//            SectionIRolled section = new SectionIRolled("", depth, flangeWidth, flangeThickness, webThickness, filletDistance);

//            return section.MomentOfInertiaX;
//        }


//        /// <summary>
//        /// Procedure retreives IRolled section moment of inertia about Y axis
//        /// </summary>
//        /// <param name="depth"></param>
//        /// <param name="flangeWidth"></param>
//        /// <param name="flangeThickness"></param>
//        /// <param name="webThickness"></param>
//        /// <param name="filletDistance"></param>
//        /// <returns></returns>
//        [Route("massprop/irolled/depth/{depth:double}/flangeWidth/{flangeWidth:double}/flangeThickness/{flangeThickness:double}/webThickness/{webThickness:double}/filletDistance/{filletDistance:double}/momentOfInertiaY")]
//        // example "", 17.7, 6.0, 0.425, 0.3, 0.827
//        // massprop/irolled/depth/17.7/flangeWidth/6.0/flangeThickness/0.425/webThickness/0.3/filletDistance/0.827/full"
//        public double GetMomentOfInertiaY(double depth,
//            double flangeWidth, double flangeThickness, double webThickness,
//            double filletDistance)
//        {
//            SectionIRolled section = new SectionIRolled("", depth, flangeWidth, flangeThickness, webThickness, filletDistance);

//            return section.Area;
//        }

//    }
//}
