﻿extern alias json;

using json.Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOM = Microsoft.AnalysisServices.Tabular;

namespace TabularEditor.TOMWrapper
{
    public partial class Perspective
    {
    }

    public partial class PerspectiveCollection
    {
        internal class SerializedPerspective
        {
            public string Name;
            public string Description;
            public Dictionary<string, string> Annotations;
        }

        internal string ToJson()
        {
            // TODO: We should really use the TOM JsonSerializer here instead...

            return JsonConvert.SerializeObject(this.Select(p => 
            new SerializedPerspective {
                Name = p.Name,
                Description = p.Description,
                Annotations = p.Annotations.Keys.ToDictionary(k => k, k => p.GetAnnotation(k))
            }).OrderBy(p => p.Name).ToArray());
        }
    }
}
