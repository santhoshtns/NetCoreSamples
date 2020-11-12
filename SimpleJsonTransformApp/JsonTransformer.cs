using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SimpleJsonTransformApp
{
    internal class JsonTransformer
    {
        internal string Transform(IEnumerable<JToken> tokens)
        {
            foreach (JToken child in tokens)
            {
                switch (child.Type)
                {
                    case JTokenType.None:
                        break;
                    case JTokenType.Object:
                        break;
                    case JTokenType.Array:
                        Transform(child.Values<JToken>());
                        break;
                    case JTokenType.Constructor:
                        break;
                    case JTokenType.Property:
                        break;
                    case JTokenType.Comment:
                        break;
                    case JTokenType.Integer:
                        break;
                    case JTokenType.Float:
                        break;
                    case JTokenType.String:
                        break;
                    case JTokenType.Boolean:
                        break;
                    case JTokenType.Null:
                        break;
                    case JTokenType.Undefined:
                        break;
                    case JTokenType.Date:
                        break;
                    case JTokenType.Raw:
                        break;
                    case JTokenType.Bytes:
                        break;
                    case JTokenType.Guid:
                        break;
                    case JTokenType.Uri:
                        break;
                    case JTokenType.TimeSpan:
                        break;
                    default:
                        break;
                }

                if (child.HasValues)
                {
                    Transform(child.Values<JToken>());
                }
            }


            return "";
        }
    }
}