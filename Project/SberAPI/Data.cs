using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SberAPI.Models;

namespace SberAPI
{
    public static class Data
    {
        public static SberCloudContext SberCloudContext;

        public static void Initialize()
        {
            SberCloudContext = new SberCloudContext();
        }
    }
}
