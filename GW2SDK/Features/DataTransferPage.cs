﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace GW2SDK
{
    internal sealed class DataTransferPage<T> : IDataTransferPage<T>
    {
        private readonly IPageContext _context;

        private readonly IReadOnlySet<T> _inner;

        public DataTransferPage(IReadOnlySet<T> inner, IPageContext context)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int ResultTotal => _context.ResultTotal;

        public int ResultCount => _context.ResultCount;

        public ContinuationToken? Previous => _context.Previous;

        public ContinuationToken? Next => _context.Next;

        public ContinuationToken First => _context.First;

        public ContinuationToken Self => _context.Self;

        public ContinuationToken Last => _context.Last;

        public int PageTotal => _context.PageTotal;

        public int PageSize => _context.PageSize;

        public IEnumerator<T> GetEnumerator() => _inner.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _inner).GetEnumerator();

        public int Count => _inner.Count;

        public bool Contains(T item) => _inner.Contains(item);

        public bool IsProperSubsetOf(IEnumerable<T> other) => _inner.IsProperSubsetOf(other);

        public bool IsProperSupersetOf(IEnumerable<T> other) => _inner.IsProperSupersetOf(other);

        public bool IsSubsetOf(IEnumerable<T> other) => _inner.IsSubsetOf(other);

        public bool IsSupersetOf(IEnumerable<T> other) => _inner.IsSupersetOf(other);

        public bool Overlaps(IEnumerable<T> other) => _inner.Overlaps(other);

        public bool SetEquals(IEnumerable<T> other) => _inner.SetEquals(other);
    }
}
