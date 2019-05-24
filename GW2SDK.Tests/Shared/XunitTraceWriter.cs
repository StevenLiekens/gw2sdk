﻿using System;
using System.Diagnostics;
using GW2SDK.Infrastructure;
using Newtonsoft.Json.Serialization;
using Xunit.Abstractions;

namespace GW2SDK.Tests.Shared
{
    internal class XunitTraceWriter : ITraceWriter
    {
        private readonly ITestOutputHelper _output;

        public XunitTraceWriter([NotNull] ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Trace(TraceLevel level, string message, Exception ex)
        {
            _output.WriteLine("{0}: {1}", level.ToString(), message);
        }

        public TraceLevel LevelFilter => TraceLevel.Verbose;
    }
}