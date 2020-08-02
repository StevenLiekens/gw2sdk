﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GW2SDK.Impl.JsonReaders.Mappings
{
    public partial class JsonObjectMapping<TObject>
    {
        public void Map(string propertyName, Expression<Func<TObject, int>> int32)
        {
            Children.Add(new JsonPropertyMapping
            {
                Name = propertyName,
                Destination = ((MemberExpression) int32.Body).Member,
                Significance = MappingSignificance.Required,
                ValueNode = new JsonValueMapping<int>
                {
                    ValueKind = JsonValueMappingKind.Int32,
                    Significance = MappingSignificance.Required
                }
            });
        }

        public void Map(string propertyName, Expression<Func<TObject, int?>> int32)
        {
            Children.Add(new JsonPropertyMapping
            {
                Name = propertyName,
                Destination = ((MemberExpression) int32.Body).Member,
                Significance = MappingSignificance.Optional,
                ValueNode = new JsonValueMapping<int?>
                {
                    ValueKind = JsonValueMappingKind.Int32,
                    Significance = MappingSignificance.Optional
                }
            });
        }
        
        public void Map(
            string propertyName,
            Expression<Func<TObject, IEnumerable<int>?>> int32s,
            MappingSignificance significance = MappingSignificance.Required)
        {
            Children.Add(new JsonPropertyMapping
            {
                Name = propertyName,
                Destination = ((MemberExpression) int32s.Body).Member,
                Significance = significance,
                ValueNode = new JsonArrayMapping<int>
                {
                    ValueMapping = new JsonValueMapping<int>
                    {
                        ValueKind = JsonValueMappingKind.Int32,
                        Significance = MappingSignificance.Required
                    },
                    Significance = significance
                },
            });
        }
        
        public void Map(
            string propertyName,
            Expression<Func<TObject, IEnumerable<int?>?>> int32s,
            MappingSignificance significance = MappingSignificance.Required)
        {
            Children.Add(new JsonPropertyMapping
            {
                Name = propertyName,
                Destination = ((MemberExpression) int32s.Body).Member,
                Significance = significance,
                ValueNode = new JsonArrayMapping<int?>
                {
                    ValueMapping = new JsonValueMapping<int?>
                    {
                        ValueKind = JsonValueMappingKind.Int32,
                        Significance = MappingSignificance.Optional
                    },
                    Significance = significance
                }
            });
        }
    }
}