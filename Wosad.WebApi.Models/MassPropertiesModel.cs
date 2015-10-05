#region Copyright
   /*Copyright (C) 2015 Wosad Inc

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wosad.Common.Mathematics;

namespace Wosad.WebApi.Models
{
    public class MassPropertiesModel
    {
        public double Area { get; set; }
        public Point2D Centroid { get; set; }
        public Point2D PlasticCentroidCoordinate { get; set; }
        public double MomentOfInertiaX { get; set; }
        public double MomentOfInertiaY { get; set; }
        public double PlasticSectionModulusX { get; set; }
        public double PlasticSectionModulusY { get; set; }
        public double RadiusOfGyrationX { get; set; }
        public double RadiusOfGyrationY { get; set; }
        public double SectionModulusXBot { get; set; }
        public double SectionModulusXTop { get; set; }
        public double SectionModulusYLeft { get; set; }
        public double SectionModulusYRight { get; set; }
        public double TorsionalConstant { get; set; }

    }
}
