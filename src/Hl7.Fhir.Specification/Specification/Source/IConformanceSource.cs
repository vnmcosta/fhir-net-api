/* 
 * Copyright (c) 2016, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://github.com/ewoutkramer/fhir-net-api/blob/master/LICENSE
 */

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Hl7.Fhir.Model;

namespace Hl7.Fhir.Specification.Source
{

    public interface IConformanceSource : IResourceResolver
    {
        /// <summary>
        /// List all resource uris for the resources managed by the source, optionally filtered by type.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<string> ListResourceUris(ResourceType? filter = null);

        /// <summary>
        /// Find ValueSets that define codes for a Codesystem with the given system uri
        /// </summary>
        /// <param name="system"></param>
        /// <returns></returns>
        ValueSet FindValueSetBySystem(string system);

        /// <summary>
        /// Find ConceptMaps which map from the given sourceUri to the given targetUri
        /// </summary>
        /// <param name="sourceUri">An uri that is either the source uri, source ValueSet system or source StructureDefinition canonical url for the map.</param>
        /// <param name="targetUri">An uri that is either the target uri, target ValueSet system or target StructureDefinition canonical url for the map.</param>
        /// <returns></returns>
        /// <remarks>Either sourceUri may be null, or targetUri, but not both</remarks>
        IEnumerable<ConceptMap> FindConceptMaps(string sourceUri=null, string targetUri=null);

        /// <summary>
        /// Finds a NamingSystem resource by matching any of a system's UniqueIds
        /// </summary>
        /// <param name="uniqueid"></param>
        /// <returns></returns>
        NamingSystem FindNamingSystem(string uniqueid);
    }

}