﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenFX.Core
{
    internal static class ObjectCache<T> where T : HandleObject, new()
    {
        private static Dictionary<int, T> m_dictionary = new Dictionary<int, T>();

        public static T Get(int handle)
        {
            T item;

            if (!m_dictionary.TryGetValue(handle, out item))
            {
                item = new T();
                item.SetHandle(handle);
            }

            return item;
        }

        public static void Add(T item)
        {
            m_dictionary.Add(item.Handle, item);
        }

        public static void Remove(T item)
        {
            m_dictionary.Remove(item.Handle);
        }
    }
}
