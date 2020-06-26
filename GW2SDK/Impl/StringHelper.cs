﻿using System;

namespace GW2SDK.Impl
{
    internal static class StringHelper
    {
        internal static string ToSnakeCase(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (text.Length > 1)
            {
                var inWord = false;
                for (var i = text.Length - 1; i > 0; i--)
                {
                    if (char.IsLower(text[i]))
                    {
                        inWord = true;
                    }
                    else
                    {
                        if (inWord || !char.IsUpper(text[i - 1]))
                        {
                            text = text.Insert(i, "_");
                        }

                        inWord = false;
                    }
                }
            }

            return text.ToLowerInvariant();
        }
    }
}