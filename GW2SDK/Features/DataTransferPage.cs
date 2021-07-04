﻿using System;
using System.Collections.Generic;

namespace GW2SDK
{
    internal sealed class DataTransferPage<T> : IDataTransferPage<T>
    {
        public DataTransferPage(
            bool hasValue,
            DateTimeOffset? update = null,
            IReadOnlySet<T>? value = default,
            IPageContext? context = null,
            DateTimeOffset? expires = null,
            DateTimeOffset? lastModified = null
        )
        {
            HasValues = hasValue;
            Update = update;
            if (hasValue)
            {
                Values = value ?? throw new ArgumentNullException(nameof(value));
                Context = context ?? throw new ArgumentNullException(nameof(context));
                Expires = expires;
                LastModified = lastModified;
            }
        }

        public DateTimeOffset? Update { get; }

        public DateTimeOffset? Expires { get; }

        public DateTimeOffset? LastModified { get; }

        public bool HasValues { get; }

        public IReadOnlySet<T>? Values { get; }

        public IPageContext? Context { get; }
    }
}
