using GDS.Mades.Data.Core.Storeable;
using GDS.Mades.Data.Engine.Data;
using GDS.Mades.Data.Interfaces.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GDS.Mades.Data.Mock.Store
{
    public class JsonStoreMock
    {
        private static Type[] availableTypes = new[] {
                                                typeof(int),
                                                typeof(double),
                                                typeof(float),
                                                typeof(string)
                                              };

        public static CreateStoreInfo GenerateRandomStore()
        {
            Random rand = new Random();
            int index = (rand.Next() % availableTypes.Length);

            return new CreateStoreInfo(Guid.NewGuid(), availableTypes[index]);
        }

        public static IStoreable GetSingleData(Type type)
        {
            Random random = new Random();
            object id = null;

            if (type == typeof(int))
                id = random.Next();
            if (type == typeof(double))
                id = random.NextDouble();
            if (type == typeof(float))
                id = (float)random.NextDouble();
            if (type == typeof(string))
                id = Guid.NewGuid().ToString();

            JsonMockStoreable data = new JsonMockStoreable(type, id);

            return new JsonStoreable {
                                       IndexType = data.IndexType,
                                       StoringId = data.StoringId,
                                       Json = data.Json
                                     };
        }

        public static List<IStoreable> GetMultiData(Type type, int count = 0)
        {
            List<IStoreable> data = new List<IStoreable>();

            Random random = new Random();

            if (count == 0)
                count = random.Next() % 10;

            for (int iter = 0; iter < count;)
            {
                IStoreable single = GetSingleData(type);

                if (data.Any(item => item.StoringId == single.StoringId))
                    continue;

                data.Add(single);

                iter++;
            }

            return data;
        }

        public class JsonMockStoreable : JsonStoreable
        {
            public JsonMockStoreable(Type indexType, object storingId)
            {
                IndexType = indexType.ToString();
                StoringId = storingId;
                MockJson();
            }

            private void MockJson()
            {
                Json = JsonConvert.SerializeObject(new MockData());
            }
        }
    }
}
